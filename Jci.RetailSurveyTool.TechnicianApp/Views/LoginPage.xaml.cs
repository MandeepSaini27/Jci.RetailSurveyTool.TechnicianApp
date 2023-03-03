using Jci.RetailSurveyTool.TechnicianApp.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jci.RetailSurveyTool.TechnicianApp.ViewModels;



namespace Jci.RetailSurveyTool.TechnicianApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
           
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
            this.BindingContext = new LoginViewModel(null);
            base.OnAppearing();
        }
    }
}