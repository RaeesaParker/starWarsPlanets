using StarWarsPlanets.Models; 
using StarWarsPlanets.Interfaces; 
using StarWarsPlanets.Database;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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
  }
}