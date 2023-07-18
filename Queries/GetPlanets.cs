using MediatR;
using StarWarsPlanets.Models;
using StarWarsPlanets.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;


namespace StarWarsPlanets.Querys
{
  public class GetPlanetsQuery : IRequest<List<StarWarsPlanet>>
  {
    public GetPlanetsQuery()
    {
        
    }

  }

  public class GetPlanetsQueryHandler : IRequestHandler<GetPlanetsQuery, List<StarWarsPlanet>>
  {
    private readonly IPlanetsRepository _repo;

      public GetPlanetsQueryHandler(IPlanetsRepository repo )
      {
          _repo = repo;
      }

      public async Task<List<StarWarsPlanet>> Handle(GetPlanetsQuery request, CancellationToken cancellationToken)
      {
        var planets = await _repo.GetAll();
        return planets;

      }
  }
}