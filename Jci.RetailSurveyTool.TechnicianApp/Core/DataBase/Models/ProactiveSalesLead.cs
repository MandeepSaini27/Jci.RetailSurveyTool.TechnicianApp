using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JCI.RetailSurveyTool.DataBase.Models
{
    public class ProactiveSalesLead
    {
        [Key]
        public int ID { set; get; }
        public virtual ProactiveSalesLeadStatus Status { set; get; }
        public virtual Inventory Source { set; get; }
    }
}
