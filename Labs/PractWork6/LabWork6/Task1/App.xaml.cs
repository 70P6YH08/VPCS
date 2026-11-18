using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Task1.Serivces;
using Task1.ViewModels;
using Task1.Views;

namespace Task1
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

            services.AddSingleton<MainWindow>(provider =>
            {
                var mainWindow = new MainWindow
                {
                    DataContext = provider.GetRequiredService<MainViewModel>()
                };

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
