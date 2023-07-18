using Microsoft.EntityFrameworkCore;
using StarWarsPlanets.Models;

namespace StarWarsPlanets.Database{
  class StarWarsPlanetsDB : DbContext
{
    public StarWarsPlanetsDB(DbContextOptions<StarWarsPlanetsDB> options)
        : base(options) { }

    public DbSet<StarWarsPlanet> Todos => Set<StarWarsPlanet>();
}

}