using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Task3.Navigations;
using Task3.Services;
using Task3.ViewModels;
using Task3.Views;

namespace Task3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<SMTPService>();
            services.AddSingleton<LogService>();
            services.AddSingleton<MessageService>();
            services.AddSingleton<MailValidator>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<MainViewModel>();

            services.AddSingleton(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<Func<string, AuthorizationWindow>>(
                sp => email =>
                {
                    var vm = sp.GetRequiredService<Func<string, AuthorizationViewModel>>()(email);
                    return new AuthorizationWindow(vm);
                });

            services.AddSingleton<Func<string, AuthorizationViewModel>>(
                sp => email => new AuthorizationViewModel(
                    sp.GetRequiredService<SMTPService>(),
                    sp.GetRequiredService<LogService>(),
                    sp.GetRequiredService<MessageService>())
                { Email = email });


            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
