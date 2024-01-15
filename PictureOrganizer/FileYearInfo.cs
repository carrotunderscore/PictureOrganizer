using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureOrganizer
{
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
