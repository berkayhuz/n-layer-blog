using HuzlabBlog.Entities.DTOs.Articles;
using HuzlabBlog.Entities.DTOs.Subscribe;

namespace HuzlabBlog.Service.Services.Abstractions
{
    public interface ISubscribeService 
    {
        Task SubscribeAsync(SubscribeAddDto subscribeAddDto);
    }
}
