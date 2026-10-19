using FrigoMalin.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Globalization;

namespace FrigoMalin.Converters
{
    public class UrgencyToColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is UrgencyStatus status)
            {
                return status switch
                {
                    UrgencyStatus.Perime => Color.FromArgb("#B71C1C"),   // Rouge bordeaux
                    UrgencyStatus.Critique => Color.FromArgb("#D32F2F"), // Rouge alerte
                    UrgencyStatus.Alerte => Color.FromArgb("#EF6C00"),   // Orange vif
                    _ => Color.FromArgb("#2E7D32")                       // Vert feuille
                };
            }
            return Color.FromArgb("#757575");
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public class UrgencyToBgColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is UrgencyStatus status)
            {
                return status switch
                {
                    UrgencyStatus.Perime => Color.FromArgb("#FFEBEE"),
                    UrgencyStatus.Critique => Color.FromArgb("#FFEBEE"),
                    UrgencyStatus.Alerte => Color.FromArgb("#FFF3E0"),
                    _ => Color.FromArgb("#E8F5E9")
                };
            }
            return Color.FromArgb("#F5F5F5");
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }

    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            return false;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            return false;
        }
    }
}
