using FluentNHibernate.Mapping;

namespace TestFluent.Models
{
    public class UserStoryMap : ClassMap<UserStoryModel>
    {
        public UserStoryMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Title);
            Map(x => x.Description);
            HasMany(x => x.Tasks).Cascade.AllDeleteOrphan().Inverse();
            Table("user_stories");
        }
    }
}