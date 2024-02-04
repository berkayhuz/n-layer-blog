using AutoMapper;
using HuzlabBlog.Entities.DTOs.Settings;
using HuzlabBlog.Entities.Entities;

namespace HuzlabBlog.Service.AutoMapper.Settings
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<SettingDto, Setting>().ReverseMap();
            CreateMap<SettingUpdateDto, Setting>().ReverseMap();
        }
    }
}
