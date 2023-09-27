using AutoMapper;

namespace ApiLenxy.Application.Mappings.CustomerMappingsProfile;

public class CustomerUpdateMappingProfile : Profile
{
    //public CustomerUpdateMappingProfile()
    //{
    //    CreateMap<UpdateCustomerCommand, Domain.Entites.Customer>()
    //        .ForMember(dest => dest.Name.FirstName, opt => opt.MapFrom(src => src.FirstName))
    //        .ForMember(dest => dest.Name.LastName, opt => opt.MapFrom(src => src.LastName))
    //        .ForMember(dest => dest.Email.Address, opt => opt.MapFrom(src => src.Address))
    //        .ForMember(dest => dest.Document.Number, opt => opt.MapFrom(src => src.DocumentNumber))
    //        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
    //        .ForMember(dest => dest.Document.Type, opt => opt.MapFrom(src => src.DocumentType))
    //        .ForMember(dest => dest.BirthDay.Date, opt => opt.MapFrom(src => src.BirthDay))
    //        .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phone))
    //        .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
    //        .ReverseMap();
    //}
}
