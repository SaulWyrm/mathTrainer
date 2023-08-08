using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using KursovoyProject.Src.Pages;
using static KursovoyProject.Src.Windows.CalcW;

namespace KursovoyProject.Src.Games.Operations
{
    public partial class OperationTestP : Page
    {
        string selectedOperation = (App.Current as App).OpertationUsed;
        public int addNumber1;
        public int addNumber2;
        int check;
        public double addNewRand1;
        public double addNewRand2;
        public double addNewAns;
        public string addNewRand1String;
        public string addNewRand2String;

        Random addRandom = new Random();
        public OperationTestP()
        {
            InitializeComponent();
            MainWindow.i = 1;
            lblAddSign.Content = selectedOperation;
            AddNew();
        }
        
        // Проверка вписанного ответа уравнению
        public void AddCheck()
        {
            var exp = $"{addNewRand1} {selectedOperation} {addNewRand2}";
            var result = StringToFormula.Eval(exp);

            if (Convert.ToInt32(txtbAddAnswer.Text) == result)
            {
                MainWindow.correct++;
                MessageBox.Show("Правильно!");
            }
            else
            {
                MainWindow.incorrect++;
                MessageBox.Show("Отвен неверен!");
            }
            MainWindow.i++;
            
            // Ставим пустые значение, если все примеры решены
            if (MainWindow.i == (MainWindow.numberQuestions) + 1)
            {
                btnAddFinish.IsEnabled = true;
                btnAddNext.IsEnabled = false;
                lblAddNum1 = null;
                lblAddNum2 = null;
            }
        }

        // Составляем новый пример
        public void AddNew()
        {
            lblAddQuesNum.Content = MainWindow.i;
            addNewRand1 = (int)(addRandom.NextDouble() * OperationW.addFactor) + 1;
            addNewRand2 = (int)(addRandom.NextDouble() * OperationW.addFactor) + 1;
            lblAddNum1.Content = addNewRand1;
            lblAddNum2.Content = addNewRand2;
        }
        
        private void btnAddNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                check = Convert.ToInt32(txtbAddAnswer.Text);
                AddCheck();
                if (MainWindow.i != (MainWindow.numberQuestions) + 1)
                {
                    AddNew();
                } 
            }
            catch (FormatException)
            {
                MessageBox.Show("Используйте только числа!");
            }
        }

        private void txtbAddAnswer_MouseEnter(object sender, MouseEventArgs e)
        {
            txtbAddAnswer.Text = null;
        }

        private void btnAddFinish_Click(object sender, RoutedEventArgs e)
        {
            var p = new OpScoreP();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(p);
        }
    }
}
