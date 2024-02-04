using HuzlabBlog.Core.Entities;

namespace HuzlabBlog.Entities.Entities
{
    public class Setting : BaseEntity
    {
        public Setting()
        {

        }
        public Setting(string appDesc, string appKeyword)
        {
            AppKeyword = appKeyword;
            AppDesc = appDesc;
        }
        public string AppDesc { get; set; }
        public string AppKeyword{ get; set; }
    }
}
