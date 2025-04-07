namespace Data_vis.Models;
public class PieChartData
{
	public float Number { get; set; }
	public string Name { get; set; }
	public PieChartData(float number, string name)
	{
		Number = number;
		Name = name;
	}
}
