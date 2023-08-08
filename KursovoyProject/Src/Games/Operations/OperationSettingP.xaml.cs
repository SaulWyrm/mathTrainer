using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

using KursovoyProject.Src.Games.Operations;

namespace KursovoyProject.Src.Games.Operations
{
    /// <summary>
    /// Interaction logic for OperationSettingP.xaml
    /// </summary>
    public partial class OperationSettingP : Page
    {
        public OperationSettingP()
        {
            InitializeComponent();
        }

        private void txtbNumAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            txtbNumAdd.Text = null;
        }

        // Определяем коэффициент создания примеров в зависимости от выбранного размера числа
        private void btnAddTest_Click(object sender, RoutedEventArgs e)
        {
                if (txtbNumAdd.Text == "")
                {
                txtbNumAdd.Text = "1";
                }
                MainWindow.numberQuestions = Convert.ToInt32(txtbNumAdd.Text);
                if ((string)cmbAddBigProblems.SelectionBoxItem == "Единицы")
                {
                    OperationW.addFactor = 10;
                }
                else if ((string)cmbAddBigProblems.SelectionBoxItem == "Десятки")
                {
                    OperationW.addFactor = 100;
                }
                else if ((string)cmbAddBigProblems.SelectionBoxItem == "Сотни")
                {
                    OperationW.addFactor = 1000;
                }

                var p = new OperationTestP();
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(p);
            

        }

        // Кнопка назад
        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            var page2 = new OperationGameP();
            NavigationService.Navigate(page2);
        }

        // Фильтрация ввода
        private void txtbNumAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            (App.Current as App).textChange(txtbNumAdd);
        }
    }
}
