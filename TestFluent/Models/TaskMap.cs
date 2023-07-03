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
            References(x => x.UserStory);
            Table("tasks");
        }
    }
}