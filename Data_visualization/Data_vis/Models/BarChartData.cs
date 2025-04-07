namespace Data_vis.Models;
public class BarChartData
{
	public float Number { get; set; }
	public string Name { get; set; }
	public BarChartData(float number, string name)
	{
		Number = number;
		Name = name;
	}
}
