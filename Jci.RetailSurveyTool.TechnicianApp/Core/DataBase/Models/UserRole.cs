﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JCI.RetailSurveyTool.DataBase.Models
{
    public class UserRole
    {
        [Key]
        public int ID { set; get; }
        public string GlobalID { set; get; }
        public int? RoleID { set; get; }
        public int? CustomerID { set; get; }
        [SQLite.Ignore]
        public virtual Role Role { set; get; }
        [SQLite.Ignore]
        public virtual Customer Customer { set; get; }
    }
}
