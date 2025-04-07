using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.VisualElements;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Data_vis.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
	[ObservableProperty]
	private ObservableCollection<string> items;

	[ObservableProperty]
	private string selectFilter;

	[ObservableProperty]
	private string fromFilter;

	[ObservableProperty]
	private string whereFilter;

	[ObservableProperty]
	private ObservableCollection<string> selectFilterOptions;

	[ObservableProperty]
	private ObservableCollection<string> fromFilterOptions;

	[ObservableProperty]
	private ObservableCollection<string> whereFilterOptions;

	[ObservableProperty]
	private bool isPieChartVisible = true;

	[ObservableProperty]
	private bool isCartesianChartVisible = true;

	public MainWindowViewModel()
	{
		selectFilter = string.Empty;
		fromFilter = string.Empty;
		whereFilter = string.Empty;

		items = new ObservableCollection<string>
		{
			"Query 1",
			"Query 2",
			"Query 3",
			"Query 4",
			"Query 5",
		};

		// Initialize filter options
		selectFilterOptions = new ObservableCollection<string> { "Column1", "Column2", "Column3" };
		fromFilterOptions = new ObservableCollection<string> { "Table1", "Table2", "Table3" };
		whereFilterOptions = new ObservableCollection<string> { "Condition1", "Condition2", "Condition3" };
	}

	[RelayCommand]
	private void AddChart()
	{

	}

	[RelayCommand]
	public void ShowPieChart()
	{
		IsPieChartVisible = true;
	}

	[RelayCommand]
	public void RemovePieChart()
	{
		IsPieChartVisible = false;
	}

	[RelayCommand]
	public void ShowCartesianChart()
	{
		IsCartesianChartVisible = true;
	}

	[RelayCommand]
	public void RemoveCartesianChart()
	{
		IsCartesianChartVisible = false;
	}

	[RelayCommand]
	private void ExecuteQuery()
	{
		// Example: Combine filters into a query string
		var query = $"SELECT {SelectFilter} FROM {FromFilter} WHERE {WhereFilter}";
		// Add the query to the items list or handle it as needed
		Items.Add(query);
	}
	public ISeries[] Pie { get; set; }
		= new ISeries[]
		{
				new PieSeries<double> { Values = new double[] { 2 } },
				new PieSeries<double> { Values = new double[] { 4 } },
				new PieSeries<double> { Values = new double[] { 1 } },
				new PieSeries<double> { Values = new double[] { 4 } },
				new PieSeries<double> { Values = new double[] { 3 } }
		};
	public ISeries[] Line { get; set; } =
	[
		new ColumnSeries<double>
			{
				Values = [2, 1, 3, 5, 3, 4, 6],


			},
			new ColumnSeries<double>
			{
				Values = [4, 2, 5, 2, 4, 5, 3],

		}
	];
	public Axis[] XAxes { get; set; } =
    [
        new Axis
        {
            Labels = ["Category 1", "Category 2", "Category 3"],
            LabelsRotation = 0,
            SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
            SeparatorsAtCenter = false,
            TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
            TicksAtCenter = true,
		}
	];
	public LabelVisual Title { get; set; } =
		new LabelVisual
		{
			Text = "IT WORKS!!!!!!!",
			TextSize = 25,
			Padding = new LiveChartsCore.Drawing.Padding(15)
		};

}
