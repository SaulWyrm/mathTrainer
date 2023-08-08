using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KursovoyProject.Src.Components
{
    public partial class WindowBar : UserControl
    {
        public WindowBar()
        {
            InitializeComponent();
        }
        // Сжатие окна
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this);
            main.WindowState = WindowState.Minimized;
        }
        // Расширение окна
        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this);
            if (main.WindowState != WindowState.Maximized)
            {
                main.WindowState = WindowState.Maximized;
            }
            else
            {
                main.WindowState = WindowState.Normal;
            }
        }
        // Закрытие окна
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this);
            if (Process.GetProcessesByName("hh").Length > 0)
            {
                var process = Process.GetProcessesByName("hh")[0];
                var appPath = process.MainModule.FileName;
                process.Kill();
            }
            main.Close();
        }
        // Перетягивание окна через вернюю панель
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var main = Window.GetWindow(this);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                main.DragMove();
            }
        }

        private void ButtonManual_Click(object sender, RoutedEventArgs e)
        {
            if (Process.GetProcessesByName("hh").Length > 0)
            {
                MessageBox.Show("Справочник уже открыт");


            }
            else
            {
                Process.Start(@".\ReferenceBook\ReferenceBook.chm");

            }
            
        }
    }
}
