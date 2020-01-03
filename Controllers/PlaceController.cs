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
      return Ok(db.Places.OrderBy(place => place.PlaceName));
    }

    [HttpGet("{id}")]
    public ActionResult GetOneShip(int id)
    {
      var db = new DatabaseContext();
      var onePlace = db.Places.FirstOrDefault(i => i.Id == id);
      if (onePlace == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(onePlace);
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
    public ActionResult UpdatePlace(int id, Place place)
    {
      var db = new DatabaseContext();
      var prevPlace = db.Places.FirstOrDefault(pl => pl.Id == place.Id);
      if (prevPlace == null)
      {
        return NotFound();
      }
      else
      {
        prevPlace.PlaceName = place.PlaceName;
        prevPlace.ShortDescription = place.ShortDescription;

        db.SaveChanges();
        return Ok(prevPlace);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePlace(int id)
    {
      var db = new DatabaseContext();
      var place = db.Places.FirstOrDefault(pl => pl.Id == id);
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