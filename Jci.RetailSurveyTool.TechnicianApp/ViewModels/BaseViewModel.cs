
using Jci.RetailSurveyTool.TechnicianApp.Data;
using Jci.RetailSurveyTool.TechnicianApp.Models;
using Jci.RetailSurveyTool.TechnicianApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void OnAppearing()
        {
        }

        public LocalAppDatabase LocalAppDatabase => DependencyService.Resolve<LocalAppDatabase>();
        public RestService RestService => DependencyService.Resolve<RestService>();

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            return true;
        }
        protected async Task LoadTable<T>(ObservableCollection<T> collection, Func<List<T>> source)
        {
            IsBusy = true;

            try
            {
                await Task.Run(() =>
                {
                    collection.Clear();
                    foreach (T item in source.Invoke())
                    {
                        collection.Add(item);
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected async Task LoadTableAsync<T>(ObservableCollection<T> collection, Func<Task<IEnumerable<T>>> source)
        {
            IsBusy = true;

            try
            {
                collection.Clear();
                foreach (T item in await source.Invoke())
                {
                    collection.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected async Task LoadTableAsync<T>(ObservableCollection<T> collection, Func<Task<List<T>>> source)
        {
            IsBusy = true;

            try
            {
                collection.Clear();
                foreach (T item in await source.Invoke())
                {
                    collection.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected bool SetProperty<T>(Action<T> setAction, Func<T> getAction, T value,
           [CallerMemberName] string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(getAction.Invoke(), value))
                return false;

            setAction.Invoke(value);
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        protected readonly INavigationService _navigationService;
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        public virtual bool OnBackButtonPressed()
        {
            return false;
        }
        public virtual void OnSoftBackButtonPressed()
        {
        }

        protected virtual void OnDisappearing() { }

    }


}
