using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFluent.Models
{
    public class TaskModel
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        //public virtual int UserStory_Id { get; set; }
        public virtual UserStoryModel UserStory { get; set; }
    }
}