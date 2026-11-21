using System.Windows;
using Task3.ViewModels;

namespace Task3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow(AuthorizationViewModel authorizationViewModel)
        {
            InitializeComponent();
            DataContext= authorizationViewModel;
        }
    }
}