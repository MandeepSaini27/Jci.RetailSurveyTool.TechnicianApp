﻿using System;
using System.Globalization;


namespace Jci.RetailSurveyTool.TechnicianApp.Converters
{
    public class ItemTappedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ItemTappedEventArgs eventArgs)
                return eventArgs.Item;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
