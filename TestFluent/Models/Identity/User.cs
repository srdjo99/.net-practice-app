using FluentNHibernate.Mapping;
using Microsoft.AspNet.Identity;

namespace TestFluent.Models.Identity
{
    public class User: IUser<int>
    {
        public virtual int Id { get; protected set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public class Map : ClassMap<User>
        {
            public Map()
            {
                Id(x => x.Id).GeneratedBy.Increment();
                Map(x => x.UserName);
                Map(x => x.Password);
                Table("users");
            }
        }
    }
}