using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Models; 
using StarWarsPlanets.Interfaces; 
using StarWarsPlanets.Database;
using System.Text.Json;

namespace StarWarsPlanets.Integrations
{
  public class PlanetsRepository : IPlanetsRepository
  {
    private readonly StarWarsPlanetsDB _dbContext;
    private readonly IHttpClientFactory _httpClientFactory;

    public PlanetsRepository(StarWarsPlanetsDB dbContext, IHttpClientFactory httpClientFactory)
    {
      _dbContext = dbContext;
      _httpClientFactory = httpClientFactory;
    }

    public async Task<List<StarWarsPlanet>> GetAll()
    {
      var httpClient = _httpClientFactory.CreateClient(); 
      var response = await httpClient.GetAsync("https://swapi.dev/api/planets/");

      if (response.IsSuccessStatusCode)
      {
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var planets = JsonSerializer.Deserialize<StarWarsPlanetResponse>(json, options)?.Results;
        return planets;
      }
      else throw new Exception("Error: response from API has failes"); 
    }


    public async Task<StarWarsPlanet> Get(int planetId)
    {
      var httpClient = _httpClientFactory.CreateClient(); 
      var response = await httpClient.GetAsync($"https://swapi.dev/api/planets/{planetId.ToString()}");

      if (response.IsSuccessStatusCode)
      {
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var planet = JsonSerializer.Deserialize<StarWarsPlanet>(json, options);
        return planet;
      }
      else throw new Exception("Error: response from API has failes"); 
    }


    public async Task<List<StarWarsPlanet>> GetFavPlanets()
    {
      return await _dbContext.Planets.ToListAsync();
    }


    public async Task<StarWarsPlanet> GetFavPlanet(long planetId)
    {
      StarWarsPlanet planet = await _dbContext.Planets.FindAsync(planetId);
      if (planet == null) throw new Exception("The planet does not exist");
      else return planet;
    }


    public async Task<StarWarsPlanet> PostFav(StarWarsPlanet planet)
    {
      _dbContext.Planets.Add(planet); 
      await _dbContext.SaveChangesAsync();
      
      StarWarsPlanet savedPlanet = await GetFavPlanet(planet.Id);
      return savedPlanet;
    }


    public async Task<StarWarsPlanet> DeleteFav(long planetId)
    {
      if (await _dbContext.Planets.FindAsync(planetId) is StarWarsPlanet planet)
      {
          _dbContext.Planets.Remove(planet);
          await _dbContext.SaveChangesAsync();
          return null;
      }
      else throw new Exception ("Planet not found");
    }
  }
}