using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task3.Navigations
{
    public interface INavigationService
    {
        void SetCurrentWindow(Window window);

        void NavigateTo<T, TParam>(TParam parameter) where T : Window;
    }
}
