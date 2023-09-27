using ApiLenxy.Application.Mappings.CustomerMappingsProfile;
using ApiLenxy.Application.Mappings.PhoneMappingsProfile;

namespace ApiLenxy.Presentation.Configuration;

public static class AutoMapperConfig
{
   public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CustomerReadMappingProfile));
        services.AddAutoMapper(typeof(CustomerUpdateMappingProfile));
    }
}
