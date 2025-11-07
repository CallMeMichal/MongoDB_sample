using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_sample.Models.Dto;
using MongoDB_sample.Repository.Database;
using MongoDB_sample.Repository.Database.Entity;

namespace MongoDB_sample.Repository
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer>? _customers;
        private readonly IMapper _mapper;

        public CustomerRepository(MongoDbService mongoDbService, IMapper mapper)
        {
            _customers = mongoDbService.Database?.GetCollection<Customer>("customers");
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerDto dto)
        {
            var databaseEntity = _mapper.Map<Customer>(dto);
            await _customers?.InsertOneAsync(databaseEntity);
            return databaseEntity;
        }

        public async Task<Customer> GetCustomer(ObjectId id)
        {
            var users = await _customers.Find(x => x.Id == id).FirstOrDefaultAsync();
            return users;

        }

        public async Task<List<Customer>> GetCustomers()
        {

            var users = await _customers.Find(_ => true).ToListAsync();
            return users;

        }

        public async Task<Customer> UpdateCustomer(UpdateCustomerDto dto)
        {

            var databaseEntity = _mapper.Map<Customer>(dto);
            var objectId = ObjectId.Parse(dto.Id);
            var result = await _customers.FindOneAndReplaceAsync(x => x.Id == objectId, databaseEntity);
            return result;
        }

        public async Task<Customer> DeleteCustomer(string id)
        {
            var objectId = ObjectId.Parse(id);
            var result = await _customers.FindOneAndDeleteAsync(x => x.Id == objectId);
            return result;
        }
    }
}
