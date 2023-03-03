using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JCI.RetailSurveyTool.DataBase.Models
{
    public class CustomerErpMapping
    {
        [Key]
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public int ErpCustomerNumber { set; get; }
        [SQLite.Ignore]
        public virtual Customer Customer { set; get; }
    }
}
