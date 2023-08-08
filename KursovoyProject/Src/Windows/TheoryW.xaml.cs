using Microsoft.Win32;
using System;
using System.Windows;

namespace KursovoyProject.Src.Windows
{
    public partial class TheoryW : Window
    {
        public TheoryW()
        {
            InitializeComponent();   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // настройки проводника для выбора раздела теории
            var basepath = System.AppDomain.CurrentDomain.BaseDirectory + @"HtmlPages";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ValidateNames = true;
            fileDialog.Filter = "HTML | *.html";
            fileDialog.DefaultExt = ".html";
            fileDialog.RestoreDirectory = true;
            fileDialog.InitialDirectory = basepath;       

            Nullable<bool> dialogOk = fileDialog.ShowDialog();
            
            if (dialogOk == true)
            {
                // если выбранный путь содержит путь с теорией, то отображаем, иначе: сообщаем пользователю
                if (fileDialog.FileName.Contains(basepath))
                {
                    string filePath = fileDialog.FileName;
                    txtFileName.Text = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                    Uri uri = new Uri(fileDialog.FileName);
                    articleBrowser.Source = uri;
                }
                else
                {
                    txtFileName.Text = "Выберите раздел из папки";
                }
           }
        }
    }
}
