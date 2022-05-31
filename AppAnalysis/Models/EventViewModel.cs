using System.ComponentModel.DataAnnotations;

namespace AppAnalysis.Models;

public class EventViewModel
{
    [Required]
    [Display(Name = "ID приложения")]
    public int AppId { get; set; }
    [Required]
    [Display(Name = "Название события")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Дата события")]
    public string Date { get; set; }
}