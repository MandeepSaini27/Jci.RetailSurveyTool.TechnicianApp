﻿using Jci.RetailSurveyTool.TechnicianApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Jci.RetailSurveyTool.TechnicianApp.Views
{
    //[QueryProperty(nameof(IssueId), "ID")]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPicturesPage : ContentPage
    {

        //private string issueid;
        //public string IssueId
        //{
        //    get => issueid; set
        //    {
        //        issueid = value;
        //        ((ViewPicturesViewModel)this.BindingContext).LoadExistingData(int.Parse(value));
        //    }
        //}
        public ViewPicturesPage()
        {
            InitializeComponent();
        }
    }
}