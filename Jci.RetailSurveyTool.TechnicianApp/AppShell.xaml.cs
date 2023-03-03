using Jci.RetailSurveyTool.TechnicianApp.ViewModels;
using Jci.RetailSurveyTool.TechnicianApp.Views;
using System;
using System.Collections.Generic;
using Jci.RetailSurveyTool.TechnicianApp.Views.NewAudit;

namespace Jci.RetailSurveyTool.TechnicianApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SyncPage), typeof(SyncPage));

            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            if (App.objUserModel != null && !string.IsNullOrEmpty(App.objUserModel.DisplayName))
            {
                userNameID.Text = App.objUserModel.DisplayName;
            }
            LbLAppVersion.Text = AppInfo.VersionString;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SyncPage();
        }
    }
}
