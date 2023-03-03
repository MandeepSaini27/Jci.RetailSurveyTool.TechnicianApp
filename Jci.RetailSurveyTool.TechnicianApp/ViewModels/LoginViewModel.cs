using Jci.RetailSurveyTool.TechnicianApp.Models;
using Jci.RetailSurveyTool.TechnicianApp.Services;
using Jci.RetailSurveyTool.TechnicianApp.Views;
using Microsoft.Identity.Client;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;


namespace Jci.RetailSurveyTool.TechnicianApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private Command authenticateCommand;
        public Command AuthenticateCommand => authenticateCommand ?? (authenticateCommand = new Command(async () => await OnSignInSignOut()));

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
   
        async Task OnSignInSignOut()
        {
            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync();
            try
            {
                if (true)
                {
                    try
                    {
                        IAccount firstAccount = accounts.FirstOrDefault();
                        authResult = await App.PCA.AcquireTokenSilent(App.Scopes, firstAccount)
                                              .ExecuteAsync();
                    }
                    catch (MsalUiRequiredException ex)
                    {
                        try
                        {
                            authResult = await App.PCA.AcquireTokenInteractive(App.Scopes)
                                                      .WithParentActivityOrWindow(App.ParentWindow)
                                                      .ExecuteAsync().ConfigureAwait(true);
                        }
                        catch (Exception ex2)
                        {
                            await Application.Current.MainPage.DisplayAlert("Acquire token interactive failed. See exception message for details: ", ex2.Message, "Dismiss");
                        }
                    }

                    if (authResult != null)
                    {
                        var content = await GetHttpContentWithTokenAsync(authResult.AccessToken);
                        JObject user = JObject.Parse(content);
                        if (user != null)
                        {
                            UserModel objUserModel = new UserModel();
                            if (user["id"] != null)
                                objUserModel.Id = user["id"].ToString();
                            if (user["displayName"] != null)
                                objUserModel.DisplayName = user["displayName"].ToString();
                            if (user["givenName"] != null)
                                objUserModel.GivenName = user["givenName"].ToString();
                            if (user["mail"] != null)
                                objUserModel.Mail = user["mail"].ToString();
                            if (user["officeLocation"] != null)
                                objUserModel.OfficeLocation = user["officeLocation"].ToString();
                            if (user["surname"] != null)
                                objUserModel.Surname = user["surname"].ToString();
                            if (user["userPrincipalName"] != null)
                                objUserModel.UserPrincipalName = user["userPrincipalName"].ToString();

                            objUserModel.Token = authResult.AccessToken;

                            App.objUserModel = new UserModel();
                            App.objUserModel = objUserModel;
                        }
                        Shell.Current.GoToAsync("//login/SyncPage");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Authentication failed. See exception message for details: ", ex.Message, "Dismiss");
            }
        }
        public async Task<string> GetHttpContentWithTokenAsync(string token)
        {
            try
            {
                //get data from API
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.SendAsync(message);
                string responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("API call to graph failed: ", ex.Message, "Dismiss");
                return ex.ToString();
            }
        }

        
    }
}
