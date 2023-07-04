using FluentNHibernate.Mapping;

namespace TestFluent.Models
{
    public class TaskMap : ClassMap<TaskModel>
    {
        public TaskMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Title);
            Map(x => x.Description);
            //Map(x => x.UserStory_Id);
            References(x => x.UserStory).Column("UserStory_Id").LazyLoad();
            Table("tasks");
        }
    }
}