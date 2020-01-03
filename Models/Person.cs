
using System.ComponentModel.DataAnnotations;

namespace UniverseExplorer.Models
{
  public class Person
  {
    public int Id { get; set; }

    public string ActorName { get; set; }
    public string CharacterName { get; set; }
    public bool MainCharacter { get; set; }

    public Place Place { get; set; }
  }
}