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
            CreateMap<Models.Cart, Models.Response.CartByIdResponse>().
                   ForMember(d => d.Product,d => d.MapFrom(s =>s.Product)); 
            CreateMap<Models.ProductType, Models.Response.ProductType>().ReverseMap();

            ///CreateMap<Models.ProductType, Models.Response.CartByIdResponse>();

        }
    }
}
