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
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.NumericUpDown();
            this.End = new System.Windows.Forms.NumericUpDown();
            this.SheetNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBLSheetPath = new System.Windows.Forms.Label();
            this.LBLImgPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBLCount = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.End)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetNum)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.web.Location = new System.Drawing.Point(0, 156);
            this.web.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.web.MinimumSize = new System.Drawing.Size(17, 16);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(652, 593);
            this.web.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(565, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Sheet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Image Folder";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(417, 23);
            this.Start.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Start.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(120, 20);
            this.Start.TabIndex = 6;
            this.Start.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(417, 56);
            this.End.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.End.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(120, 20);
            this.End.TabIndex = 6;
            this.End.Value = new decimal(new int[] {
            6800,
            0,
            0,
            0});
            // 
            // SheetNum
            // 
            this.SheetNum.Location = new System.Drawing.Point(417, 89);
            this.SheetNum.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.SheetNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SheetNum.Name = "SheetNum";
            this.SheetNum.Size = new System.Drawing.Size(120, 20);
            this.SheetNum.TabIndex = 6;
            this.SheetNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sheet Number";
            // 
            // LBLSheetPath
            // 
            this.LBLSheetPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LBLSheetPath.Location = new System.Drawing.Point(87, 37);
            this.LBLSheetPath.Name = "LBLSheetPath";
            this.LBLSheetPath.Size = new System.Drawing.Size(260, 13);
            this.LBLSheetPath.TabIndex = 7;
            this.LBLSheetPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBLImgPath
            // 
            this.LBLImgPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LBLImgPath.Location = new System.Drawing.Point(53, 98);
            this.LBLImgPath.Name = "LBLImgPath";
            this.LBLImgPath.Size = new System.Drawing.Size(309, 13);
            this.LBLImgPath.TabIndex = 7;
            this.LBLImgPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBLCount);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LBLSheetPath);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.End);
            this.panel1.Controls.Add(this.LBLImgPath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SheetNum);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(652, 122);
            this.panel1.TabIndex = 10;
            // 
            // LBLCount
            // 
            this.LBLCount.AutoSize = true;
            this.LBLCount.Location = new System.Drawing.Point(588, 109);
            this.LBLCount.Name = "LBLCount";
            this.LBLCount.Size = new System.Drawing.Size(0, 13);
            this.LBLCount.TabIndex = 10;
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(588, 128);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(49, 23);
            this.Stop.TabIndex = 4;
            this.Stop.Text = "| | Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(533, 128);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(49, 23);
            this.Run.TabIndex = 4;
            this.Run.Text = "<| Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.web);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.Stop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.End)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetNum)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser web;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button2;
        private Button button3;
        private NumericUpDown Start;
        private NumericUpDown End;
        private NumericUpDown SheetNum;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label LBLSheetPath;
        private Label LBLImgPath;
        private Panel panel1;
        private Label LBLCount;
        private Button Stop;
        private Button Run;
    }
}

