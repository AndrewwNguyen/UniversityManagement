using System.Text.Json;

namespace UniversityManagement.API.Models
{
    public class ErrorResponse
    {
        public int statusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
