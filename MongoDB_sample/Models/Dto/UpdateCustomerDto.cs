using MongoDB.Bson;

namespace MongoDB_sample.Models.Dto
{
    public class UpdateCustomerDto
    {
        public string? Id { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }
}
