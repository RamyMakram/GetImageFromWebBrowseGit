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
        bool Enter = true;
        Microsoft.Office.Interop.Excel.Worksheet sh;
        Thread Task;
        public Form1()
        {
            InitializeComponent();
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = ExcelApp.Workbooks.Open(Directory.GetCurrentDirectory() + "\\Sheet6000.xlsx", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            sh = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[2];
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            System.Timers.Timer t = new System.Timers.Timer(3000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(Session_Start);
            t.Start();
        }
        void Session_Start(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(url);
            if (url == 3)
            {
                string ProName = sh.Cells[url, 2].Value.ToString();
                string ss = "https://www.google.com/search?biw=1366&bih=663&tbm=isch&sxsrf=ACYBGNRsFK23-nOW5PQf_E_XfAHl3lGxrg%3A1576403238675&sa=1&ei=JgH2XYXMKNTygQb5loeYCA&q=" + Uri.EscapeDataString(ProName);
                web.Navigate(ss);
                url++;
            }
            else if (!Enter && url <= 6428)
            {
                Enter = true;
                string ProName = sh.Cells[url, 2].Value.ToString();
                string ss = "https://www.google.com/search?biw=1366&bih=663&tbm=isch&sxsrf=ACYBGNRsFK23-nOW5PQf_E_XfAHl3lGxrg%3A1576403238675&sa=1&ei=JgH2XYXMKNTygQb5loeYCA&q=" + Uri.EscapeDataString(ProName);
                web.Navigate(ss);
                url++;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection s = this.web.Document.GetElementsByTagName("img");
            for (int i = 0; i < s.Count; i++)
            {
                string imgUrl = s[i].GetAttribute("src");
                if (imgUrl != "" && !imgUrl.StartsWith("https://www.google") && !imgUrl.Split(',')[0].Contains("svg"))
                {
                    string base64 = imgUrl.Split(',')[1];
                    File.WriteAllBytes("D:\\Images\\" + sh.Cells[url-1, 1].Value.ToString() + ".png", Convert.FromBase64String(base64));
                    Enter = false;
                    break;
                }
            }
        }
    }
}
