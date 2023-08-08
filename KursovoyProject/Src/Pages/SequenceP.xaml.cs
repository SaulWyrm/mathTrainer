using KursovoyProject.Src.Games.ChooseTheOption;
using KursovoyProject.Src.Games.GuessTheNumber;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovoyProject.Src.Pages
{
    public partial class SequenceP : Page
    {
        public SequenceP()
        {
            InitializeComponent();
        }

        // Переход по страницы при нажатии на конкретные кнопки
        private void btnAddition_Click(object sender, RoutedEventArgs e)
        {
            var p = new GuessTheNumberP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }

        private void btnSubtraction_Click(object sender, RoutedEventArgs e)
        {

            var p = new SequenceTestP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }


    }
}
