using System.Linq;
using System.Windows;
using System.Windows.Controls;
using KursovoyProject.Src.Games.Operations;

namespace KursovoyProject.Src.Pages
{
    public partial class MainP : Page
    {
        public MainP()
        {
            InitializeComponent();
        }
        // Создание окна раздела "Математические операции"
        // Если окно "Тестирование" уже открыто, то новое окно откроется дальше от Главной и наоборот.
        private void btnAddition_Click(object sender, RoutedEventArgs e)
        {
            OperationW instance = Application.Current.Windows.OfType<OperationW>().SingleOrDefault();
            SequenceW instanceSeq = Application.Current.Windows.OfType<SequenceW>().SingleOrDefault();
            // Если окно существует, то сообщаем, что оно уже было открыто
            if (instance == null)
            {
                OperationW opW = new OperationW();
                opW.WindowStartupLocation = WindowStartupLocation.Manual;
                // Определяем расположение нового окна в зависимости от существования других на экране
                if (instanceSeq == null)
                {
                    var main = (MainWindow)Application.Current.MainWindow;
                    if (main.WindowState == WindowState.Maximized)
                    {
                        opW.Show();
                    }
                    opW.Left = main.Left - main.Width - 10;
                    opW.Top = main.Top + (main.Height - opW.Height) / 2;
                }
                else
                {
                    var seq = Window.GetWindow(instanceSeq);

                    opW.Left = seq.Width - 70;
                    opW.Top = seq.Top + (seq.Height - opW.Height) / 2 + 20;
                }
                opW.Show();
            } else
            {
                MessageBox.Show("Окно тренажера уже открыто!",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
        // Схожая логика, что и в функции выше
        private void btnSequence_Click(object sender, RoutedEventArgs e)
        {
            SequenceW instance = Application.Current.Windows.OfType<SequenceW>().SingleOrDefault();
            OperationW instanceOp = Application.Current.Windows.OfType<OperationW>().SingleOrDefault();

            if (instance == null)
            {
                SequenceW seqW = new SequenceW();
                seqW.WindowStartupLocation = WindowStartupLocation.Manual;

                if (instanceOp == null)
                {
                    var main = (MainWindow)Application.Current.MainWindow;
                    seqW.Left = main.Left - main.Width - 10;
                    seqW.Top = main.Top + (main.Height - seqW.Height) / 2;
                }
                else
                {
                    var op = Window.GetWindow(instanceOp);

                    seqW.Left = op.Width - 70;
                    seqW.Top = op.Top + (op.Height - seqW.Height) / 2 + 20;
                }
                seqW.Show();
            }
            else
            {
                MessageBox.Show("Окно тренажера уже открыто!",
                    "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
