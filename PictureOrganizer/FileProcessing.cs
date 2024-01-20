using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PictureOrganizer.Helper;


namespace PictureOrganizer
{
	internal class FileProcessing
	{
		private string selectedInputFolder;
		private string selectedOutputFolder;
		private static bool LoopSubFolders;
		private static Dictionary<string, bool> FileTypeCheckboxes;

		public FileProcessing(string selectedInputFolder, string selectedOutputFolder, Dictionary<string, bool> fileTypeCheckboxes, bool loopSubFolders)
		{
			this.selectedInputFolder=selectedInputFolder;
			this.selectedOutputFolder=selectedOutputFolder;
			FileTypeCheckboxes = fileTypeCheckboxes;
			LoopSubFolders = loopSubFolders;

		}

		public void sortFiles(bool sortByMonth)
		{
			try
			{
				if (!String.IsNullOrEmpty(selectedInputFolder))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(selectedInputFolder);
					string folderPath = selectedOutputFolder;

					HashSet<int> uniqueYears = new HashSet<int>();
					List<FileYearInfo> fileYearList = new List<FileYearInfo>();

					if (directoryInfo.Exists)
					{
						bool sortFiles = LoopFoldersAndFiles(directoryInfo, ref fileYearList, ref uniqueYears, sortByMonth);
						//Create directories by year
						if (sortFiles)
						{
							CreateDirectories(folderPath, fileYearList, sortByMonth);
							ProgressBar progressBar = new ProgressBar(fileYearList, folderPath, sortByMonth);
							progressBar.Show();
						}	
					}
				}
				else
				{
					MessageBox.Show("You need to set input folder");
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}
		private void CreateDirectories(string folderPath, List<FileYearInfo> fileYearList, bool sortByMonth)
		{
			//Create directories by year
			DirectoryInfo yearGroupDirectory = new DirectoryInfo(folderPath + "\\PictureOrganizer" + "\\Years");
			if (!yearGroupDirectory.Exists)
			{
				Directory.CreateDirectory(folderPath + "\\PictureOrganizer" + "\\Years");
			}

			var uniqueYearMonths = fileYearList
			.Select(info => new { Year = info.FileCreationDate.Year, Month = info.FileCreationDate.Month })
			.Distinct()
			.ToList();

			if (!sortByMonth)
			{

				foreach (var yearMonth in uniqueYearMonths)
				{
					string individualYearString = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + yearMonth.Year.ToString();
					DirectoryInfo yearDirectory = new DirectoryInfo(individualYearString);
					if (!yearDirectory.Exists)
					{
						Directory.CreateDirectory(individualYearString);
					}
					//AddNewFileLocation(ref fileYearList);
				}
			}
			else
			{
				foreach (var yearMonth in uniqueYearMonths)
				{
					string individualYearString = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + yearMonth.Year + "\\" + yearMonth.Month;
					DirectoryInfo yearDirectory = new DirectoryInfo(individualYearString);
					if (!yearDirectory.Exists)
					{
						Directory.CreateDirectory(individualYearString);
					}
				}
			}

		}
		public bool LoopFoldersAndFiles(DirectoryInfo directoryInfo, ref List<FileYearInfo> fileYearList, ref HashSet<int> uniqueYears, bool sortByMonth)
		{

			FileInfo[] files = directoryInfo.GetFiles();
			//Loopa igenom alla mappar i en mapp
			List<string> allFiles = new List<string>();
			EnumerateFolders(directoryInfo.FullName, allFiles);
			List<double> allFilesSizeMB = new List<double>();

			foreach (string filePath in allFiles)
			{
				FileInfo fileInfo = new FileInfo(filePath);
				// Get the size of the file in bytes	
				long fileSizeInBytes = fileInfo.Length;
				// Convert bytes to kilobytes
				double fileSizeInKb = fileSizeInBytes / 1024.0;
				// Convert bytes to megabytes
				double fileSizeInMb = fileSizeInKb / 1024.0;

				allFilesSizeMB.Add(fileSizeInMb);

				DateTime currentTime = DateTime.Now;
				string oldFileLocation = fileInfo.FullName.ToString();

				fileYearList.Add(
						new FileYearInfo(
							fileInfo.Name,
							fileInfo.FullName,
							null, //newFileLocation, 
							oldFileLocation,
							currentTime,
							fileInfo.CreationTime
							));

			}
			double sumMB = allFilesSizeMB.Sum();
			double sumGB = sumMB / 1024.0;
			double roundedValueMB = Math.Round(sumMB, 2);
			double roundedValueGB = Math.Round(sumGB, 2);

			DialogResult result = MessageBox.Show("" +
				"Number of files: " + fileYearList.Count() + "\n" +
				"Size in MB: " + roundedValueMB.ToString() + " MB\n" +
				"Size in GB: " + roundedValueGB.ToString() + " GB\n" +
				"Press OK to continue sorting, press cancel to cancel", "Title", MessageBoxButtons.OKCancel);
			
			if (result == DialogResult.OK)
				return true;
			else
				return false;
		}

		public string AddNewFileLocation(ref List<FileYearInfo> fileYearList)
		{
			foreach (FileYearInfo fileInfo in fileYearList)
			{

				fileInfo.NewFileLocation = fileInfo.Filename;
			}

			return "";
		}
		static void EnumerateFolders(string folderPath, List<string> allFiles)
		{
			string[] allowedExtensions = getAllowedFileExtensions(FileTypeCheckboxes);
			try
			{
				string[] filesInFolder = Directory.GetFiles(folderPath, "*.*")
					.Where(file => allowedExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
					.ToArray();
				allFiles.AddRange(filesInFolder);
			}
			catch (UnauthorizedAccessException ex)
			{
				Console.WriteLine($"Access denied: {ex.Message}");
			}


			if(LoopSubFolders)
			{
				try
				{
					var hej = Directory.EnumerateDirectories(folderPath);
					foreach (string directory in Directory.EnumerateDirectories(folderPath))
					{
						try
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(directory);
							if ((directoryInfo.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
							{

								string[] files = Directory.GetFiles(directory, "*.*")
								.Where(file => allowedExtensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
								.ToArray();
								allFiles.AddRange(files);

								EnumerateFolders(directory, allFiles);
							}
						}
						catch (UnauthorizedAccessException ex)
						{
						}
					}
				}
				catch (UnauthorizedAccessException ex)
				{
					Console.WriteLine($"Access denied: {ex.Message}");
				}
			}
			
		}
	}
}
