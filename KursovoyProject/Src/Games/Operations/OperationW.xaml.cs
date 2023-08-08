using System.Windows;

namespace KursovoyProject.Src.Games.Operations
{
    /// <summary>
    /// Interaction logic for OperationW.xaml
    /// </summary>
    public partial class OperationW : Window
    {
        public static int addFactor;
        public OperationW()
        {
            InitializeComponent();
            MainWindow.correct = 0;
            MainWindow.incorrect = 0;
            OperationFrame.Content = new OperationGameP();
        }
    }
}
