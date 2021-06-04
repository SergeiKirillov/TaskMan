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
    /// Логика взаимодействия для winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        public bool logCheck = false;
        public winLogin()
        {
            InitializeComponent();
        }

        private void btnPasCheck_Click(object sender, RoutedEventArgs e)
        {
            LogPasswordChecking();
        }

        private void pbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && e.Key == Key.Enter)
            {
                LogPasswordChecking();
            }
        }

        private void LogPasswordChecking()
        {
            string data = DateTime.Now.ToString("ddMMyyyy");
            
            //Console.WriteLine(data);

            if (pbPassword.Password.ToString()==data)
            {
                
                log.writeLog("Пароль правильный");
                logCheck = true;
                Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            }
            else
            {
                log.writeLog("Пароль не правильный");
                MessageBox.Show("Пароль не правильный.Сегодня " + DateTime.Now.ToString("ddMMyyyy"));
                logCheck = false;
            }

        }
    }
}
