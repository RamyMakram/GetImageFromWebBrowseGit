using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace web
{
	public partial class Form1 : Form
	{
		MultiThreadSort.Semaphore sema;
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
		async void navigate()
		{
			lock (this)
			{
				if (url <= End.Value)
				{
					Enter = true;
					ProName = sh.Cells[url, 2].Value.ToString();
					ss = "https://www.google.com/search?tbm=isch&q=" + Uri.EscapeDataString(ProName);
					web.Navigate(ss);
					url++;
					sema.Wait();
				}
				else
				{
					t.Stop();
					this.panel1.Enabled = true;
				}
			}
		}
		private async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			try
			{
				LBLCount.Text = url.ToString();
				string Path = ImgFolder + "\\" + sh.Cells[url - 1, 1].Value.ToString() + ".png";
				var Elements = this.web.Document.GetElementsByTagName("img");
				for (int i = 2; i < 300; i++)
				{
					string imgUrl = Elements[i].GetAttribute("src");
					if (imgUrl != "" && !imgUrl.StartsWith("https://www.google") && !imgUrl.Contains("svg"))
					{
						byte[] Arr = Convert.FromBase64String(imgUrl.Split(',')[1]);
						File.WriteAllBytes(Path, Arr);
						if (File.Exists(Path) && File.Open(Path, FileMode.Open).Length != 0)
						{
							sema.Signal();
							navigate();
						}
						else Thread.Sleep(100);
						break;
					}
				}
			}
			catch (Exception ث)
			{
				MessageBox.Show("Error In Row Number # " + (url).ToString());
				Enter = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			sema = new MultiThreadSort.Semaphore(1);
			web.ScriptErrorsSuppressed = true;
			if (PathSheet != "" && ImgFolder != "")
			{
				url = (int)Start.Value;
				LBLCount.Text = url.ToString();
				button1.Enabled = false;
				this.panel1.Enabled = false;
				sh = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[SheetNum.Value];
				ProName = sh.Cells[url, 2].Value.ToString();
				ss = "https://www.google.com/search?tbm=isch&q=" + Uri.EscapeDataString(ProName);
				web.Navigate(ss);
				url++;
				web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
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
			web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
		}

		private void Run_Click(object sender, EventArgs e)
		{
			sema.Wait();
			web.Stop();
		}
	}
}
