using System.ComponentModel.DataAnnotations;

namespace UniverseExplorer.Models
{
  public class Person
  {
    public int Id { get; set; }

    [Required]
    public string CharacterName { get; set; }

    public string ActorName { get; set; }

    public bool MainCharacter { get; set; } = true;

    public bool Human { get; set; } = true;

    public Place Place { get; set; }
  }
}