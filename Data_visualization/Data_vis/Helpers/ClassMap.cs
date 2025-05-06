using CsvHelper.Configuration;
using Data_vis.Models;

namespace Data_vis.Helpers;

public class ClassMap : ClassMap<VideoGameSales>
{
	public ClassMap()
	{
		Map(m => m.Rank).Name("Rank").TypeConverterOption.NullValues("N/A");
		Map(m => m.Name).Name("Name").TypeConverterOption.NullValues("N/A");
		Map(m => m.Platform).Name("Platform").TypeConverterOption.NullValues("N/A");
		Map(m => m.Year).Name("Year").TypeConverterOption.NullValues("N/A");
		Map(m => m.Genre).Name("Genre").TypeConverterOption.NullValues("N/A");
		Map(m => m.Publisher).Name("Publisher").TypeConverterOption.NullValues("N/A");
		Map(m => m.NA_Sales).Name("NA_Sales").TypeConverterOption.NullValues("N/A");
		Map(m => m.EU_Sales).Name("EU_Sales").TypeConverterOption.NullValues("N/A");
		Map(m => m.JP_Sales).Name("JP_Sales").TypeConverterOption.NullValues("N/A");
		Map(m => m.Other_Sales).Name("Other_Sales").TypeConverterOption.NullValues("N/A");
		Map(m => m.Global_Sales).Name("Global_Sales").TypeConverterOption.NullValues("N/A");

	}
}
