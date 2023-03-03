using Jci.RetailSurveyTool.TechnicianApp.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;


namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Xamarin.Essentials.Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}