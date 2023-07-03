using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFluent.Models
{
    public class UserStoryModel
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<TaskModel> Tasks { get; set; } = new List<TaskModel>();

    }
}