using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PictureOrganizer
{
	public partial class ProgressBar : Form
	{
		private static Stopwatch stopwatch = new Stopwatch();
		private List<FileYearInfo> fileYearList;
		private string folderPath;
		private bool sortByMonth;
		private int progressBarIndex = 0;

		public ProgressBar(List<FileYearInfo> fileYearList, string folderPath, bool sortByMonth)
		{
			InitializeComponent();
			this.fileProcessingProgressBar.Minimum = 0;
			this.fileProcessingProgressBar.Maximum = fileYearList.Count() * 1000;
			this.fileYearList = fileYearList;
			this.folderPath = folderPath;
			this.sortByMonth = sortByMonth;
			stopwatch.Start();

			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

			// Start the background worker
			backgroundWorker1.RunWorkerAsync();
		}
			
		public async Task updateProgressBar(int progressValue)
		{
		}

		private void fileProcessingProgressBar_Click(object sender, EventArgs e)
		{
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			int index = 0;
			foreach (FileYearInfo file in fileYearList)
			{
				if (File.Exists(file.FullFilename))
				{
					using (FileStream fs = File.Open(file.FullFilename, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
					{
						var newFileLocation = "";
						if (!sortByMonth)
						{
							newFileLocation = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + file.FileCreationDate.Year.ToString() + "\\" + file.Filename;
						}
						else
						{
							newFileLocation = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + file.TimeProcessed.Year.ToString() + "\\" + file.FileCreationDate.Month + "\\" + file.Filename;
						}
						file.NewFileLocation = newFileLocation;
						worker.ReportProgress(index);
						File.Copy(file.FullFilename, Path.Combine(folderPath, newFileLocation), true);
						//File.Move(sourcePath, Path.Combine(destinationPath, Path.GetFileName(sourcePath)));
						index++;
						progressBarIndex = index;
					}
				}
			}
		}
		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			fileProcessingProgressBar.Value = e.ProgressPercentage;			
		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			fileProcessingProgressBar.Value = progressBarIndex;
			this.Close();
		}
	}
}
