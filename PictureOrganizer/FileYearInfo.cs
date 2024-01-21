using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureOrganizer
{
	public class FileYearInfo
	{
		public string Filename { get; set; }

		public string NewFileLocation { get; set; }

		public string OldFileLocation { get; set; }

		public DateTime TimeProcessed { get; set; }

		public DateTime FileCreationDate { get; set; }

		public FileYearInfo(string fileName, string newFileLocation, string oldFileLocation, DateTime timeProcessed,
			DateTime fileCreationDate)
		{
			Filename = fileName;
			NewFileLocation = newFileLocation;
			OldFileLocation = oldFileLocation;
			TimeProcessed = timeProcessed;
			FileCreationDate = fileCreationDate;
		}
	}
}
