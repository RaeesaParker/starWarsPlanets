using MediatR;
using StarWarsPlanets.Models;
using StarWarsPlanets.Interfaces;

namespace StarWarsPlanets.Commands
{
  public class PostFavouriteCommand : IRequest<StarWarsPlanet>
  {
    public int PlanetId {get; private set;}

    public PostFavouriteCommand(int planetId)
    {
      PlanetId = planetId; 
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
      StarWarsPlanet planet = await _planetRepo.Get(request.PlanetId);
      
      // Check if the planet has already been favourited 
      List<StarWarsPlanet> favouritedPlanets = await _planetRepo.GetFavPlanets();
      StarWarsPlanet APIPlanet = await _planetRepo.Get(request.PlanetId);
      
      StarWarsPlanet foundPlanet = favouritedPlanets.Find(planet => planet.name == APIPlanet.name);

      if(foundPlanet != null)
      {
        Console.WriteLine("Planet has already been favourited");
        throw new Exception();
      } 
      else
      {
        StarWarsPlanet savedPlanet = await _planetRepo.PostFav(planet);

        if (savedPlanet == null) throw new Exception("Error saving planet");
        else return savedPlanet ;
      }
 
    }
  }
}