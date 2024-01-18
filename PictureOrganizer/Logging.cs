using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureOrganizer
{
	static class Logging
	{

		public static bool CreateLogFile()
		{
			string appDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string appFolder = Path.Combine(appDataRoamingPath, "PictureOrganizer");
			Directory.CreateDirectory(appFolder);
			string jsonFilePath = Path.Combine(appFolder, "settings.json");
			if (!File.Exists(jsonFilePath))
			{
				File.WriteAllText(jsonFilePath, "");
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

		public static bool WriteToLogFile()
		{
			return false;
		}
	}
}
