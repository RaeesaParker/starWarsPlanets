using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Models;

namespace StarWarsPlanets.Database{
  public class StarWarsPlanetsDB : DbContext
  {
    public StarWarsPlanetsDB(DbContextOptions<StarWarsPlanetsDB> options)
        : base(options) { }

    public DbSet<StarWarsPlanet> Planets => Set<StarWarsPlanet>();
  }
}