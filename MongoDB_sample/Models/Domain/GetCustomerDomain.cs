using MongoDB.Bson;

namespace MongoDB_sample.Models.Domain
{
    public class GetCustomerDomain
    {
        public string? Id { get; set; }
        public string? CustomerName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }
}
