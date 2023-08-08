using System.Windows;
using KursovoyProject.Src.Pages;

namespace KursovoyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // глобальные переменные для накопления данных
        public static int numberQuestions = 0;
        public static int correct = 0;
        public static int incorrect = 0;
        public static int i = 1;

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainP();
        }


    }
}
