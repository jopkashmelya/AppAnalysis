using System.ComponentModel.DataAnnotations;

namespace AppAnalysis.Models;

public class CreateAppViewModel
{
    [Required]
    [Display(Name = "Название приложения")]
    public string Name { get; set; }

}