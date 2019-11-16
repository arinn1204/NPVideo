using System.ComponentModel.DataAnnotations;

namespace Evo.WebApi.Models.Requests
{
    public class GenreRequest
    {
        [Required]
        public string Name { get; set; }
    }
}