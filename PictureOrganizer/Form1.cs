using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


/*
 TODO
1. Fix the selection of buttons with the arrowkeys
2. zoom in and out of the picture with the up and down arrows
3. Add button and folder to loop through everything. Input folder and output folder --CURRENT----------------

4. Copy all the files to folders organized in years / months 
5. fix filename layout
 */

namespace PictureOrganizer
{
	public partial class Form1 : Form
	{

		private string[] imageFiles;
		private int currentImageIndex = 0;
		private string selectedOutputFolder;

		public Form1()
		{
			InitializeComponent();
			this.Size = new System.Drawing.Size(2100, 1200);
			KeyPreview = true;
			KeyDown += Form_KeyDown;
			skipRight.TabStop = false; // Replace button1 with the name of your button

		}

		private void openFolder_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				string selectedFolder = folderBrowserDialog1.SelectedPath;

				string[] allowedExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif" };
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
				string selectedFolder = inputFolderDialog.SelectedPath;

				string[] allowedExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif" };
				imageFiles = Directory.GetFiles(selectedFolder)
									   .Where(file => allowedExtensions.Any(ext => ext.Equals(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase)))
									   .ToArray();

				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(selectedFolder);

					if (directoryInfo.Exists)
					{
						FileInfo[] files = directoryInfo.GetFiles();

						foreach (FileInfo fileInfo in files)
						{
							Console.WriteLine($"File Name: {fileInfo.Name}");
							Console.WriteLine($"Full Path: {fileInfo.FullName}");
							Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
							Console.WriteLine($"Last Access Time: {fileInfo.LastAccessTime}");
							Console.WriteLine($"Last Write Time: {fileInfo.LastWriteTime}");
							Console.WriteLine($"File Size: {fileInfo.Length} bytes");
							Console.WriteLine();
						}
					}
					else
					{
						Console.WriteLine("Folder does not exist.");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred: {ex.Message}");
				}

			}
		}

		private void outputFolder_Click(object sender, EventArgs e)
		{
			if (inputFolderDialog.ShowDialog() == DialogResult.OK)
			{
				selectedOutputFolder = inputFolderDialog.SelectedPath;

				

			}
		}
	}
}