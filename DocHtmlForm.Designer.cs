
namespace DOCHTML
{
    partial class DocHtmlForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocHtmlForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.pjd = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(310, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "选择文件";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(48, 38);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(256, 21);
            this.txtURL.TabIndex = 1;
            // 
            // pjd
            // 
            this.pjd.Location = new System.Drawing.Point(-1, 94);
            this.pjd.Name = "pjd";
            this.pjd.Size = new System.Drawing.Size(439, 10);
            this.pjd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(119, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "转换完成后，请再次人工确认格式！";
            // 
            // DocHtmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 104);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pjd);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocHtmlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOC转HTML工具 - 哔哔大侠（bbdaxia.com）";
            this.Load += new System.EventHandler(this.DocHtmlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ProgressBar pjd;
        private System.Windows.Forms.Label label1;
    }
}

