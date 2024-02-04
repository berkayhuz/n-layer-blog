using HuzlabBlog.Entities.DTOs.Settings;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.Services.Abstractions
{
    public interface ISettingService
    {
        Task<string> UpdateSettingAsync(SettingUpdateDto settingUpdateDto);
        Task<List<SettingDto>> GetSetting();
        Task<Setting> GetSettingByGuid(Guid id);
    }
}
