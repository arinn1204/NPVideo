using Evo.WebApi.Models.Enums;

namespace Evo.WebApi.Models.ViewModels
{
    public class StarViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public PersonType Role { get; set; }
    }
}