using System.Collections.Generic;
namespace rest_sim.Models;

public class Recipe{
	public string Name { get; set; }
	public string Difficulty { get; set; }
	public List<string> Equipment { get; set; }
	public List<RecipeStep> Steps { get; set; }
}