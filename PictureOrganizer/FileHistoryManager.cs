using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PictureOrganizer
{
	public partial class FileHistoryManager : Form
	{
		private ContextMenuStrip contextMenu;

		public FileHistoryManager()
		{
			InitializeComponent();
			InitializeTreeView();
		}
		private void InitializeTreeView()
		{
			treeView1.Dock = DockStyle.Fill;
			treeView1.AfterSelect += treeView1_AfterSelect;
			Controls.Add(treeView1);
			CreateContextMenu();
			ReadJsonData();
		}
		private void CreateContextMenu()
		{
			contextMenu = new ContextMenuStrip();
			ToolStripMenuItem reverseMove = new ToolStripMenuItem("Reverse move of files");
			ToolStripMenuItem reverseCopy = new ToolStripMenuItem("Reverse copying of file");
			ToolStripMenuItem openFolder = new ToolStripMenuItem("Open folder");

			reverseMove.Click += new EventHandler(reverseMove_Click);
			reverseCopy.Click += new EventHandler(reverseCopy_Click);
			openFolder.Click += new EventHandler(openFolder_Click);

			contextMenu.Name = "reverseMove";
			contextMenu.Items.Add(reverseMove);
			contextMenu.Items.Add(reverseCopy);
			contextMenu.Items.Add(openFolder);
		}
		private void reverseMove_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Open menu item clicked!");
		}
		private void reverseCopy_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Open menu item clicked!");
		}
		private void openFolder_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			string folder = selectedNode.Tag.ToString();
			OpenFolderInExplorer(folder);

		}
		static void OpenFolderInExplorer(string folder)
		{
			if (Directory.Exists(folder))
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo
				{
					FileName = "explorer.exe",
					Arguments = folder,
					WorkingDirectory = Environment.CurrentDirectory
				};
				Process.Start(processStartInfo);
			}
			else
			{
				MessageBox.Show("Folder doesn't exist.");
			}
		}
		private void ReadJsonData()
		{
			string pictureOrganizerFolder = "PictureOrganizer";
			string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string logFilePath = Path.Combine(appDataFolder, pictureOrganizerFolder, "changeLog.json");

			string jsonContent = File.ReadAllText(logFilePath);
			if (!String.IsNullOrEmpty(jsonContent))
			{
				JToken jsonToken = JToken.Parse(jsonContent);
				JArray jsonArray = (JArray)jsonToken;

				foreach (JObject jsonObject in jsonArray)
				{
					//MASTER NODE 1
					DateTime timeStamp = (DateTime)jsonObject["Timestamp"];
					TimeSpan timeAgo = DateTime.Now - timeStamp;

					TreeNode firstNode = treeView1.Nodes.Add("");
					firstNode.BackColor = Color.Beige;
					firstNode.ContextMenuStrip = contextMenu;

					/*
					Add type of operation i changeLog.json
					Add move operation
					Change the treeview. Maybe use another component overall. Think more about the purpose
					 */
					bool nodeChanged = false;
					JArray changesArray = (JArray)jsonObject["Changes"];
					for (int i = 0; i < changesArray.Count(); i++)
					{
						JObject jObject = (JObject)changesArray[i];
						var fileName = (string)jObject["Filename"];
						var newFileLocation = (string)jObject["NewFileLocation"];
						if (!nodeChanged)
						{
							string[] baseUrl = newFileLocation.Split("PictureOrganizer");
							string[] fileLocation = newFileLocation.Split("\\" + fileName);
							firstNode.Text = "(" +baseUrl[0] + ") " + " (" + timeStamp.ToString() + ") " + " (" + FormatTimeAgo(timeAgo) + ")";
							firstNode.Tag = fileLocation[0];
							nodeChanged = true;
						}

						var oldFileLocation = (string)jObject["OldFileLocation"];
						var timeProcessed = (DateTime)jObject["TimeProcessed"];
						var fileCreationDate = (DateTime)jObject["FileCreationDate"];

						TreeNode secondNode = firstNode.Nodes.Add("New location: " + newFileLocation);

						TreeNode thirdNode = secondNode.Nodes.Add("Filename: " + fileName);
						secondNode.Nodes.Add("Old location: " + oldFileLocation);
						secondNode.Nodes.Add("Time of operation: " + timeProcessed);
						secondNode.Nodes.Add("File created: " + fileCreationDate);
					}
				}
			}

			
		}

		public static string FormatTimeAgo(TimeSpan timeAgo)
		{
			if (timeAgo.TotalSeconds < 60)
			{
				return $"{(int)timeAgo.TotalSeconds} seconds ago";
			}
			else if (timeAgo.TotalMinutes < 60)
			{
				return $"{(int)timeAgo.TotalMinutes} minutes ago";
			}
			else if (timeAgo.TotalHours < 24)
			{
				return $"{(int)timeAgo.TotalHours} hours ago";
			}
			else
			{
				return $"{(int)timeAgo.TotalDays} days ago";
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}

		private void helloToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("SS");
		}
	}

	public class MyTreeNode : TreeNode
	{
		public DateTime Folder { get; set; }

		public MyTreeNode(DateTime folder)
		{
			Folder = folder;
		}
	}
}
