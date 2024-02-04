using AutoMapper;
using HuzlabBlog.Data.UnitOfWorks;
using HuzlabBlog.Entities.DTOs.Settings;
using HuzlabBlog.Entities.Entities;
using HuzlabBlog.Service.Extensions;
using HuzlabBlog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HuzlabBlog.Service.Services.Concrete
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<SettingDto>> GetSetting()
        {

            var setting = await unitOfWork.GetRepository<Setting>().GetAllAsync();
            var map = mapper.Map<List<SettingDto>>(setting);

            return map;
        }

        public async Task<Setting> GetSettingByGuid(Guid id)
        {
            var setting = await unitOfWork.GetRepository<Setting>().GetByGuidAsync(id);
            return setting;
        }

        public async Task<string> UpdateSettingAsync(SettingUpdateDto settingUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var setting = await unitOfWork.GetRepository<Setting>().GetAsync(x => !x.IsDeleted && x.Id == settingUpdateDto.Id);

            setting.AppDesc = settingUpdateDto.AppDesc;
            setting.AppKeyword = settingUpdateDto.AppKeyword;
            setting.ModifiedBy = userEmail;
            setting.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Setting>().UpdateAsync(setting);
            await unitOfWork.SaveAsync();

            return setting.AppDesc;
        }
    }
}
