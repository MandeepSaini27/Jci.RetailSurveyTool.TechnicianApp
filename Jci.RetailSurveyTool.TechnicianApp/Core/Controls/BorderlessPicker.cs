using System;
using System.Collections.Generic;
using System.Text;


namespace Jci.RetailSurveyTool.TechnicianApp.Controls
{
    public class BorderlessPicker : Picker
    {
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(BorderlessPicker), string.Empty);

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
}
