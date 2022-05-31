using System.Text.Json.Serialization;

namespace AppAnalysis.Models;

public class Event
{
    public int Id { get; set; }
    [JsonIgnore]
    public UserApp App { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
}