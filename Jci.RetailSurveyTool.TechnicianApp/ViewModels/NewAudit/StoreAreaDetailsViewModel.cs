using Jci.RetailSurveyTool.TechnicianApp.Attributes;
using Jci.RetailSurveyTool.TechnicianApp.Bootstrap;
using Jci.RetailSurveyTool.TechnicianApp.Services;
using Jci.RetailSurveyTool.TechnicianApp.Utility;
using Jci.RetailSurveyTool.TechnicianApp.Views.NewAudit;
using JCI.RetailSurveyTool.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels.NewAudit
{
    public partial class StoreAreaDetailsViewModel : BaseViewModel
    {
        public StoreAreaDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            CommandTaskAttribute.InitCommands(this);
        }

        public void InitializeMessenger()
        {
            MessagingCenter.Subscribe<AuditStoreAreaListViewModel, StoreArea>(this, MessageNames.SelectedStoreAreaMessage, (auditStoreAreaListViewModel, storeArea) => OnSelectedStoreArea(storeArea));
        }

        private StoreArea _selectedStoreArea;

        public StoreArea SelectedStoreArea
        {
            get { return _selectedStoreArea; }
            set
            {
                _selectedStoreArea = value;   
                OnPropertyChanged();
                OnPropertyChanged(nameof(StoreAreaDetailTitle));
            }
        }

        public ICommand AddItemCommand => new Command(OnAddItemCommand);
        public ICommand AddInventoryCommand => new Command(OnAddInventoryCommand);
        public ICommand AddIssueCommand => new Command(OnAddIssueCommand);


        private void OnAddItemCommand()
        {
            if ((SelectedTab?.GetType() ?? typeof(InventoryListPage)) == typeof(InventoryListPage))
            {
                OnAddInventoryCommand();
            }
            else
            {
              OnAddIssueCommand();
            }
        }

        private void OnAddInventoryCommand()
        {
            if (SelectedStoreArea.DeactivationArea && SelectedStoreArea.PedestalArea)
            {
                App.NavigationService.NavigateTo("SelectInventoryPage");
            }
            else if (SelectedStoreArea.DeactivationArea)
            {
                App.NavigationService.NavigateTo("DeactivationInventoryDetailsPage");
            }
            else if( SelectedStoreArea.PedestalArea)
            {
                App.NavigationService.NavigateTo("PedestalInventoryDetailsPage");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Inventory", "Pedestal or Deactivation type is not set for this area", "Ok");
            }
        }

        private void OnAddIssueCommand()
        {
            App.NavigationService.NavigateTo("IssueDetailPage");
        }

        private void OnSelectedStoreArea(StoreArea storeArea)
        {
            SelectedStoreArea = storeArea;
        }


        public override async Task InitializeAsync(object parameter)
        {

        }

        public string StoreAreaDetailTitle
        {
            get
            {
                return SelectedStoreArea?.Name ?? "Area Details";
            }
        }

        private Page _selectedTab;

        public Page SelectedTab
        {
            get => _selectedTab; 
            set
            {
                _selectedTab = value;
                OnPropertyChanged();
                tabChanged();
            }
        }


        private void tabChanged()
        {
            if ((SelectedTab?.GetType() ?? typeof(InventoryListPage)) == typeof(InventoryListPage))
            {
                MessagingCenter.Send<StoreAreaDetailsViewModel>(this, MessageNames.RefreshInventoryListMessage); //Reset issue list form
            }
            else
            {
                MessagingCenter.Send<StoreAreaDetailsViewModel>(this, MessageNames.RefreshIssueListMessage); //Reset issue list form
            }
        }

    }
}
