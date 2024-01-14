using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


/*
 TODO
1. Fix the selection of buttons with the arrowkeys -small
2. zoom in and out of the picture with the up and down arrows -small

Show pictures in subfolders flag -small
Copy / move flag -small
Open gui and select which folders to configure -big
Save old file location -big
Organize code - medium
add window telling you how much space the file take up when copying - small



DESIGN CHANGES
5. fix filename layout -medium
6. Make buttons change location when resizing window -small



DONE__________________
3. Add button and folder to loop through everything. Input folder and output folder -DONE
4. Copy all the files to folders organized in years / months -DONE
7. fixa checkboxes
configure which type of file to copy/move -DONE
Add progressbar -medium - DONE -was small
 */

namespace PictureOrganizer
{
	public partial class Form1 : Form
	{
		private string[] imageFiles;
		private int currentImageIndex = 0;
		private string selectedOutputFolder;
		private string selectedInputFolder;
		private Dictionary<string, bool> fileTypeCheckboxes;

		public Form1()
		{
			InitializeComponent();
			this.Size = new System.Drawing.Size(2100, 1200);
			KeyPreview = true;
			KeyDown += Form_KeyDown;


			fileTypeCheckboxes = new Dictionary<string, bool>
			{
				// Text Files
				{ "Text files:", false },
				{ ".txt", false },
				{ ".csv", false },

				// Document Files
				{ ".doc", false },
				{ ".docx", false },
				{ ".pdf", false },

				// Spreadsheet Files
				{ ".xls", false },
				{ ".xlsx", false },

				// Presentation Files
				{ ".ppt", false },
				{ ".pptx", false },

				// Image Files
				{ "Image Files:", false },
				{ ".jpg", true },
				{ ".jpeg", true },
				{ ".png", true },
				{ ".gif", true },
				{ ".bmp", true },

				// Audio Files
				{ ".mp3", false },
				{ ".wav", false },
				{ ".ogg", false },

				// Video Files
				{ ".mp4", false },
				{ ".avi", false },
				{ ".mkv", false },
				{ ".mov", false },

				// Archive Files
				{ ".zip", false },
				{ ".rar", false },

				// Programming Files
				{ ".c", false },
				{ ".cpp", false },
				{ ".java", false },
				{ ".py", false },

				// Database Files
				{ ".db", false },
				{ ".sqlite", false },
				{ ".mdb", false },
				{ ".accdb", false },

				// Web Files
				{ ".html", false },
				{ ".htm", false },
				{ ".css", false },
				{ ".js", false },

				// Executable Files
				{ ".exe", false },
				{ ".dll", false },
				{ ".app", false },

				// Configuration Files
				{ ".ini", false },
				{ ".json", false },

				// Font Files
				{ ".ttf", false },
				{ ".otf", false },

				// 3D Model Files
				{ ".obj", false },
				{ ".stl", false },
			};

		}

		private void openFolder_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				string selectedFolder = folderBrowserDialog1.SelectedPath;

				string[] allowedExtensions = fileTypeCheckboxes
				.Where(pair => pair.Value)
				.Select(pair => pair.Key)
				.Where(extension => extension.StartsWith("."))
				.ToArray();

				imageFiles = Directory.GetFiles(selectedFolder)
									   .Where(file => allowedExtensions.Any(ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
									   .ToArray();

				if (imageFiles.Length > 0)
				{
					LoadImage(currentImageIndex);
					pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
				}
				else
				{
					MessageBox.Show("No images found in the selected folder.");
				}
			}
		}

		private void skipRight_Click(object sender, EventArgs e)
		{
			renamingBox.Text = "";

			if (currentImageIndex + 1 < imageFiles.Length)
			{
				currentImageIndex++;
				LoadImage(currentImageIndex);
			}
			else
			{
				MessageBox.Show("No more images in the folder.");
			}
		}

		private void LoadImage(int index)
		{
			try
			{
				if (pictureBox1.Image!=null)
				{
					var img = pictureBox1.Image;
					pictureBox1.Image = null;
					img.Dispose();
				}
				fileName.Text = imageFiles[index];
				pictureBox1.Image = Image.FromFile(imageFiles[index]);
			}
			catch (System.OutOfMemoryException ex)
			{
				pictureBox1.Refresh();

			}


		}

