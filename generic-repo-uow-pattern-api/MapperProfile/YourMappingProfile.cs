using AutoMapper;
using generic_repo_pattern_api.Entity;
using generic_repo_pattern_api.ViewModel;
using Microsoft.Extensions.Hosting;

namespace generic_repo_pattern_api.MapperProfile
{
    public class YourMappingProfile : Profile
    {
        public YourMappingProfile()
        {
            //CreateMap<entity, Dto>();
            CreateMap<Product, ProductRequest>().ReverseMap();
            //CreateMap<Order, OrderRequest>().ReverseMap();

            //CreateMap<Blog, BlogPostReqeust>().ReverseMap();
            //CreateMap<Post, PostRequest>().ReverseMap();
            //CreateMap<Post, PostResponse>().ReverseMap();
        }
    }
}
