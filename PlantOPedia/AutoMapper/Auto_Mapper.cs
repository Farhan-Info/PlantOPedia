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
            CreateMap<Models.Order, Models.Response.Order>();
            CreateMap<Models.Request.Order, Models.Order>();
            CreateMap<Models.Users, Models.Request.Order>().ReverseMap();
            CreateMap<Models.Product, Models.Request.Order>().ReverseMap();
            CreateMap<Models.Cart, Models.Response.CartByIdResponse>().
                   ForMember(d => d.Product,d => d.MapFrom(s =>s.Product)); 
            CreateMap<Models.ProductType, Models.Response.ProductType>().ReverseMap();

            ///CreateMap<Models.ProductType, Models.Response.CartByIdResponse>();

        }
    }
}
