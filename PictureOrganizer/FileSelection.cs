using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PictureOrganizer
{
	public partial class FileSelection : Form
	{
		private Dictionary<string, bool> fileTypeCheckboxes = new Dictionary<string, bool>();

		public FileSelection(Dictionary<string, bool> fileTypeCheckboxes)
		{
			InitializeComponent();

			foreach (Control control in this.Controls)
			{
				if (control.HasChildren)
				{
					foreach (Control innerControl in control.Controls)
					{
						if (innerControl is System.Windows.Forms.CheckBox checkBox)
						{
							foreach ((string name, bool isChecked) in fileTypeCheckboxes)
							{
								if (name == checkBox.Text)
								{
									checkBox.Checked = isChecked;
								}
							}
						}
					}
				}
			}

			this.FormClosing += FileSelection_FormClosing;

		}

		public Dictionary<string, bool> GetCheckedBoxes()
		{
			return fileTypeCheckboxes;
		}

		private void okButton_Click_1(object sender, EventArgs e)
		{
			saveCheckboxState();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void FileSelection_FormClosing(object sender, FormClosingEventArgs e)
		{
			saveCheckboxState();
			DialogResult = DialogResult.OK;
		}

		private void saveCheckboxState()
		{
			foreach (Control control in this.Controls)
			{
				if (control.HasChildren)
				{
					foreach (Control innerControl in control.Controls)
					{
						if (innerControl is System.Windows.Forms.CheckBox checkBox)
						{
							bool isChecked = checkBox.Checked;
							string checkboxText = checkBox.Text;

							if (!fileTypeCheckboxes.ContainsKey(checkboxText))
							{
								fileTypeCheckboxes.Add(checkboxText, isChecked);
							}
						}
					}
				}
			}
		}


		//Checkbox check changes
		private void textFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (textFilesCheckbox.Checked)
			{
				txtCheckbox.Checked = true;
				csvCheckbox.Checked = true;
			}
			else
			{
				txtCheckbox.Checked = false;
				csvCheckbox.Checked = false;
			}
		}

		private void imageFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (imageFilesCheckbox.Checked)
			{
				jpgCheckbox.Checked = true;
				jpegCheckbox.Checked = true;
				pngCheckbox.Checked = true;
				gifCheckbox.Checked = true;
				bmpCheckbox.Checked = true;
			}
			else
			{
				jpgCheckbox.Checked = false;
				jpegCheckbox.Checked = false;
				pngCheckbox.Checked = false;
				gifCheckbox.Checked = false;
				bmpCheckbox.Checked = false;
			}
		}

		private void documentFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (documentFilesCheckbox.Checked)
			{
				docCheckbox.Checked = true;
				docxCheckbox.Checked = true;
				pdfCheckbox.Checked = true;
			}
			else
			{
				docCheckbox.Checked = false;
				docxCheckbox.Checked = false;
				pdfCheckbox.Checked = false;
			}
		}

		private void spreadsheetFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (spreadsheetFilesCheckbox.Checked)
			{
				xlsCheckbox.Checked = true;
				xlsxCheckbox.Checked = true;
				csvCheckbox2.Checked = true;
			}
			else
			{
				xlsCheckbox.Checked = false;
				xlsxCheckbox.Checked = false;
				csvCheckbox2.Checked = false;
			}
		}

		private void audioFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (audioFilesCheckbox.Checked)
			{
				mp3Checkbox.Checked = true;
				wavCheckbox.Checked = true;
				oggCheckbox.Checked = true;
			}
			else
			{
				mp3Checkbox.Checked = false;
				wavCheckbox.Checked = false;
				oggCheckbox.Checked = false;
			}
		}

		private void videoFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (videoFilesCheckbox.Checked)
			{
				mp4Checkbox.Checked = true;
				aviCheckbox.Checked = true;
				mkvCheckbox.Checked = true;
				movCheckbox.Checked = true;
			}
			else
			{
				mp4Checkbox.Checked = false;
				aviCheckbox.Checked = false;
				mkvCheckbox.Checked = false;
				movCheckbox.Checked = false;
			}
		}

		private void archiveFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (archiveFilesCheckbox.Checked)
			{
				zipCheckbox.Checked = true;
				rarCheckbox.Checked = true;
			}
			else
			{
				zipCheckbox.Checked = false;
				rarCheckbox.Checked = false;
			}
		}

		private void programmingFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (programmingFilesCheckbox.Checked)
			{
				cCheckbox.Checked = true;
				cppCheckbox.Checked = true;
				javaCheckbox.Checked = true;
				pyCheckbox.Checked = true;
			}
			else
			{
				cCheckbox.Checked = false;
				cppCheckbox.Checked = false;
				javaCheckbox.Checked = false;
				pyCheckbox.Checked = false;
			}
		}

		private void databaseFiles_CheckedChanged(object sender, EventArgs e)
		{
			if (databaseFilesCheckbox.Checked)
			{
				dbCheckbox.Checked = true;
				sqliteCheckbox.Checked = true;
				mdbCheckbox.Checked = true;
				accdbCheckbox.Checked = true;
			}
			else
			{
				dbCheckbox.Checked = false;
				sqliteCheckbox.Checked = false;
				mdbCheckbox.Checked = false;
				accdbCheckbox.Checked = false;
			}
		}

		private void webFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (webFilesCheckbox.Checked)
			{
				htmlCheckbox.Checked = true;
				htmCheckbox.Checked = true;
				cssCheckbox.Checked = true;
				jsCheckbox.Checked = true;
			}
			else
			{
				htmlCheckbox.Checked = false;
				htmCheckbox.Checked = false;
				cssCheckbox.Checked = false;
				jsCheckbox.Checked = false;
			}
		}

		private void executableFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (executableFilesCheckbox.Checked)
			{
				exeCheckbox.Checked = true;
				dllCheckbox.Checked = true;
				appCheckbox.Checked = true;
			}
			else
			{
				exeCheckbox.Checked = false;
				dllCheckbox.Checked = false;
				appCheckbox.Checked = false;
			}
		}

		private void configurationFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (configurationFilesCheckbox.Checked)
			{
				iniCheckbox.Checked = true;
				jsonCheckbox.Checked = true;
			}
			else
			{
				iniCheckbox.Checked = false;
				jsonCheckbox.Checked = false;
			}
		}

		private void fontFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (fontFilesCheckbox.Checked)
			{
				ttfCheckbox.Checked = true;
				otfCheckbox.Checked = true;
			}
			else
			{
				ttfCheckbox.Checked = false;
				otfCheckbox.Checked = false;
			}
		}

		private void threeDModelFilesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (threeDModelFilesCheckbox.Checked)
			{
				objCheckbox.Checked = true;
				stlCheckbox.Checked = true;
			}
			else
			{
				objCheckbox.Checked = false;
				stlCheckbox.Checked = false;
			}
		}

		private void checkAllCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			if (checkAllCheckbox.Checked)
			{
				txtCheckbox.Checked = true;
				csvCheckbox.Checked = true;
				jpgCheckbox.Checked = true;
				jpegCheckbox.Checked = true;
				pngCheckbox.Checked = true;
				gifCheckbox.Checked = true;
				bmpCheckbox.Checked = true;
				docCheckbox.Checked = true;
				docxCheckbox.Checked = true;
				pdfCheckbox.Checked = true;
				xlsCheckbox.Checked = true;
				xlsxCheckbox.Checked = true;
				csvCheckbox2.Checked = true;
				mp3Checkbox.Checked = true;
				wavCheckbox.Checked = true;
				oggCheckbox.Checked = true;
				mp4Checkbox.Checked = true;
				aviCheckbox.Checked = true;
				mkvCheckbox.Checked = true;
				movCheckbox.Checked = true;
				zipCheckbox.Checked = true;
				rarCheckbox.Checked = true;
				cCheckbox.Checked = true;
				cppCheckbox.Checked = true;
				javaCheckbox.Checked = true;
				pyCheckbox.Checked = true;
				dbCheckbox.Checked = true;
				sqliteCheckbox.Checked = true;
				mdbCheckbox.Checked = true;
				accdbCheckbox.Checked = true;
				htmlCheckbox.Checked = true;
				htmCheckbox.Checked = true;
				cssCheckbox.Checked = true;
				jsCheckbox.Checked = true;
				exeCheckbox.Checked = true;
				dllCheckbox.Checked = true;
				appCheckbox.Checked = true;
				iniCheckbox.Checked = true;
				jsonCheckbox.Checked = true;
				ttfCheckbox.Checked = true;
				otfCheckbox.Checked = true;
				objCheckbox.Checked = true;
				stlCheckbox.Checked = true;
			}
			else
			{
				txtCheckbox.Checked = false;
				csvCheckbox.Checked = false;
				jpgCheckbox.Checked = false;
				jpegCheckbox.Checked = false;
				pngCheckbox.Checked = false;
				gifCheckbox.Checked = false;
				bmpCheckbox.Checked = false;
				docCheckbox.Checked = false;
				docxCheckbox.Checked = false;
				pdfCheckbox.Checked = false;
				xlsCheckbox.Checked = false;
				xlsxCheckbox.Checked = false;
				csvCheckbox2.Checked = false;
				mp3Checkbox.Checked = false;
				wavCheckbox.Checked = false;
				oggCheckbox.Checked = false;
				mp4Checkbox.Checked = false;
				aviCheckbox.Checked = false;
				mkvCheckbox.Checked = false;
				movCheckbox.Checked = false;
				zipCheckbox.Checked = false;
				rarCheckbox.Checked = false;
				cCheckbox.Checked = false;
				cppCheckbox.Checked = false;
				javaCheckbox.Checked = false;
				pyCheckbox.Checked = false;
				dbCheckbox.Checked = false;
				sqliteCheckbox.Checked = false;
				mdbCheckbox.Checked = false;
				accdbCheckbox.Checked = false;
				htmlCheckbox.Checked = false;
				htmCheckbox.Checked = false;
				cssCheckbox.Checked = false;
				jsCheckbox.Checked = false;
				exeCheckbox.Checked = false;
				dllCheckbox.Checked = false;
				appCheckbox.Checked = false;
				iniCheckbox.Checked = false;
				jsonCheckbox.Checked = false;
				ttfCheckbox.Checked = false;
				otfCheckbox.Checked = false;
				objCheckbox.Checked = false;
				stlCheckbox.Checked = false;
			}
		}
	}

}
