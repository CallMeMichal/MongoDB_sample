using AutoMapper;
using MongoDB.Bson;
using MongoDB_sample.Models.Domain;
using MongoDB_sample.Models.Dto;
using MongoDB_sample.Repository.Database.Entity;

namespace MongoDB_sample.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateCustomerDomain, CreateCustomerDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, GetCustomerDomain>();
            CreateMap<Customer, GetCustomersDomain>();
            CreateMap<UpdateCustomerDomain, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
