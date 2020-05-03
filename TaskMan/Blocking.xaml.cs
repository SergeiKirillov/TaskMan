using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для Blocking.xaml
    /// </summary>
    public partial class Blocking : Window
    {
        public Blocking()
        {
            InitializeComponent();

            ListUpdate();

            //if (clUnBlock.IsAdmin())
            //{
            //    btnBlock.IsEnabled = true;
            //    btnUnBlock.IsEnabled = true;

            //}
            //else
            //{
            //    btnBlock.IsEnabled = false;
            //    btnUnBlock.IsEnabled = false;

            //}
        }

       

        private void btnBlock_Click(object sender, RoutedEventArgs e)
        {

            #region Блокировка заРаз ver 1
            //clUnBlock blockAll = new clUnBlock();
            //blockAll.BlockAllUblock(true);
            //ListUpdate();
            #endregion

            #region Блокировка заРаз ver 2
            //string baseSoft = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TaskMan.exe";
            //Console.WriteLine("baseSoft=  " + baseSoft);
            //clUnBlock.RunAsAdmin(baseSoft, "b");
            #endregion


            #region Блокировка заРаз ver3

            MessageBox.Show("После применения необходимо сделать выход/вход.", "Bloking...(5сек)", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            if (clUnBlock.IsAdmin())
            {

                clUnBlock blockAll = new clUnBlock();
                blockAll.BlockAllUblock(true);
            }
            else
            {
                try
                {
                    ////Ver 1
                    //string baseSoft = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TaskMan.exe";
                    //Process.Start(new ProcessStartInfo { FileName = baseSoft, Arguments = "-block", Verb = "runas" }).WaitForExit();

                    //Ver 2
                    //установка времени ожидания
                    int timeOut = 5000;

                    //MessageBox.Show("После применения необходимо сделать выход/вход.", "Bloking...(5сек)", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    //получить путь на котором сидит программа
                    string sysFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    //Создание отдельного процесса 
                    ProcessStartInfo pinfo = new ProcessStartInfo();
                    //Установка имени файла
                    pinfo.FileName = sysFolder + @"\TaskMan.exe";
                    //Аргументы
                    pinfo.Arguments = "-block";
                    //Права admin 
                    pinfo.Verb = "runas";
                    //Старт процесса 
                    Process p = Process.Start(pinfo);

                    //ждем окончания загрузки окна.
                    p.WaitForExit(timeOut);
                    // Проверяем, запущен ли процесс.
                    if (p.HasExited == false)
                    {
                        //Процесс все ещё запущен
                        if (p.Responding)
                        {
                            //процесс отвечает, закрываем главное окно
                            p.CloseMainWindow();
                        }
                        else
                        {
                            //Процесс не отвечает, грохаем все
                            p.Kill();
                        }
                    }


                }
                catch 
                {

                    MessageBox.Show("Повышение привелегий не удалось");
                }
            }
            #endregion

            log.writeLog("Программа заблокировала реестр.");
            
        }

        private void btnUnBlock_Click(object sender, RoutedEventArgs e)
        {
            #region Разблокировка заРаз ver 1
            //clUnBlock unBlockAll = new clUnBlock();
            //unBlockAll.BlockAllUblock(false);
            //ListUpdate();
            #endregion

            #region Разблокировка заРаз ver 2
            //string baseSoft = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TaskMan.exe";
            //Console.WriteLine("baseSoft=  " + baseSoft);
            //clUnBlock.RunAsAdmin(baseSoft, "u");

            #endregion

            #region Блокировка заРаз ver3

            MessageBox.Show("После применения необходимо сделать выход/вход.", "Unbloking....(5сек)", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            if (clUnBlock.IsAdmin())
            {
                clUnBlock blockAll = new clUnBlock();
                blockAll.BlockAllUblock(false);
            }
            else
            {
                try
                {
                    ////Ver 1
                    //string baseSoft = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TaskMan.exe";
                    //Process.Start(new ProcessStartInfo { FileName = baseSoft, Arguments = "-unblock", Verb = "runas" }).WaitForExit();
                    
                    //Ver 2
                    //установка времени ожидания
                    int timeOut = 5000;
                    
                    //получить путь на котором сидит программа
                    string sysFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    //Создание отдельного процесса 
                    ProcessStartInfo pinfo = new ProcessStartInfo();
                    //Установка имени файла
                    pinfo.FileName = sysFolder + @"\TaskMan.exe";
                    //Аргументы
                    pinfo.Arguments = "-unblock";
                    //Права admin 
                    pinfo.Verb = "runas";
                    //Старт процесса 
                    Process p = Process.Start(pinfo);

                    //ждем окончания загрузки окна.
                    p.WaitForExit(timeOut);
                    // Проверяем, запущен ли процесс.
                    if (p.HasExited == false)
                    {
                        //Процесс все ещё запущен
                        if (p.Responding)
                        {
                            //процесс отвечает, закрываем главное окно
                            p.CloseMainWindow();
                        }
                        else
                        {
                            //Процесс не отвечает, грохаем все
                            p.Kill();
                        }
                    }

                }
                catch
                {

                    MessageBox.Show("Повышение привелегий не удалось");
                }
            }
            #endregion

            log.writeLog("Программа разблокировала реестр.");
        }

        private void ListUpdate()
        {
            
            lstRegBlock.Items.Clear();
           // lstRegBlock.Items.Add(DateTime.Now.ToString());
                       
            clUnBlock dicBlock = new clUnBlock();
            #region загружаем данные c словаря и ищем в реестре эти ключи и значения. На основании значений заполняем listView



            foreach (var item in dicBlock.dicReestr)
            {
                if (item.Value.RazdelReg == "CU")
                {
                    //Console.WriteLine("RazdelReg=" + item.Value.RazdelReg);

                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(item.Value.PathReg))
                    {
                        if (item.Value.DataTypeReg == "dword")
                        {

                            string keyBl = key?.GetValue(item.Key)?.ToString();
                            //Console.WriteLine("keyBl=" + keyBl + " BlockParamReg " + item.Value.BlockParamReg);

                            if (keyBl != null)
                            {
                                
                                if (keyBl == item.Value.BlockParamReg)
                                {
                                    lstRegBlock.Items.Add(item.Value.DescriptReg);
                                    //Console.WriteLine("Блокировка");
                                }
                                else
                                {
                                    //Значение не обрабатывается
                                    //lvReestr.Items.Add(new Label() { Content = "Ветка ресстра(" + item.Key + ") на блокировку и разблокировку имеет не определеннное значение ", ToolTip = item.Value.DescriptReg });
                                }
                            }
                            else
                            {
                                //lvReestr.Items.Add(new Label() { Content = "Ветка ресстра(" + item.Key + ") на блокировку и разблокировку НЕ НАЙДЕНЫ", ToolTip = item.Value.DescriptReg });
                            }
                        }
                        else if (item.Value.DataTypeReg == "str")
                        {

                            string keyBl = key?.GetValue(item.Key)?.ToString();
                            if (keyBl != null)
                            {
                                string Ver;
                                //Определяем версию компьютера 
                                // для ХР(32) - 5.1
                                // Windows 7  - 6.1
                                // Windows 8  - 6.2
                                int majorVer = Environment.OSVersion.Version.Major;
                                int minorVer = Environment.OSVersion.Version.Minor;

                                if (majorVer == 5)
                                {
                                    Ver = @"%USERPROFILE%\Start Menu\Programs";
                                }
                                else
                                {
                                    Ver = @"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs";
                                }


                                //Console.WriteLine("keyBl=" + keyBl + " BlockParamReg " + item.Value.BlockParamReg);

                                if (keyBl == item.Value.BlockParamReg)
                                {
                                     lstRegBlock.Items.Add(item.Value.DescriptReg);
                                     //Console.WriteLine("Блокировка");
                                }
                                
                            }
                           
                        }
                        
                    }
                }
                else if (item.Value.RazdelReg == "LM")
                {
            

                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(item.Value.PathReg))
                    {
                        if (item.Value.DataTypeReg == "dword")
                        {

                        }
                        else if (item.Value.DataTypeReg == "str")
                        {
                            string keyBl = key?.GetValue(item.Key)?.ToString();

                            //Console.WriteLine("keyBl=" + keyBl + " BlockParamReg= " + System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "PerfMonitor.exe");

                            //Console.WriteLine("Замена диспетчера задач находится по пути - " + keyBl);
                            if (keyBl != null)
                            {

                                if (keyBl == System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "PerfMonitor.exe")
                                {
                                    lstRegBlock.Items.Add(item.Value.DescriptReg);
                                    //Console.WriteLine("Блокировка");
                                }
                                
                            }
                        }
                    }

                }
            }

            #endregion


        }

    }
}
