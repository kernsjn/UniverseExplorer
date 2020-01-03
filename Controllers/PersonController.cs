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
    public ActionResult CreatePerson(int id)
    {
      var db = new DatabaseContext();
      var onePlace = db.Places
        .FirstOrDefault(i => i.Id == id);
      if (onePlace == null)
      {
        return NotFound();
      }
      else
      {

        return Ok(onePlace);
      }
    }
  }
}