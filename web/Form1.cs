using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using mshtml;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace web
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database3.accdb");
        static int url = 4;
        DataSet ds;
        private bool Enter = true;
        Microsoft.Office.Interop.Excel.Worksheet sh;
        string PathSheet = "";
        string ImgFolder = "";
        System.Timers.Timer t;
        Microsoft.Office.Interop.Excel.Workbook wb;
        string ProName = "";
        string ss = "";
        public Form1()
        {
            InitializeComponent();
        }
        void Session_Start(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (url == Start.Value)
            {
                ProName = sh.Cells[url, 2].Value.ToString();
                ss = "https://www.google.com/search?biw=1366&bih=663&tbm=isch&sxsrf=ACYBGNRsFK23-nOW5PQf_E_XfAHl3lGxrg%3A1576403238675&sa=1&ei=JgH2XYXMKNTygQb5loeYCA&q=" + Uri.EscapeDataString(ProName);
                web.Navigate(ss);
                url++;
            }
            else if (!Enter && url <= End.Value)
            {
                Enter = true;
                ProName = sh.Cells[url, 2].Value.ToString();
                ss = "https://www.google.com/search?biw=1366&bih=663&tbm=isch&sxsrf=ACYBGNRsFK23-nOW5PQf_E_XfAHl3lGxrg%3A1576403238675&sa=1&ei=JgH2XYXMKNTygQb5loeYCA&q=" + Uri.EscapeDataString(ProName);
                web.Navigate(ss);
                url++;
            }
            else if (url > End.Value)
            {
                t.Stop();
                this.panel1.Enabled = true;
            }
            else
            {
                web.Navigate(ss);
            }
            Debug.WriteLine(url);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                LBLCount.Text = (url).ToString();
                string Path = ImgFolder + "\\" + sh.Cells[url - 1, 1].Value.ToString() + ".png";
                var Elements = this.web.Document.GetElementsByTagName("img");
                for (int i = 2; i < 300; i++)
                {
                    string imgUrl = Elements[i].GetAttribute("src");
                    if (imgUrl != "" && !imgUrl.StartsWith("https://www.google") && !imgUrl.Contains("svg"))
                    {
                        byte[] Arr = Convert.FromBase64String(imgUrl.Split(',')[1]);
                        File.WriteAllBytes(Path, Arr);
                        Enter = false;
                        break;
                    }
                }
            }
            catch (Exception ث)
            {
                MessageBox.Show("Error In Row Number # " + (url).ToString());
                Enter = true;
                t.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PathSheet != "" && ImgFolder != "")
            {
                url = (int)Start.Value;
                LBLCount.Text = url.ToString();
                button1.Enabled = false;
                this.panel1.Enabled = false;
                sh = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[SheetNum.Value];
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
                t = new System.Timers.Timer(5000);
                t.Elapsed += new System.Timers.ElapsedEventHandler(Session_Start);
                t.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Exel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlxs",
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = false,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathSheet = openFileDialog1.FileName;
                LBLSheetPath.Text = PathSheet;
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Visible = true;
                wb = ExcelApp.Workbooks.Open(PathSheet, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                ImgFolder = folderDlg.SelectedPath;
                LBLImgPath.Text = ImgFolder;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            t.Start();
        }
    }
}
