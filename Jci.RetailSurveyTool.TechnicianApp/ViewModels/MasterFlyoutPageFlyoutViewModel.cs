using Jci.RetailSurveyTool.TechnicianApp.Models;
using Jci.RetailSurveyTool.TechnicianApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class MasterFlyoutPageFlyoutViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MasterFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

        public MasterFlyoutPageFlyoutViewModel()
        {
            MenuItems = new ObservableCollection<MasterFlyoutPageFlyoutMenuItem>(new[]
            {
                    new MasterFlyoutPageFlyoutMenuItem { Id = 0, Title="Job List", Icon = "x:Static fontAwesome:FontAwesomeIcons.Newspaper", TargetType = typeof(JobListPage)},
                    new MasterFlyoutPageFlyoutMenuItem { Id = 1, Title="Lookup Previous", Icon = "x:Static fontAwesome:FontAwesomeIcons.Search", TargetType = typeof(LookupPreviousPage) },
                    new MasterFlyoutPageFlyoutMenuItem { Id = 2, Title="Settings", Icon = "x:Static fontAwesome:FontAwesomeIcons.Cog", TargetType = typeof(SettingsPage) },
                    new MasterFlyoutPageFlyoutMenuItem { Id = 3, Title="Force Sync", Icon = "x:Static fontAwesome:FontAwesomeIcons.Sync", TargetType = typeof(SyncPage) },
                   
                });
        }


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
