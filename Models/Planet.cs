namespace StarWarsPlanets.Models
{
  public class StarWarsPlanet
  {
    public string? PlanetName {get; set;}
    public double RotationPeriod {get; set;}
    public double OrbitalPeriod {get; set;}
    public double Diameter  {get; set;}
    public string? Climate  {get; set;}
    public string? Gravity  {get; set;}
    public string? Terrain  {get; set;}
    public double SurfaceWater  {get; set;}
    public double Population  {get; set;}
    public List<string>? Residents  {get; set;}
    public List<string>? Films  {get; set;}
    public string? Created  {get; set;}
    public string? Edited  {get; set;}
    public string? URL  {get; set;}

  }
}
