using Jci.RetailSurveyTool.TechnicianApp.Services;
using JCI.RetailSurveyTool.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class StoreAreaViewModel : BaseViewModel
    {
        public StoreAreaViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public ObservableCollection<StoreArea> StoreAreas { get; } = new ObservableCollection<StoreArea>();

        private string storeDisplayName;

        //public string StoreDisplayName { get => storeDisplayName; set => SetProperty(ref storeDisplayName, value); }
    }
}
