using MediatR;
using StarWarsPlanets.Models;
using StarWarsPlanets.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;


namespace StarWarsPlanets.Querys
{
  public class GetFavQuery : IRequest<StarWarsPlanet>
  {
    public long PlanetId {get; set;}
    public GetFavQuery(long planetId)
    {
        PlanetId = planetId;
    }

  }

  public class GetFavQueryHandler : IRequestHandler<GetFavQuery, StarWarsPlanet>
  {
    private readonly IPlanetsRepository _repo;

      public GetFavQueryHandler(IPlanetsRepository repo )
      {
          _repo = repo;
      }

      public async Task<StarWarsPlanet> Handle(GetFavQuery request, CancellationToken cancellationToken)
      {
        StarWarsPlanet planet = await _repo.GetFavPlanet(request.PlanetId);
        if (planet == null)
        {
          Console.WriteLine("Planet has not been favourited");
          throw new Exception();
        }
        else return planet;
      }
  }
}