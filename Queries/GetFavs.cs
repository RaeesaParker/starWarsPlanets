using MediatR;
using StarWarsPlanets.Models;
using StarWarsPlanets.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;


namespace StarWarsPlanets.Querys
{
  public class GetFavsQuery : IRequest<List<StarWarsPlanet>>
  {
    public GetFavsQuery()
    {
        
    }

  }

  public class GetFavsQueryHandler : IRequestHandler<GetFavsQuery, List<StarWarsPlanet>>
  {
    private readonly IPlanetsRepository _repo;

      public GetFavsQueryHandler(IPlanetsRepository repo )
      {
          _repo = repo;
      }

      public async Task<List<StarWarsPlanet>> Handle(GetFavsQuery request, CancellationToken cancellationToken)
      {
        var planets = await _repo.GetFavPlanets();
        return planets;

      }
  }
}