using Jci.RetailSurveyTool.TechnicianApp.Controls;
using Jci.RetailSurveyTool.TechnicianApp.ViewModels.NewAudit;


namespace Jci.RetailSurveyTool.TechnicianApp.Views.NewAudit
{
    public partial class StoreAreaDetailsShellTabPage : Shell
    {
        public StoreAreaDetailsShellTabPage()
        {
            try
            {
                InitializeComponent();
                //BindingContext = new StoreAreaDetailsViewModel(null);
                //Routing.RegisterRoute(nameof(IssueDetailPage), typeof(IssueDetailPage));
                //Routing.RegisterRoute(nameof(DeactivationInventoryDetailsPage), typeof(DeactivationInventoryDetailsPage));
                //Routing.RegisterRoute(nameof(PedestalInventoryDetailsPage), typeof(PedestalInventoryDetailsPage));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
