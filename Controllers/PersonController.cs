using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniverseExplorer.Models;


namespace UniverseExplorer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PersonController : ControllerBase
  {
    [HttpPost]
    public ActionResult CreatePerson()
    {
      var db = new DatabaseContext();
      var place = db.Places
        .FirstOrDefault(place => places.Id);
      if (place == null)
      {
        return NotFound();
      }
      else
      {
        var newPerson = new Person
        {
          CharacterName = newPerson.CharacterName,
          ActorName = newPerson.ActorName,
          CharacterName = newPerson.CharacterName,
          CharacterName = newPerson.Human,

        };
        db.Person.Add(newPerson);
        db.SaveChanges();
        var np = new CreatedNewPerson
        {
          Id = newPerson.Id,
          AttendanceIssues = newPerson.CharacterName,
          DoingWell = newPerson.ActorName,
          StudentId = newPerson.CharacterName,
          Improvement = newPerson.Human
        };
        return Ok(np);
      }
    }
  }
}