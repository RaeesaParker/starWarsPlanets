using StarWarsPlanets.Models;
namespace StarWarsPlanets.Interfaces
{
  public interface IPlanetsRepository
  {
    // Get all the planets
    Task<List<StarWarsPlanet>> GetAll();
    // Get a favourited planet
    // Post a favourite planet

    // Delete a planet
  }
}