using FluentNHibernate.Mapping;

namespace TestFluent.Models.UserStory
{
    public class UserStoryMap : ClassMap<UserStory>
    {
        public UserStoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.User_Id);
            Table("user_stories");
        }
    }
}

