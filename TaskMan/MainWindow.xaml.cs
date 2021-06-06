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
using Microsoft.Win32;

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

            OperatingSystem os_info = System.Environment.OSVersion;
            string OSVersion = os_info.VersionString +  "\n\nWindows " + GetOsName(os_info);

            if (IsWindows10())
            {
                MessageBox.Show("Windows 10");
            }
            else
            {
                MessageBox.Show("Windows not 10");
            }

        }

        // Return the OS name.
        private string GetOsName(OperatingSystem os_info)
        {
            string version =
                os_info.Version.Major.ToString() + "." +
                os_info.Version.Minor.ToString();
            switch (version)
            {
                case "10.0": return "10/Server 2016";
                case "6.3": return "8.1/Server 2012 R2";
                case "6.2": return "8/Server 2012";
                case "6.1": return "7/Server 2008 R2";
                case "6.0": return "Server 2008/Vista";
                case "5.2": return "Server 2003 R2/Server 2003/XP 64-Bit Edition";
                case "5.1": return "XP";
                case "5.0": return "2000";
            }
            return "Unknown";
        }

        private bool IsWindows10()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string productName = (string)reg.GetValue("ProductName");
            return productName.StartsWith("Windows 10");
        }


        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {
            bool WinVer10 = true;
            if (WinVer10)
            {
                Blocking10 Reg = new Blocking10();
                Reg.ShowDialog();
            }
            else
            {
                Blocking Reg = new Blocking();
                Reg.ShowDialog();
            }

            


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
