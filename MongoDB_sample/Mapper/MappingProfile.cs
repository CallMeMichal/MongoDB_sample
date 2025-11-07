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
            CreateMap<Customer, GetCustomerDomain>()
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<Customer, GetCustomersDomain>()
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<UpdateCustomerDomain, UpdateCustomerDto>()
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));

            CreateMap<UpdateCustomerDto, Customer>()
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
        }
    }
}
