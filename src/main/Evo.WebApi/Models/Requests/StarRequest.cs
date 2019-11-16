using System.ComponentModel.DataAnnotations;
using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.Requests
{
    public class StarRequest
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public PersonType Role { get; set; }
    }
}