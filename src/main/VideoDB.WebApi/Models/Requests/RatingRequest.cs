using System.ComponentModel.DataAnnotations;

namespace Evo.WebApi.Models.Requests
{
    public class RatingRequest
    {
        [Required] public string Source { get; set; }

        [Required] public decimal RatingValue { get; set; }
    }
}