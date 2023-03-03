using Jci.RetailSurveyTool.TechnicianApp.Utility;
using Jci.RetailSurveyTool.TechnicianApp.ViewModels;
using Jci.RetailSurveyTool.TechnicianApp.Views.NewAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Jci.RetailSurveyTool.TechnicianApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobListPage : ContentPage
    {
        public JobListPage()
        {
            InitializeComponent();
            //this.BindingContext = ViewModelLocator.JobListViewModel; // working version

            //Routing.RegisterRoute(nameof(NewAuditPage), typeof(NewAuditPage));
        }

        //private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    //((JobListViewModel)this.BindingContext).SelectedWO = (JCI.RetailSurveyTool.DataBase.Models.SVMX_WO)e.Item;
        //}
    }
}