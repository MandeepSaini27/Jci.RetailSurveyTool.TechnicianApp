using Jci.RetailSurveyTool.TechnicianApp.Views.ExistingAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Jci.RetailSurveyTool.TechnicianApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LookupPreviousPage : ContentPage
    {
        public LookupPreviousPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("ExistingAuditStoreAreaList", typeof(AuditStoreAreaList));
        }
    }
}