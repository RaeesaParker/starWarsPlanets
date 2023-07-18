using MediatR;
using StarWarsPlanets.Models;
using StarWarsPlanets.Interfaces;

namespace StarWarsPlanets.Commands
{
  public class PostFavouriteCommand : IRequest<StarWarsPlanet>
  {
    public StarWarsPlanet Planet {get; private set;}

    public PostFavouriteCommand(StarWarsPlanet planet)
    {
      Planet = planet; 
    }
  }

  public class PostFavouriteCommandHandler :  IRequestHandler<PostFavouriteCommand, StarWarsPlanet>
  {
    private IPlanetsRepository _planetRepo; 
    private readonly IMediator _mediator; 

    public PostFavouriteCommandHandler(IPlanetsRepository planetRepo, IMediator mediator )
    {
      _planetRepo = planetRepo;
      _mediator = mediator;
    }
    public  async Task<StarWarsPlanet> Handle(PostFavouriteCommand request, CancellationToken cancellationToken)
    {
      return null ; 
    }
  }
}