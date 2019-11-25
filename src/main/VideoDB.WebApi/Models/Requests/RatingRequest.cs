using System.ComponentModel.DataAnnotations;

namespace Evo.WebApi.Models.Requests
{
    public class RatingRequest
    {
        public string Source { get; set; }

        public decimal RatingValue { get; set; }
    }
}