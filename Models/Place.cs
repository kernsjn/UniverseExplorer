
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace UniverseExplorer.Models
{
  public class Place
  {
    public int Id { get; set; }

    [Required]
    public string PlaceName { get; set; }
    public string ShortDescription { get; set; }

    public List<Person> Persons { get; set; }
  = new List<Person>();



  }
}