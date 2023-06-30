using FluentNHibernate.Mapping;

namespace TestFluent.Models.UserStoryTasks
{
    public class UserStoryTasksMap : ClassMap<UserStoryTasks>
    {
        public UserStoryTasksMap() 
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.User_Story_Id);
            Table("user_story_tasks");
         }
    }
}