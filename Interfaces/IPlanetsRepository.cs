using StarWarsPlanets.Models;
namespace StarWarsPlanets.Interfaces
{
  public interface IPlanetsRepository
  {
    Task<List<StarWarsPlanet>> GetAll();          // Get all the planets from API
    Task<StarWarsPlanet> Get(int planetId);       // Get one planet from API
    Task<List<StarWarsPlanet>>GetFavPlanets();   // Get favourite planets from DB
    Task<StarWarsPlanet>GetFavPlanet(long planetId);   // Get favourite planet from DB
    Task<StarWarsPlanet> PostFav(StarWarsPlanet planet);      // Post a favourite planet
    Task<StarWarsPlanet> DeleteFav(long planetId);      // Delete a favourite planet

  }
}