using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NodaTime;

namespace AppAnalysis.Models;

public class UserApp
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }

    [Required]
    [Display(Name = "Название приложения")]
    public string Name { get; set; }
    
    [JsonIgnore]
    public User Owner { get; set; }
    public List<Event> Events { get; set; }
    
    public UserApp()
    {
        Events = new();
    }
}