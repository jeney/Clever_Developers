using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using rest_sim.Models;
using rest_sim.ViewModels;
public static class RecipeLoaderService{
    public static (List<Ingredient>, List<Recipe>) LoadRecipes(string jsonPath){
        try{
            var json = File.ReadAllText(jsonPath);
			var options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true};
            var data = JsonSerializer.Deserialize<ExerciseJSON>(json, options);

        // Handle potential null values
        return (data?.Ingredients ?? new List<Ingredient>(),
                data?.Recipes ?? new List<Recipe>());
    }
    catch (Exception ex) {
        throw new InvalidOperationException($"Failed to load recipes: {ex.Message}", ex);
    }
}

    private class ExerciseJSON{
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}