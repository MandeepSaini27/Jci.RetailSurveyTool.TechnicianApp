using Jci.RetailSurveyTool.TechnicianApp.Attributes;
using JCI.RetailSurveyTool.DataBase.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using System.Linq;
using Jci.RetailSurveyTool.TechnicianApp.Services;

namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class LookupPreviousViewModel : BaseViewModel
    {
        public LookupPreviousViewModel(INavigationService navigationService) : base(navigationService)
        {
            CommandTaskAttribute.InitCommands(this);

            LoadCustomersCommand.Execute(null);
        }

        [CommandTask(nameof(LoadCustomersTask))]
        public Command LoadCustomersCommand { private set; get; }
        public async Task LoadCustomersTask()
        {
            Customers.Clear();
            foreach (var cust in (await LocalAppDatabase.GetCustomerAsync()).OrderBy(x => x.Name))
            {

                Customers.Add(cust);

            }
        }

        public Customer SelectedCustomer { set; get; }
        public string SearchString { set; get; }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }


        [CommandTask(nameof(DoSearchTask))]
        public Command DoSearchCommand { private set; get; }

        public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();

        public ObservableCollection<Audit> Audits { get; } = new ObservableCollection<Audit>();

        public async Task DoSearchTask()
        {

            if (SelectedCustomer == null)
            {
                await Shell.Current.DisplayAlert("Error", "Please Select A Customer First", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                await Shell.Current.DisplayAlert("Error", "Please Enter A Store # First", "OK");
                return;
            }

            IsRefreshing = true;
            //do API
            var apiResults = await LocalAppDatabase.restService.SearchForAudits(SelectedCustomer.ID, SearchString);
            Audits.Clear();
            //Foreach result from api
            //Audits.Add(Audit from api results)
            foreach (var audit in apiResults)
            {
                Audits.Add(audit);
            }

            IsRefreshing = false;
        }



        /*public Audit SelectedAudit
        {
            get => selectedAudit; set
            {
                SetProperty(ref selectedAudit, value);
                if (selectedAudit != null)
                {
                    Shell.Current.GoToAsync($"ExistingAuditStoreAreaList?audit={value.ID}");
                }
            }
        }*/

        //private SVMX_WO _woselectedItem;
        private Audit selectedAudit;
        public Audit SelectedAudit
        {
            get => selectedAudit;
            set
            {
                if (value != null)
                {
                    selectedAudit = value;
                    OnPropertyChanged("SelectedAudit");
                    App.NavigationService.NavigateTo("PreviousAuditDetailsPage", value);
                    selectedAudit = null;
                }

            }
        }
    }
}
