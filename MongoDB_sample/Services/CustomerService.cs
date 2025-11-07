using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB_sample.Models.Domain;
using MongoDB_sample.Models.Dto;
using MongoDB_sample.Repository;
using MongoDB_sample.Repository.Database.Entity;

namespace MongoDB_sample.Service
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerDomain data)
        {
            var dto = _mapper.Map<CreateCustomerDto>(data);
            var result = await _customerRepository.CreateCustomer(dto);
            return result;
        }


        public async Task<GetCustomerDomain> GetCustomer(string id)
        {
            var objectId = ObjectId.Parse(id);
            var result = await _customerRepository.GetCustomer(objectId);
            var mapped = _mapper.Map<GetCustomerDomain>(result);
            return mapped;

        }

        public async Task<GetCustomersDomain> GetCustomers()
        {
            var result = await _customerRepository.GetCustomers();
            var mapped = _mapper.Map<GetCustomersDomain>(result);
            return mapped;

        }

        public async Task<Customer> UpdateCustomer(UpdateCustomerDomain data)
        {
            var mappedData = _mapper.Map<UpdateCustomerDto>(data);
            var result = await _customerRepository.UpdateCustomer(mappedData);

            return result;
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            var result = await _customerRepository.DeleteCustomer(id);
            return true;
        }
    }
}
