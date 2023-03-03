using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JCI.RetailSurveyTool.DataBase.Models
{
    public class CustomerPreferredSystem
    {
        [Key]
        public int ID { set; get; }
        [SQLite.Ignore]
        public virtual Customer Customer { set; get; }
        [SQLite.Ignore]
        public virtual SystemType SystemType { set; get; }
    }
}
