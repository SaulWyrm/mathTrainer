using KursovoyProject.Src.Pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KursovoyProject.Src.Games.GuessTheNumber
{
    public partial class GuessTheNumberP : Page
    {
        Random randomNumber = new Random();
        int number = 0;
        int guesses = 0;
        public GuessTheNumberP()
        {
            InitializeComponent();

            loadQuestions();
        }

        // проверка числа
        private void CheckNumber(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtEnterNumber.Text);

            // подсчет кол-ва сделанных попыток
            guesses += 1;
            lblGuessed.Text = "Сделано " + guesses + " попыток";
            
            if (i == number)
            {
                MessageBox.Show("Круто, угадано верно. Попробуйте еще");
               loadQuestions();
                txtEnterNumber.Text = "";
                guesses = 0;
                lblGuessed.Text = "Сделано " + guesses + " попыток";
            } // подсказка, если число не найдено
            else if (i < number)
            {
                MessageBox.Show("Бери выше");
                
            }
            else
            {
                MessageBox.Show("Бери ниже");
            }
            txtEnterNumber.Text = "";

        }

        // составление диапазона чисел
        private void loadQuestions()
        {
            // подбираем такой диапазон, чтобы числа находились 0 - 80,
            // нижнее и верхнее число находились друн от друга на дистанции 3-10 чисел
            int limit = 80;
            int range = randomNumber.Next(3, 10);
            int lowBorder = randomNumber.Next(limit - 1);
            int highBorder = randomNumber.Next(lowBorder + 1, limit);
            while ( (highBorder - lowBorder) != range)
            {
                lowBorder = randomNumber.Next(limit - 1);
                highBorder = randomNumber.Next(lowBorder, limit);
            }
            number = randomNumber.Next(lowBorder, highBorder);

            lblQuestion.Text = $"Я загадал число в диапазоне: {lowBorder} и {highBorder} ";

        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            var page2 = new SequenceP();
            NavigationService.Navigate(page2);
        }

        // Фильтрация ввода
        private void txtEnterNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            (App.Current as App).textChange(txtEnterNumber);
        }
    }
}
