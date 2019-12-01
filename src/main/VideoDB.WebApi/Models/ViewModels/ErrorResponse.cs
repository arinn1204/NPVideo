namespace Evo.WebApi.Models.ViewModels
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public string StackTrace { get; internal set; }
    }
}