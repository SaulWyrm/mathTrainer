using System;
using System.Windows;

namespace KursovoyProject.Src.Pages
{
    public partial class SequenceW : Window
    {
        public SequenceW()
        {
            InitializeComponent();
            SequenceFrame.Content = new SequenceP();
        }
    }
}
