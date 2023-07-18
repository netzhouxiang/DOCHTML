using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DOCHTML
{
    using Word = Microsoft.Office.Interop.Word;
    public partial class DocHtmlForm : Form
    {
        public DocHtmlForm()
        {
            InitializeComponent();
        }

        private void DocHtmlForm_Load(object sender, EventArgs e)
        {

        }

        public static string GetWordContent(string path, DocHtmlForm hx)
        {
            try
            {
                Word.Application app = new Word.Application();
                Type wordType = app.GetType();
                Word.Document doc = null;
                object unknow = Type.Missing;
                app.Visible = false;

                object file = path;
                doc = app.Documents.Open(ref file,
                ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow, ref unknow,
                ref unknow, ref unknow, ref unknow);
                int count = doc.Paragraphs.Count;

                string diyhtml = "<html lang=zh-cn><head><meta charset=utf-8><meta http-equiv=pragram content=no-cache><meta http-equiv=cache-control content=\"no - cache, no - store, must - revalidate\"><meta http-equiv=expires content=0><meta name=renderer content=webkit><meta name=force-rendering content=webkit><meta http-equiv=X-UA-Compatible content=\"IE = edge,chrome = 1\"><meta name=viewport content=\"width = device - width,initial - scale = 1\"><style>.htmlCss {color: #333333;}.htmlCss p {line-height: 19pt;text-indent: 21pt;margin: 0;font-size: 15px;}.htmlCss p.indent {text-indent: 0pt;}.htmlCss .center {text-align: center;text-indent: 0pt;}.htmlCss .right {text-align: right;}.htmlCss .float_right {float: right;margin-right: 20px;text-indent: 0;}</style></head><body><div class=\"htmlCss\">";
                for (int i = 1; i <= count; i++)
                {
                    var range = doc.Paragraphs[i].Range;
                    string text = range.Text;
                    if (i == 1)
                    {
                        diyhtml += "<h2 class=\"center\">" + text.Trim() + "</h2>";
                    }
                    else
                    {
                        if (text.Trim() != "")
                        {
                            string h = "<p>";
                            if (doc.Paragraphs[i].Alignment == Word.WdParagraphAlignment.wdAlignParagraphRight)
                            {
                                h = "<p class=\"right\">";
                            }
                            if (doc.Paragraphs[i].Alignment == Word.WdParagraphAlignment.wdAlignParagraphCenter)
                            {
                                h = "<p class=\"center\">";
                                if (range.Font.Size > 16)
                                {
                                    h = "<h2 class=\"center\">";
                                }
                            }
                            if (range.ListFormat.ListValue > 0 && range.ListFormat.ListString != null)
                            {
                                h += range.ListFormat.ListString;
                            }
                            if (range.Bold != 0 || range.Underline != Word.WdUnderline.wdUnderlineNone)
                            {
                                for (int y = 1; y <= range.Words.Count; y++)
                                {
                                    var w = range.Words[y];
                                    string txt = w.Text;
                                    if (w.Underline != Word.WdUnderline.wdUnderlineNone)
                                    {
                                        // 如果标记下划线
                                        h += "<u>" + txt + "</u>";
                                    }
                                    else if (w.Bold != 0)
                                    {
                                        // 如果标记加粗
                                        h += "<b>" + txt + "</b>";
                                    }
                                    else
                                    {
                                        h += txt;
                                    }
                                }

                                if (range.Font.Size > 16)
                                {
                                    h += "</h2>";
                                }
                                else
                                {
                                    h += "</p>";
                                }
                            }
                            else
                            {
                                h += text.Trim();
                                if (range.Font.Size > 16)
                                {
                                    h += "</h2>";
                                }
                                else
                                {
                                    h += "</p>";
                                }
                            }
                            diyhtml += h;
                        }
                        else
                        {
                            diyhtml += "<p>&nbsp;</p>";
                        }

                    }

                    double aa = (double)(Math.Round((decimal)(Convert.ToDouble(i) / Convert.ToDouble(count)), 2));
                    hx.UpdateJD(Convert.ToInt32(aa * 100));
                }

                diyhtml += "</div></body></html>";

                diyhtml = diyhtml.Replace("</b><b>", "");
                diyhtml = diyhtml.Replace("</u><u>", "");

                doc.Close(ref unknow, ref unknow, ref unknow);
                wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, app, null);
                doc = null;
                app = null;
                //垃圾回收
                GC.Collect();
                GC.WaitForPendingFinalizers();

                return diyhtml;
            }
            catch
            {
                return "";
            }
        }


        private delegate void UpdateJDBack(int jd);
        public void UpdateJD(int jd)
        {
            if (pjd.InvokeRequired)
            {
                UpdateJDBack d = new UpdateJDBack(UpdateJD);
                this.Invoke(d, new object[] { jd });
            }
            else
            {
                pjd.Value = jd;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择Word文档";
            dialog.Filter = "Word文档|*.doc;*.docx";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                txtURL.Text = file;
                var xx = this;
                // 线程处理
                Thread newThread = new Thread(new ParameterizedThreadStart(delegate
                {
                    UpdateJD(0);
                    string doc = GetWordContent(file, xx);
                    string name = dialog.SafeFileName.Replace(".docx", "");
                    name = name.Replace(".doc", "");
                    string html = Application.StartupPath + "/" + name + ".html";
                    FileStream fs = new FileStream(html, FileMode.Create);
                    StreamWriter wr = null;
                    wr = new StreamWriter(fs); wr.WriteLine(doc); wr.Close();
                    MessageBox.Show("转换成功", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                newThread.Start();
            }
        }
    }
}
