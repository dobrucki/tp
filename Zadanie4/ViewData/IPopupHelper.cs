using System;
using System.Collections.Generic;
using System.Text;

namespace ViewData
{
    public interface IPopupHelper
    {
        void Show(string errorName, string errorMessage);

        void ShowDetails();
        
    }
}
