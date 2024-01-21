using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace PictureOrganizer
{
	public partial class FileHistoryManager : Form
	{
		private TreeView treeView; // Change the type from System.Windows.Forms.TreeView to TreeView

		public FileHistoryManager()
		{
			InitializeComponent();
			InitializeTreeView(); // Change the method name to InitializeTreeView
		}
		private void InitializeTreeView()
		{
			treeView = new TreeView(); // Change the type from System.Windows.Forms.TreeView to TreeView

			// Set properties for the TreeView
			treeView.Dock = DockStyle.Fill; // Fill the entire form
			treeView.AfterSelect += treeView1_AfterSelect; // Subscribe to the AfterSelect event

			// Add the TreeView to the form's Controls collection
			Controls.Add(treeView);



			ReadJsonData();

		}

		private void PopulateTreeView()
		{

		}

		private string ReadJsonData()
		{
			string pictureOrganizerFolder = "PictureOrganizer";
			string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string logFilePath = Path.Combine(appDataFolder, pictureOrganizerFolder, "changeLog.json");

			string jsonContent = File.ReadAllText(logFilePath);

			JToken jsonToken = JToken.Parse(jsonContent);

			
			JArray jsonArray = (JArray)jsonToken;
			List<string> timeStampList = new List<string>();

			foreach (JObject jsonObject in jsonArray)
			{
				//MASTER NODE 1
				DateTime timeStamp = (DateTime)jsonObject["Timestamp"];
				TreeNode firstNode = treeView1.Nodes.Add(timeStamp.ToString());





				/*
				Add type of operation i changeLog.json
				Change the treeview. Maybe use another component overall. Think more about the purpose

				 */

				JArray changesArray = (JArray)jsonObject["Changes"];
				for (int i = 0; i < changesArray.Count(); i++)
				{
					JObject jObject = (JObject)changesArray[i];
					var fileName = (string)jObject["Filename"];
					var newFileLocation = (string)jObject["NewFileLocation"];

					var oldFileLocation = (string)jObject["OldFileLocation"];
					var timeProcessed = (DateTime)jObject["TimeProcessed"];
					var fileCreationDate = (DateTime)jObject["FileCreationDate"];

					TreeNode secondNode = firstNode.Nodes.Add("Filename: " + fileName);
					TreeNode thirdNode = secondNode.Nodes.Add("New location: " + newFileLocation);

					secondNode.Nodes.Add("Old location: " + oldFileLocation);
					secondNode.Nodes.Add("Time of operation: " + timeProcessed);
					secondNode.Nodes.Add("File created: " + fileCreationDate);

				}


			}
			


			return "";
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}
	}
}
