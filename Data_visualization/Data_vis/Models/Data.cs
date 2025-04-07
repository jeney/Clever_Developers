using System;
using CsvHelper.Configuration.Attributes;

namespace Data_vis.Models
{
	public class VideoGameSales
	{
		public string? Rank { get; set; }
		public string? Name { get; set; }
		public string? Platform { get; set; }
		public int? Year { get; set; }
		public string? Genre { get; set; }
		public string? Publisher { get; set; }
		public float? NA_Sales { get; set; }
		public float? EU_Sales { get; set; }
		public float? JP_Sales { get; set; }
		public float? Other_Sales { get; set; }
		public float? Global_Sales { get; set; }
	}
}
