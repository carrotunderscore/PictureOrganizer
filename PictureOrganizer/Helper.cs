using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureOrganizer
{
	public static class Helper
	{
		public static string GetMonthName(int monthNumber)
		{
			if (monthNumber < 1 || monthNumber > 12)
			{
				throw new ArgumentOutOfRangeException(nameof(monthNumber), "Month number should be between 1 and 12.");
			}

			CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			DateTimeFormatInfo dateTimeFormat = cultureInfo.DateTimeFormat;

			return dateTimeFormat.GetMonthName(monthNumber);
		}
		public static string[] getAllowedFileExtensions(Dictionary<string, bool> fileTypeCheckboxes)
		{
			string[] allowedExtensions = fileTypeCheckboxes
				.Where(pair => pair.Value)
				.Select(pair => pair.Key)
				.Where(extension => extension.StartsWith("."))
				.ToArray();
			return allowedExtensions;
		}
	}
}
