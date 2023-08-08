using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace KursovoyProject.Src.Games.Operations
{
    public partial class OperationGameP : Page
    {
        public OperationGameP()
        {
            InitializeComponent();
        }

        // Переход к тренажеру с учетом выбранной операции
        private void btnAddition_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).OpertationUsed = "+";
            var p = new OperationSettingP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }

        private void btnSubtraction_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).OpertationUsed = "-";
            var p = new OperationSettingP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).OpertationUsed = "*";
            var p = new OperationSettingP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }

        private void btnDivision_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).OpertationUsed = "/";
            var p = new OperationSettingP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }
    }
}
