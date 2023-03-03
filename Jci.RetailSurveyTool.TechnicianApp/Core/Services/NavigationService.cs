using Jci.RetailSurveyTool.TechnicianApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace Jci.RetailSurveyTool.TechnicianApp.Services
{
    public class NavigationService : INavigationService
    {
        private Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();

        public Page MainPage => Application.Current.MainPage;

        public void Configure(string key, Type pageType) => pages[key] = pageType;

        public void GoBack() => MainPage.Navigation.PopAsync();

        public async Task NavigateTo(string pageKey, object parameter = null)
        {
            try
            {

                if (pages.TryGetValue(pageKey, out Type pageType))
                {
                    var page = (Page)Activator.CreateInstance(pageType);
                    page.SetNavigationArgs(parameter);
                    await App.Current.MainPage.Navigation.PushAsync(page);
                    //App.NavigationService.NavigateTo(pageKey);
                    (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
                }
                else
                {
                    throw new ArgumentException($"This page doesn't exist: {pageKey}.", nameof(pageKey));
                }
            }
            catch(Exception ex)
            {

            }
        }
    }

    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            object argument = null;
            try
            {

            arguments.TryGetValue(page, out argument);
            }
            catch(Exception ex)
            {

            }

            return argument;
        }

        public static void SetNavigationArgs(this Page page, object args)
        {
            try
            {
                arguments.Add(page, args);
            }
            catch (Exception ex)
            {

            }
        } 
    }

}
