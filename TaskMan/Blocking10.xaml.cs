using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskMan
{
    /// <summary>
    /// Логика взаимодействия для Blocking10.xaml
    /// </summary>
    public partial class Blocking10 : Window
    {
        public Blocking10()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            Blocking Reg = new Blocking();
            Reg.ShowDialog();
            
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
        }
    }
}
