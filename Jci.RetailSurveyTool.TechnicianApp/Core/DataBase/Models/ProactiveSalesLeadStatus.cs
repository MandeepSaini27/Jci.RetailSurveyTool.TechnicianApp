using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JCI.RetailSurveyTool.DataBase.Models
{
    public class ProactiveSalesLeadStatus
    {
        [Key]
        [MaxLength(100)]
        public string ProactiveSalesLeadStatusName { set; get; }
        public virtual List<ProactiveSalesLead> Leads { set; get; }

    }
}
