using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniverseExplorer.ViewModels
{
  public class PlaceDetails
  {
    public int Id { get; set; }

    [Required]
    public string PlaceName { get; set; }
    public string ShortDescription { get; set; }

    public List<CreatedPerson> Persons { get; set; }
  = new List<CreatedPerson>();
  }
}