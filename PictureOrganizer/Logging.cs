using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PictureOrganizer
{
	static class Logging
	{
		public static bool CreateLogFile()
		{
			string appDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string appFolder = Path.Combine(appDataRoamingPath, "PictureOrganizer");
			Directory.CreateDirectory(appFolder);
			string jsonFilePath = Path.Combine(appFolder, "changeLog.json");
			if (!File.Exists(jsonFilePath))
			{
				File.WriteAllText(jsonFilePath, "[]");
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckLogFileExists() {
			return true;
		}	

		public static void WriteToLogFile(List<FileYearInfo> fileYearInfo)
		{
			try
			{
				string pictureOrganizerFolder = "PictureOrganizer";
				string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string logFilePath = Path.Combine(appDataFolder, pictureOrganizerFolder, "changeLog.json");

				JArray existingData = new JArray();
				if (File.Exists(logFilePath))
				{
					string existingJson = File.ReadAllText(logFilePath);
					if (String.IsNullOrEmpty(existingJson))
					{
						File.WriteAllText(logFilePath, "[]");
					}
					existingData = JArray.Parse(existingJson);
				}

				JObject newEntry = new JObject(
					new JProperty("Timestamp", DateTime.Now),
					new JProperty("Changes", JArray.FromObject(fileYearInfo))
				);

				existingData.Add(newEntry);
				File.WriteAllText(logFilePath, existingData.ToString(Newtonsoft.Json.Formatting.Indented));
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
			
		}
		public class ChangeLogEntry
		{
			public DateTime Timestamp { get; set; }
			public List<FileYearInfo>? Changes { get; set; }
		}
	}
}
