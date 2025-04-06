using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LINQ;

public class Queries
{
	public List<Data> Datas { get; set; } = CsvReader.ReadCsv("vgsales.csv");
	public List<PieChartData> PieChart1() //total sales per year
	{
		List<PieChartData> Slices = new List<PieChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Year)
			.Select(g => new
			{
				Year = g.Key,
				TotalSales = g.Sum(p => p.Global_Sales)
			})
			.OrderByDescending(g => g.TotalSales)
			.Take(6);
		foreach (var group in groupedDataset)
		{
			PieChartData singleSlice = new PieChartData(group.TotalSales, group.Year.ToString());
			Slices.Add(singleSlice);
		}
		return Slices;
	}
	public List<PieChartData> PieChart2() //total sales per genre
	{
		List<PieChartData> Slices = new List<PieChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Genre)
			.Select(g => new
			{
				Genre = g.Key,
				TotalSales = g.Sum(p => p.Global_Sales)
			})
			.OrderByDescending(g => g.TotalSales)
			.Take(6);
		foreach (var group in groupedDataset)
		{
			PieChartData singleSlice = new PieChartData(group.TotalSales, group.Genre);
			Slices.Add(singleSlice);
		}
		return Slices;
	}

	public List<PieChartData> PieChart3() //total sales per platform
	{
		List<PieChartData> Slices = new List<PieChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Platform)
			.Select(g => new
			{
				Platform = g.Key,
				TotalSales = g.Sum(p => p.Global_Sales)
			})
			.OrderByDescending(g => g.TotalSales)
			.Take(6);
		foreach (var group in groupedDataset)
		{
			PieChartData singleSlice = new PieChartData(group.TotalSales, group.Platform);
			Slices.Add(singleSlice);
		}
		return Slices;
	}

	public List<PieChartData> PieChart4() //number of games per publisher
	{
		List<PieChartData> Slices = new List<PieChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Publisher)
			.Select(g => new
			{
				Publisher = g.Key,
				GameCount = g.Count()
			})
			.OrderByDescending(g => g.GameCount)
			.Take(6);
		foreach (var group in groupedDataset)
		{
			PieChartData singleSlice = new PieChartData(group.GameCount, group.Publisher);
			Slices.Add(singleSlice);
		}
		return Slices;
	}

	public List<PieChartData> PieChart5() //number of games per platform
	{
		List<PieChartData> Slices = new List<PieChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Platform)
			.Select(g => new
			{
				Platform = g.Key,
				GameCount = g.Count()
			})
			.OrderByDescending(g => g.GameCount)
			.Take(6);
		foreach (var group in groupedDataset)
		{
			PieChartData singleSlice = new PieChartData(group.GameCount, group.Platform);
			Slices.Add(singleSlice);
		}
		return Slices;
	}
	public List<BarChartData> BarChart1() //number of games per year
	{
		List<BarChartData> Points = new List<BarChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Year)
			.Select(g => new
			{
				Year = g.Key,
				GameCount = g.Count()
			})
			.OrderBy(g => g.Year);
		foreach (var group in groupedDataset)
		{
			BarChartData singlePoint = new BarChartData(group.GameCount, group.Year.ToString());
			Points.Add(singlePoint);
		}
		return Points;
	}

	public List<BarChartData> BarChart2() //total sales per genre
	{
		List<BarChartData> Points = new List<BarChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Genre)
			.Select(g => new
			{
				Genre = g.Key,
				TotalSales = g.Sum(p => p.Global_Sales)
			})
			.OrderBy(g => g.Genre);
		foreach (var group in groupedDataset)
		{
			BarChartData singlePoint = new BarChartData(group.TotalSales, group.Genre.ToString());
			Points.Add(singlePoint);
		}
		return Points;
	}

	public List<BarChartData> BarChart3() //average sales per genre
	{
		List<BarChartData> Points = new List<BarChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Genre)
			.Select(g => new
			{
				Genre = g.Key,
				AverageSales = g.Average(p => p.Global_Sales)
			})
			.OrderBy(g => g.Genre);
		foreach (var group in groupedDataset)
		{
			BarChartData singlePoint = new BarChartData(group.AverageSales, group.Genre.ToString());
			Points.Add(singlePoint);
		}
		return Points;
	}
	public List<BarChartData> BarChart4() //number of games per publisher
	{
		List<BarChartData> Points = new List<BarChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Publisher)
			.Select(g => new
			{
				Publisher = g.Key,
				GameCount = g.Count()
			})
			.OrderBy(g => g.Publisher);
		foreach (var group in groupedDataset)
		{
			BarChartData singlePoint = new BarChartData(group.GameCount, group.Publisher);
			Points.Add(singlePoint);
		}
		return Points;
	}

	public List<BarChartData> BarChart5() //total sales per year
	{
		List<BarChartData> Points = new List<BarChartData>();
		var groupedDataset = Datas
			.GroupBy(p => p.Year)
			.Select(g => new
			{
				Year = g.Key,
				TotalSales = g.Sum(p => p.Global_Sales)
			})
			.OrderBy(g => g.Year);
		foreach (var group in groupedDataset)
		{
			BarChartData singlePoint = new BarChartData(group.TotalSales, group.Year.ToString());
			Points.Add(singlePoint);
		}
		return Points;
	}
}
