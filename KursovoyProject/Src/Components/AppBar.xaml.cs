using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KursovoyProject.Src.Windows;

namespace KursovoyProject.Src.Components
{
    public partial class AppBar : UserControl
    {
        public AppBar()
        {
            InitializeComponent();
        }

        // Информация при нажатии опции "Обо мне"
        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа-тренажер по формированию тестов с использованием числовых паттернов,\nсделано Давидом Никончук\nв 2022 году."
                , "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // Запуск калькулятора, определению его позиции в зависимости от других открытых окон
        private void menuCalc_Click(object sender, RoutedEventArgs e)
        {
            CalcW instance = Application.Current.Windows.OfType<CalcW>().SingleOrDefault();

            if (instance == null)
            {

                var main = (MainWindow)Application.Current.MainWindow;
                CalcW winCalc = new CalcW();
                winCalc.WindowStartupLocation = WindowStartupLocation.Manual;
                winCalc.Left = main.Left + main.Width + 10;
                winCalc.Top = main.Top + (main.Height - winCalc.Height) / 2;
                winCalc.Show();
            }
            else
            {
                MessageBox.Show("Окно калькулятора уже открыто!",
                   "Warning",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning);
            }
        }

        // Открытие окна теории
        private void menuTheory_Click(object sender, RoutedEventArgs e)
        {
            TheoryW instance = Application.Current.Windows.OfType<TheoryW>().SingleOrDefault();
            CalcW instanceC = Application.Current.Windows.OfType<CalcW>().SingleOrDefault();

            if (instance == null)
            {

                TheoryW seqW = new TheoryW();
                seqW.WindowStartupLocation = WindowStartupLocation.Manual;

                if (instanceC == null)
                {
                    var main = (MainWindow)Application.Current.MainWindow;
                    seqW.Left = main.Left + main.Width + 10;
                    seqW.Top = main.Top + (main.Height - seqW.Height) / 2;
                }
                else
                {
                    var op = Window.GetWindow(instanceC);

                    seqW.Left = op.Width*2+seqW.Width ;
                    seqW.Top = op.Top + (op.Height - seqW.Height) / 2 + 20;
                }

                seqW.Show();
            }
            else
            {
                MessageBox.Show("Окно теоретического материала уже открыто!",
                   "Warning",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning);
            }
        }
    }
}
