using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static PictureOrganizer.FileYearInfo;
using static PictureOrganizer.FileProcessing;
using static PictureOrganizer.Helper;


/*
 TODO
1. Fix the selection of buttons with the arrowkeys -small
2. zoom in and out of the picture with the up and down arrows -small

Copy / move flag -small
Move operation - small
Open gui and select which folders to configure -big


_____________________________________________________________________________________________________
																									|
create reverse process functionality - big
	Create form with a list of processes that has run -DONE
	Click on each to reverse -must move first-
	If files been copied then delete the copied files
	if they've been moved then move them back
																									|
-----------------------------------------------------------------------------------------------------
	
TODO:::::::::::

TODO:::::::::::

DESIGN CHANGES
5. fix filename layout -medium
6. Make buttons change location when resizing window -small

DONE__________________
3. Add button and folder to loop through everything. Input folder and output folder -DONE
4. Copy all the files to folders organized in years / months -DONE
7. fixa checkboxes
configure which type of file to copy/move -DONE
Add progressbar -medium - DONE -was small
Organize code - medium - was medium
add window telling you how much space the file take up when copying - small - was small
loop pictures in subfolders flag -small
file history. Save files previous history so that you can move them and then reverse it if you want.-big -was big

 */

namespace PictureOrganizer
{
	public partial class Form1 : Form
	{
		private string[] imageFiles;
		private int currentImageIndex = 0;
		private string selectedOutputFolder;
		private string selectedInputFolder;
		private static Dictionary<string, bool> fileTypeCheckboxes;
		private FileProcessing fileProcessing;
		private bool loopSubFolders = false;
		private bool moveFiles = false;

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
			Logging.CreateLogFile();
		}

		//EVENT HANDLERS
		private void openFolder_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				string selectedFolder = folderBrowserDialog1.SelectedPath;

				string[] allowedExtensions = getAllowedFileExtensions(fileTypeCheckboxes);

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
			FileProcessing fileProcessing = new FileProcessing(selectedInputFolder, selectedOutputFolder, fileTypeCheckboxes, loopSubFolders, moveFiles);
			fileProcessing.sortFiles(false);
		}
		private void sortMonth_Click(object sender, EventArgs e)
		{
			FileProcessing fileProcessing = new FileProcessing(selectedInputFolder, selectedOutputFolder, fileTypeCheckboxes, loopSubFolders, moveFiles);
			fileProcessing.sortFiles(true);
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
		private void loopSubFolders_CheckedChanged(object sender, EventArgs e)
		{
			if (loopSubfoldersCheckbox.Checked == true)
			{
				loopSubFolders = true;
			}
			else
			{
				loopSubFolders = false;
			}
		}

		//FILEPROCESSING
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
				MessageBox.Show(ex.Message);
			}
		}

		private void fileHistoryManagerButton_Click(object sender, EventArgs e)
		{
			// Create an instance of SecondForm
			FileHistoryManager fileHistoryManager = new FileHistoryManager();

			// Show the SecondForm
			fileHistoryManager.Show();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void moveFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (moveFilesCheckbox.Checked == true)
			{
				moveFiles = true;
			}
			else
			{
				moveFiles = false;
			}
		}
	}



}