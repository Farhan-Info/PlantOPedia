using AutoMapper;

namespace PlantOPedia.AutoMapper
{
    public class Auto_Mapper : Profile
    {
        public Auto_Mapper()
        {
            CreateMap<Models.Users, Models.Response.Login>().
                    ForMember(o => o.RoleType, o => o.MapFrom(s => s.Role.RoleType));

            CreateMap<Models.Product, Models.Response.Product>();
            CreateMap<Models.Product, Models.Response.ProductDetail>();
        }
    }
}
