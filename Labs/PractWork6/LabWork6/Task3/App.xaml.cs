using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Task3.Serivces;
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

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

            services.AddSingleton<AuthorizationViewModel>();
            services.AddSingleton<AuthorizationWindow>();

            services.AddSingleton(provider =>
            {
                var mainWindow = new MainWindow
                {
                    DataContext = provider.GetRequiredService<MainViewModel>()
                };

                //var authorizationWindow = new AuthorizationWindow
                //{
                //    DataContext = provider.GetRequiredService<AuthorizationViewModel>()
                //};

                return mainWindow;
            });

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
