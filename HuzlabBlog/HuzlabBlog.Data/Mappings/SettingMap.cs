using HuzlabBlog.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HuzlabBlog.Data.Mappings
{
    public class SettingMap : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(new Setting
            {
                Id = Guid.Parse("025EE5D2-1C37-486D-A441-EA7764629DA5"),
                AppDesc = "Uygulama Açıklaması",
                AppKeyword = "Keyword 1, Keyword 2, Keyword 3",
                CreatedDate = DateTime.Now,
                CreatedBy = "Berkay Huz",
                IsDeleted = false
            });
        }
    }
}
