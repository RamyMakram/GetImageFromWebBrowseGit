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
        int url = 3;
        DataSet ds;
        private bool Enter = true;
        Microsoft.Office.Interop.Excel.Worksheet sh;
        string PathSheet = "";
        string ImgFolder = "";
        System.Timers.Timer t;
        public Form1()
        {
            InitializeComponent();
        }
        void Session_Start(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (url == Start.Value)
            {
                string ProName = sh.Cells[url, 2].Value.ToString();
                string ss = "https://www.google.com/search?biw=1366&bih=663&tbm=isch&sxsrf=ACYBGNRsFK23-nOW5PQf_E_XfAHl3lGxrg%3A1576403238675&sa=1&ei=JgH2XYXMKNTygQb5loeYCA&q=" + Uri.EscapeDataString(ProName);
                web.Navigate(ss);
                url++;
            }
            else if (!Enter && url <= End.Value)
            {
                Enter = true;
                string ProName = sh.Cells[url, 2].Value.ToString();
                string ss = "https://www.google.com/search?biw=1366&bih=663&tbm=isch&sxsrf=ACYBGNRsFK23-nOW5PQf_E_XfAHl3lGxrg%3A1576403238675&sa=1&ei=JgH2XYXMKNTygQb5loeYCA&q=" + Uri.EscapeDataString(ProName);
                web.Navigate(ss);
                url++;
            }
            else if (url > End.Value)
            {
                t.Stop();
                button1.Enabled = true;
                this.panel1.Enabled = true;
            }
            Debug.WriteLine(url);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                LBLCount.Text = url.ToString();
                HtmlElementCollection s = this.web.Document.GetElementsByTagName("img");
                for (int i = 0; i < s.Count; i++)
                {
                    string imgUrl = s[i].GetAttribute("src");
                    if (imgUrl != "" && !imgUrl.StartsWith("https://www.google") && !imgUrl.Split(',')[0].Contains("svg"))
                    {
                        string base64 = imgUrl.Split(',')[1];
                        File.WriteAllBytes(ImgFolder + "\\" + sh.Cells[url - 1, 1].Value.ToString() + ".png", Convert.FromBase64String(base64));
                        Enter = false;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error in " + url.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PathSheet != "" && ImgFolder != "")
            {
                LBLCount.Text = url.ToString();
                button1.Enabled = false;
                this.panel1.Enabled = false;
                url = (int)Start.Value;
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = ExcelApp.Workbooks.Open(PathSheet, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                sh = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[SheetNum.Value];
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
                t = new System.Timers.Timer(3000);
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
    }
}
