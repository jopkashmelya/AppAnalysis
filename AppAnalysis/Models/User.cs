using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace AppAnalysis.Models;

public class User : IdentityUser
{
    [JsonIgnore]
    public List<UserApp> Apps { get; set; }

    public User()
    {
        Apps = new List<UserApp>();
    }
}