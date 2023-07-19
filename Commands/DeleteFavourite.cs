using MediatR;
using StarWarsPlanets.Models;
using StarWarsPlanets.Interfaces;

namespace StarWarsPlanets.Commands
{
  public class DeleteFavouriteCommand : IRequest<StarWarsPlanet>
  {
    public long PlanetId {get; private set;}

    public DeleteFavouriteCommand(long planetId)
    {
      PlanetId = planetId; 
    }
  }

  public class DeleteFavouriteCommandHandler :  IRequestHandler<DeleteFavouriteCommand, StarWarsPlanet>
  {
    private IPlanetsRepository _planetRepo; 
    private readonly IMediator _mediator; 

    public DeleteFavouriteCommandHandler(IPlanetsRepository planetRepo, IMediator mediator )
    {
      _planetRepo = planetRepo;
      _mediator = mediator;
    }
    public  async Task<StarWarsPlanet> Handle(DeleteFavouriteCommand request, CancellationToken cancellationToken)
    {
      
      return await _planetRepo.DeleteFav(request.PlanetId);
 
    }
  }
}