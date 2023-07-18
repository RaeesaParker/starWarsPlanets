using StarWarsPlanets.Models; 
using StarWarsPlanets.Interfaces; 
using StarWarsPlanets.Database;
using Microsoft.EntityFrameworkCore;

namespace StarWarsPlanets.Integrations
{
  public class PlanetsRepository : IPlanetsRepository
  {
    private readonly StarWarsPlanetsDB _dbContext;

      public PlanetsRepository(StarWarsPlanetsDB dbContext)
      {
        _dbContext = dbContext;
      }

  }
}