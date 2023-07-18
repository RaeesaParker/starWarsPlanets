using System.Text.Json;
using System.Text.Json.Serialization;
namespace StarWarsPlanets.Models
{
  public class StarWarsPlanet
  {
    public string? name {get; set;} 
    public string? rotation_period {get; set;} = null!; 
    public string? orbital_period {get; set;} = null!; 
    public string? Diameter  {get; set;}= null!; 
    public string? Climate  {get; set;} = null!; 
    public string? Gravity  {get; set;} = null!; 
    public string? Terrain  {get; set;} = null!; 
    public string? surface_water  {get; set;} = null!; 
    public string? Population  {get; set;} = null!; 
    public List<string>? Residents  {get; set;} = null!; 
    public List<string> Films  {get; set;} = null!; 
    public string? Created  {get; set;} = null!; 
    public string? Edited  {get; set;} = null!; 
    public string? URL  {get; set;} = null!; 
  }

  public class StarWarsPlanetResponse
{
    public int? Count { get; set; } = null!; 
    public string? Next { get; set; } = null!; 
    public string? Previous { get; set; } = null!; 
    public List<StarWarsPlanet>? Results { get; set; } = null!; 
}
}
