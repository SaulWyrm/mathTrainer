using KursovoyProject.Src.Games.Operations;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace KursovoyProject.Src.Pages
{
    public partial class OpScoreP : Page
    {
        // Подсчет кол-ва правильных и неправильных ответов
        public OpScoreP()
        {
            InitializeComponent();
            double score = 0.0;
            double dCorrect = 0.0;
            double dIncorrect = 0.0;
            double dNumber = 0.0;

            dNumber = Convert.ToDouble(MainWindow.numberQuestions);
            dCorrect = Convert.ToDouble(MainWindow.correct);
            dIncorrect = Convert.ToDouble(MainWindow.incorrect);

            // Подсчет в процентном содержании
            score = (dCorrect / dNumber) * 100;
            lblNumScore.Content = (int)score + "%";
            lblNumCorAns.Content = Convert.ToString(MainWindow.correct);
            lblNumIncCor.Content = Convert.ToString(MainWindow.incorrect);

            // Вариация ответа в зависимости от балла
            if ((int)score == 100)
            {
                lblComment.Content = "Хорошая работа. Вы Виртуоз!";
                lblComment.Foreground = Brushes.Green;
            }
            else if ((int)score >= 80)
            {
                lblComment.Content = "Неплохо, но есть куда стремиться!";
                lblComment.Foreground = Brushes.Yellow;
            }
            else if ((int)score >= 60)
            {
                lblComment.Content = "Еще бы чуть-чуть и ...";
                lblComment.Foreground = Brushes.Orange;
            }
            else
            {
                lblComment.Content = "Над этим нужно поработать.";
                lblComment.Foreground = Brushes.Red;
            }

            // Обнуляем данные для следующего тестирования
            MainWindow.correct = 0;
            MainWindow.incorrect = 0;
            MainWindow.numberQuestions = 0;
        }

        // Переносим фокус на страницы соответсвующих разделов, в зависимости от того, где мы были изначально
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            
            var p = new SequenceP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
            
            
            MainWindow.numberQuestions = 0;
            MainWindow.i = 0;
        }
    }
}
