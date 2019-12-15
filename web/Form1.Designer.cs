using System.Windows.Forms;

namespace web
{
    partial class Form1 : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.web = new System.Windows.Forms.WebBrowser();
            this.txturl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.web.Location = new System.Drawing.Point(-3, 53);
            this.web.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.web.MinimumSize = new System.Drawing.Size(17, 16);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(927, 554);
            this.web.TabIndex = 0;
            // 
            // txturl
            // 
            this.txturl.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txturl.Location = new System.Drawing.Point(286, 10);
            this.txturl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txturl.Multiline = true;
            this.txturl.Name = "txturl";
            this.txturl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txturl.Size = new System.Drawing.Size(540, 31);
            this.txturl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 603);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.web);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txturl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Label label1;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