		private void skipLeft_Click_1(object sender, EventArgs e)
		{
			renamingBox.Text = "";

			if (currentImageIndex - 1 > -1)
			{
				currentImageIndex--;
				LoadImage(currentImageIndex);
			}
			else
			{
				MessageBox.Show("No more images in the folder.");
			}
		}

		private void rename_Click(object sender, EventArgs e)
		{
			string newFileName = renamingBox.Text;

			if (pictureBox1.Image != null && !string.IsNullOrWhiteSpace(newFileName))
			{
				string currentFilePath = imageFiles[currentImageIndex];

				// Rename the file
				if (File.Exists(currentFilePath))
				{
					string directory = Path.GetDirectoryName(currentFilePath);
					string fileExtension = Path.GetExtension(currentFilePath);

					string newFilePath = Path.Combine(directory, newFileName + fileExtension);


					// Optionally, update the image in PictureBox after renaming
					pictureBox1.Image.Dispose(); // Dispose the existing image
					pictureBox1.Image = null;

					File.Move(currentFilePath, newFilePath);


					// Load the newly renamed image (assuming 'newFilePath' contains the path to the renamed file)
					pictureBox1.Image = Image.FromFile(newFilePath);
				}
				else
				{
					MessageBox.Show("The file doesn't exist or the path is incorrect.");
				}
			}
			else
			{
				MessageBox.Show("No image is currently displayed or the new file name is empty.");
			}
		}
		private void Form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right)
			{
				skipRight.PerformClick();
			}
			if (e.KeyCode == Keys.Left)
			{
				skipLeft.PerformClick();
			}
			if (e.KeyCode == Keys.Enter)
			{
				// Call your function here
				rename.PerformClick();
				skipRight.PerformClick();

			}
		}

		private void inputFolder_Click(object sender, EventArgs e)
		{
			if (inputFolderDialog.ShowDialog() == DialogResult.OK)
			{
				selectedInputFolder = inputFolderDialog.SelectedPath;

				string[] allowedExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif" };
				imageFiles = Directory.GetFiles(selectedInputFolder)
									   .Where(file => allowedExtensions.Any(ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
									   .ToArray();

				inputFolderLabel.Text = selectedInputFolder;




			}
		}

		private void outputFolder_Click(object sender, EventArgs e)
		{
			if (inputFolderDialog.ShowDialog() == DialogResult.OK)
			{
				selectedOutputFolder = inputFolderDialog.SelectedPath;

				outputFolderLabel.Text = selectedOutputFolder;


			}
		}

		private void sortYear_Click(object sender, EventArgs e)
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
						LoopFoldersAndFiles(directoryInfo, ref fileYearList, ref uniqueYears, false);

						//Create directories by year
						CreateDirectoriesByYear(folderPath, fileYearList);

						ProgressBar progressBar = new ProgressBar(fileYearList, folderPath);
						progressBar.Show();

						int index = 0;

						/*
						foreach (FileYearInfo file in fileYearList)
						{
							if (File.Exists(file.FullFilename))
							{
								using (FileStream fs = File.Open(file.FullFilename, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
								{
									var newFileLocation = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + file.Year.ToString() + "\\" + file.Filename;

									progressBar.updateProgressBar(index);

									File.Copy(file.FullFilename, Path.Combine(folderPath, newFileLocation), true);
									//File.Move(sourcePath, Path.Combine(destinationPath, Path.GetFileName(sourcePath)));
									index++;
								}
							}
						}
						*/
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

		private void sortMonth_Click(object sender, EventArgs e)
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
						LoopFoldersAndFiles(directoryInfo, ref fileYearList, ref uniqueYears, true);

						//Create directories by year
						CreateDirectoriesByYearAndMonths(folderPath, fileYearList);

						foreach (FileYearInfo file in fileYearList)
						{
							string month = file.YearMonth.Split("-")[1];
							var newFileLocation = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + file.Year.ToString() + "\\" + month + "\\" + file.Filename;

							File.Copy(file.FullFilename, newFileLocation, true);
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

		private void CreateDirectoriesByYear(string folderPath, List<FileYearInfo> fileYearList)
		{
			//Create directories by year
			DirectoryInfo yearGroupDirectory = new DirectoryInfo(folderPath + "\\PictureOrganizer" + "\\Years");
			if (!yearGroupDirectory.Exists)
			{
				Directory.CreateDirectory(folderPath + "\\PictureOrganizer" + "\\Years");
			}

			var uniqueYears = fileYearList.Select(info => info.Year).Distinct().ToList();
			var uniqueMonths = fileYearList.Select(info => info.YearMonth).Distinct().ToList();

			foreach (int years in uniqueYears)
			{
				string individualYearString = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + years.ToString();

				DirectoryInfo yearDirectory = new DirectoryInfo(individualYearString);
				if (!yearDirectory.Exists)
				{
					Directory.CreateDirectory(individualYearString);
				}
			}
		}

		private void CreateDirectoriesByYearAndMonths(string folderPath, List<FileYearInfo> fileYearList)
		{
			//Create directories by year
			DirectoryInfo yearGroupDirectory = new DirectoryInfo(folderPath + "\\PictureOrganizer" + "\\Years");
			if (!yearGroupDirectory.Exists)
			{
				Directory.CreateDirectory(folderPath + "\\PictureOrganizer" + "\\Years");
			}

			var uniqueMonths = fileYearList.Select(info => info.YearMonth).Distinct().ToList();

			foreach (string years in uniqueMonths)
			{
				string[] yearsAndMonthsSplit = years.Split('-');

				string year = yearsAndMonthsSplit[0];
				string month = yearsAndMonthsSplit[1];

				string individualYearString = folderPath + "\\PictureOrganizer" + "\\Years" + "\\" + year + "\\" + month;

				DirectoryInfo yearDirectory = new DirectoryInfo(individualYearString);
				if (!yearDirectory.Exists)
				{
					Directory.CreateDirectory(individualYearString);
				}
			}
		}

		private void LoopFoldersAndFiles(DirectoryInfo directoryInfo, ref List<FileYearInfo> fileYearList, ref HashSet<int> uniqueYears, bool sortByMonth)
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

				if (sortByMonth)
				{
					fileYearList.Add(new FileYearInfo(fileInfo.CreationTime.Year, fileInfo.CreationTime.Year.ToString() + "-" + GetMonthName(fileInfo.CreationTime.Month), fileInfo.FullName, fileInfo.Name));
				}
				else
				{
					fileYearList.Add(new FileYearInfo(fileInfo.CreationTime.Year, fileInfo.FullName, fileInfo.Name));
				}
				uniqueYears.Add(fileInfo.CreationTime.Year);
			}
			double sumMB = allFilesSizeMB.Sum();
			double sumGB = sumMB / 1024.0;
			double roundedValue = Math.Round(sumGB, 2);
			//MessageBox.Show("The files of all these files are " + sumMB.ToString() + " MB\n or " + roundedValue.ToString() + " GB");
		}

		static void EnumerateFolders(string folderPath, List<string> allFiles)
		{
			try
			{
				foreach (string directory in Directory.EnumerateDirectories(folderPath))
				{
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(directory);
						if ((directoryInfo.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
						{
							allFiles.AddRange(Directory.GetFiles(directory, "*.*"));

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

		static string GetMonthName(int monthNumber)
		{
			if (monthNumber < 1 || monthNumber > 12)
			{
				// Handle invalid month numbers (1-12 are valid)
				throw new ArgumentOutOfRangeException(nameof(monthNumber), "Month number should be between 1 and 12.");
			}

			// Use CultureInfo to get the month names
			CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			DateTimeFormatInfo dateTimeFormat = cultureInfo.DateTimeFormat;

			// Return the month name corresponding to the monthNumber
			return dateTimeFormat.GetMonthName(monthNumber);
		}

		private void fileSelection_Click(object sender, EventArgs e)
		{
			using (FileSelection fileSelection = new FileSelection(fileTypeCheckboxes))
			{
				DialogResult result = fileSelection.ShowDialog();

				if (result == DialogResult.OK)
				{
					fileTypeCheckboxes = fileSelection.GetCheckedBoxes();
					var hej = "";
				}
			}
		}
	}

	public class FileYearInfo
	{
		public int Year { get; set; }

		public string YearMonth { get; set; }
		public string FullFilename { get; set; }

		public string Filename { get; set; }

		public FileYearInfo(int year, string fullFilename, string filename)
		{
			Year = year;
			FullFilename = fullFilename;
			Filename = filename;
		}
		public FileYearInfo(int year, string yearMonth, string fullFilename, string filename)
		{
			Year = year;
			FullFilename = fullFilename;
			Filename = filename;
			YearMonth = yearMonth;
		}
	}

}