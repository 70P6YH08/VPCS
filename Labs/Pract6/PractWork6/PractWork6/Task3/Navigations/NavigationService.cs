using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task3.Navigations
{
    public class NavigationService(IServiceProvider serviceProvider) : INavigationService
    {
        private Window _currentWindow;

        public void SetCurrentWindow(Window window)
        {
            _currentWindow = window;
        }

        public void NavigateTo<T, TParam>(TParam parameter) where T : Window
        {
            var factory = serviceProvider.GetRequiredService<Func<TParam, T>>();
            var newWindow = factory(parameter);

            _currentWindow?.Close();
            _currentWindow = newWindow;
            newWindow.Show();
        }
    }
}
