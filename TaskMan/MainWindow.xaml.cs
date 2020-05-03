using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Diagnostics;
using System.Reflection;

namespace TaskMan
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool bloginA;

        public object Current { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            btnBlock.IsEnabled = false;

            log.writeLog("Программа запущена");

            
        }

        

       

        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            Blocking Reg = new Blocking();
            Reg.ShowDialog();

        }

        private void btnWord_Click(object sender, RoutedEventArgs e)
        {

           
            try
            {
                Process.Start("winword.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("В системе не обнаружен Word.");
            }
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("excel.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("В системе не обнаружен Excel.");                
            }
            
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            winLogin login = new winLogin();
            login.ShowDialog();
            bloginA = login.logCheck;

            if (bloginA)
            {
                btnBlock.IsEnabled = true;
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //определять, будет ли команда выполнятся или нет.
            e.CanExecute = true;


        }

        private void btnRunAs_Click(object sender, RoutedEventArgs e)
        {
            ////Варинт1 
            //string baseSoft = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\TaskMan.exe";
            //Console.WriteLine("baseSoft=  " + baseSoft);
            //clUnBlock.RunAsAdmin(baseSoft, "");

            //TODO Дополнить кнопку запуском 
           //Вариант2 
            clUnBlock.RunAsAdminNoParam();

        }
    }
}
