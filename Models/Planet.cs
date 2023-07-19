using System.Text.Json;
using System.Text.Json.Serialization;
namespace StarWarsPlanets.Models
{
  public class StarWarsPlanet
  { 
    public long Id  {get; set;} 
    public string? name {get; set;} 
    public string? rotation_period {get; set;} 
    public string? orbital_period {get; set;} 
    public string? Diameter  {get; set;}
    public string? Climate  {get; set;} 
    public string? Gravity  {get; set;}
    public string? Terrain  {get; set;} 
    public string? surface_water  {get; set;} 
    public string? Population  {get; set;}
    public string? Created  {get; set;} 
    public string? Edited  {get; set;} 
    public string? URL  {get; set;} 
  }

  public class StarWarsPlanetResponse
{
    public int? Count { get; set; } 
    public string? Next { get; set; } 
    public string? Previous { get; set; } 
    public List<StarWarsPlanet>? Results { get; set; }
}
}
