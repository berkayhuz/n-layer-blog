using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Subscribe;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Services.Abstractions;

namespace HuzlabBlog.Service.Services.Concrete
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IUnitOfWork unitofWork;

        public SubscribeService(IUnitOfWork unitOfWork)
        {
            this.unitofWork = unitOfWork;
        }

        public async Task SubscribeAsync(SubscribeAddDto subscribeAddDto)
        {
            var subscribe = new Subscribe(subscribeAddDto.Name, subscribeAddDto.Surname, subscribeAddDto.Email);

            await unitofWork.GetRepository<Subscribe>().AddAsync(subscribe);
            await unitofWork.SaveAsync();
        }
    }
}
