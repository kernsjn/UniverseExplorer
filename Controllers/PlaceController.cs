using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniverseExplorer.Models;


namespace UniverseExplorer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PlaceController : ControllerBase
  {

    [HttpGet]
    public ActionResult GetAllShips()
    {
      // return a list of all students ordered by fullname
      var db = new DatabaseContext();
      return Ok(db.Places.OrderBy(place => place.ShipName));
    }

    [HttpGet("{id}")]
    public ActionResult GetOneShip(int id)
    {
      var db = new DatabaseContext();
      var place = db.Places.Include(i => i.Person).FirstOrDefault(pl => pl.Id == id);
      if (place == null)
      {
        return NotFound();
      }
      else
      {
        // create our json object
        var nd = new PlaceDetails
        {
          Id = place.Id,
          PlaceName = place.PlaceName,
          ShortDescription = place.ShortDescription,
          Person = place.Person.Select(nd => new CreatedPerson
          {

            CharacterName = nd.CharacterName,
            ActorName = nd.ActorName,
            CharacterName = nd.CharacterName,
            CharacterName = nd.Human,
            Id = nd.Id

          }).ToList()
        };
        return Ok(nd);
      }
    }

    [HttpPost]
    public ActionResult CreatePlace(Place place)
    {
      var db = new DatabaseContext();
      place.Id = 0;
      db.Places.Add(place);
      db.SaveChanges();
      return Ok(place);
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePlace(Place place)
    {
      var db = new DatabaseContext();
      var prevPlace = db.Places.FirstOrDefault(pl => pl.Id == place.Id);
      if (prevPlace == null)
      {
        return NotFound();
      }
      else
      {
        prevPlaceName = place.PlaceName,
          prevShortDescription = place.ShortDescription,
 
        db.SaveChanges();
        return Ok(prevPlace);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePlace(int id)
    {
      var db = new DatabaseContext();
      var place = db.Placess.FirstOrDefault(pl => pl.Id == id);
      if (place == null)
      {
        return NotFound();
      }
      else
      {
        db.Places.Remove(place);
        db.SaveChanges();
        return Ok();
      }
    }

  }
}