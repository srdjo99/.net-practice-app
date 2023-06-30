﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFluent.Models.UserStory
{
    public class UserStory
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual int? User_Id { get; set; }
    }
}

