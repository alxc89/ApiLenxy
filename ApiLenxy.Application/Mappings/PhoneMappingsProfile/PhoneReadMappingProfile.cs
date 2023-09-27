using ApiLenxy.Application.DTOs.Phone;
using ApiLenxy.Domain.Entites;
using AutoMapper;

namespace ApiLenxy.Application.Mappings.PhoneMappingsProfile;

public class PhoneReadMappingProfile : Profile
{
    public PhoneReadMappingProfile()
    {
        CreateMap<Phone, PhoneDTO>()
            .ForMember(x => x.PhoneNumber, x => x.MapFrom(x => x.PhoneNumber.ToString()));
    }
}
