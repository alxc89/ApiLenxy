using AutoMapper;

namespace ApiLenxy.Application.Mappings.CustomerMappingsProfile
{
    public class CustomerReadMappingProfile : Profile
    {
        //public CustomerReadMappingProfile()
        //{
        //    CreateMap<Customer, CustomerDTO>()
        //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name.FirstName))
        //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Name.LastName))
        //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address))
        //    .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.Document.Number))
        //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
        //    .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.Document.Type))
        //    .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.Date))
        //    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phones))
        //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
        //    .ReverseMap();

        //    CreateMap<Phone, PhoneDTO>().ReverseMap();
        //    CreateMap<Address, AddressDTO>().ReverseMap();
        //}
    }
}
