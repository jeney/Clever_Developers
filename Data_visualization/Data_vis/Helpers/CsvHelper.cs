using System.Collections.Generic;

namespace Data_vis.Helpers;

using System;
using CsvHelper;
using System.IO;
using System.Linq;
using System.Globalization;
using Data_vis.Models;

	public class CsvReaderHelper
	{
		public List<VideoGameSales> ReadCsvFile()
		{
			using (var streamReader = new StreamReader(@"Assets/VideoGamesSales.csv.csv"))
			using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
			{
				csvReader.Context.RegisterClassMap<ClassMap>();
				var records = csvReader.GetRecords<VideoGameSales>().ToList();

				// foreach (var record in records)
				// {
				// 	Console.WriteLine($"{record.Name} - {record.Platform} ({record.Year})");
				// }

				return records;

			}
		}
	}

// reads the csv file
// converts each row into a VideoGameSales instance using ClassMap.cs
