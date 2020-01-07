using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UniverseExplorer.Models;
using UniverseExplorer.ViewModels;


namespace UniverseExplorer.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PersonController : ControllerBase
  {

    [HttpGet]
    public ActionResult GetAllPeople()
    {
      // return a list of all students ordered by fullname
      var db = new DatabaseContext();
      return Ok(db.Persons.OrderBy(person => person.CharacterName));
    }

    [HttpGet("{id}")]
    public ActionResult GetOnePerson(int id)
    {
      var db = new DatabaseContext();
      var onePerson = db.Persons.FirstOrDefault(f => f.Id == id);
      if (onePerson == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(onePerson);
      }
    }



    [HttpPost]
    public ActionResult CreatePerson(NewPerson vm)
    {
      var db = new DatabaseContext();
      var place = db.Places.FirstOrDefault(place => place.Id == vm.PlaceId);
      if (place == null)
      {
        return NotFound();
      }
      else
      {
        var newPerson = new Person
        {
          CharacterName = vm.CharacterName,
          ActorName = vm.ActorName,
          MainCharacter = vm.MainCharacter,
          Human = vm.Human,
          PlaceId = vm.PlaceId

        };
        db.Persons.Add(newPerson);
        db.SaveChanges();
        var rv = new CreatedPerson
        {
          Id = newPerson.Id,
          CharacterName = newPerson.CharacterName,
          ActorName = newPerson.ActorName,
          MainCharacter = newPerson.MainCharacter,
          PlaceId = newPerson.PlaceId,
          Human = newPerson.Human
                  };
        return Ok(rv);
      }
    }

    [HttpPut("{id}")]
    public ActionResult UpdatePerson(int id, Person person)
    {
      var db = new DatabaseContext();
      var prevPerson = db.Persons.FirstOrDefault(f => f.Id == person.Id);
      if (prevPerson == null)
      {
        return NotFound();
      }
      else
      {
        prevPerson.CharacterName = person.CharacterName;
        prevPerson.ActorName = person.ActorName;
        prevPerson.MainCharacter = person.MainCharacter;
        prevPerson.Human = person.Human;

        db.SaveChanges();
        return Ok(prevPerson);
      }
    }



    [HttpDelete("{id}")]
    public ActionResult DeletePerson(int id)
    {
      var db = new DatabaseContext();
      var person = db.Persons.FirstOrDefault(f => f.Id == id);
      if (person == null)
      {
        return NotFound();
      }
      else
      {
        db.Persons.Remove(person);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}
