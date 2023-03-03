using Jci.RetailSurveyTool.TechnicianApp.Utility;




namespace Jci.RetailSurveyTool.TechnicianApp.Views.NewAudit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuditStoreAreaList : ContentPage
    {
        public AuditStoreAreaList()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new StoreAreaDetailsShellTabPage());

                //Shell.Current.GoToAsync("//ShellTabPage");
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
               // Navigation.PushAsync(new StoreAreaDetailsShellTabPage());
                App.Current.MainPage.Navigation.PushAsync(new StoreAreaDetailsShellTabPage());
                //Shell.Current.GoToAsync("//ShellTabPage");
            });
        }
    }
}
