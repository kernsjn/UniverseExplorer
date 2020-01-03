
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace UniverseExplorer.Models
{
  public class Place
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string ShortDescription { get; set; }

    // public List<Residence> Residences { get; set; } = new List<Residence>();
  }
}