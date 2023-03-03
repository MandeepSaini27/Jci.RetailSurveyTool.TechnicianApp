


using Jci.RetailSurveyTool.TechnicianApp.ViewModels.NewAudit;

namespace Jci.RetailSurveyTool.TechnicianApp.Views.ExistingAudit
{
    public partial class IssueListPage : ContentView
    {
        public IssueListViewModel viewModel { get; set; }
        public IssueListPage()
        {
            InitializeComponent();
            viewModel = new IssueListViewModel(null);
            BindingContext = viewModel;
            viewModel.LoadCommand.Execute(viewModel);
        }
    }
}
