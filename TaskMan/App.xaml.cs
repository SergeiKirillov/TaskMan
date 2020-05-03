using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

using System.Windows;

namespace TaskMan
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            int verbose = 0;

            //var optionSet = new OptionSet
            //{
            //    { "v|verbose", "verbose output, repeat for more verbosity.",
            //        arg => verbose++ }
            //}

            var extra = e.Args;

            if (e.Args.Length==1 && e.Args[0]=="-block")
            {
                clUnBlock blockAll = new clUnBlock();
                blockAll.BlockAllUblock(true);
            }
            else if (e.Args.Length == 1 && e.Args[0] == "-unblock")
            {
                clUnBlock blockAll = new clUnBlock();
                blockAll.BlockAllUblock(false);
            }
            else
            {
                //Console.WriteLine("Нет Аргументов");
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
                

           

        }
    }
}
