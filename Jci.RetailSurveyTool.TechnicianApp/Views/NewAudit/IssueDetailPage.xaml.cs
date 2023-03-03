using Jci.RetailSurveyTool.TechnicianApp.Services;
using Jci.RetailSurveyTool.TechnicianApp.ViewModels.NewAudit;
using Jci.RetailSurveyTool.TechnicianApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jci.RetailSurveyTool.TechnicianApp.Views.NewAudit
{
    public partial class IssueDetailPage : ContentPage
    {
        public IssueDetailPage()
        {
            try
            {
                NavigationPage.SetHasBackButton(this, false);
                InitializeComponent();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
