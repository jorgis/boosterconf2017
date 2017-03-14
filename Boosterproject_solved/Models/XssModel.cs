
using System.ComponentModel.DataAnnotations;

namespace Boosterproject.Models
{
    public class XssModel
    {
        [Required]
        [Display(Name="Your name")]
        public string Name { get; set; }

    }
}