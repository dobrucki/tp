using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewData;

namespace View
{
    public class PopupHelper : IPopupHelper
    {
        public void Show(string errorName, string errorMessage)
        {
            MessageBox.Show(errorName, errorMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowDetails()
        {
            new DetailInfoWindow().Show();
        }
    }
}
