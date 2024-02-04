using AutoMapper;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Subscribe;

namespace HuzlabBlog.Service.AutoMapper.Subscribes
{
    public class SubscribeProfile : Profile
    {
        public SubscribeProfile()
        {
            CreateMap<SubscribeAddDto, Subscribe>().ReverseMap();
        }
    }
}
