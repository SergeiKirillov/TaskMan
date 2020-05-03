using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Management;




public class BlokUnKey
    {
        public string DescriptReg { get; set; }
        public string RazdelReg { get; set; }
        public string PathReg { get; set; }
        public string BlockParamReg { get; set; }
        public string UnblockParamReg { get; set; }
        public string DataTypeReg {get;set;}

        public BlokUnKey(string InDescriptReg, string InRazdelReg, string InPathReg, string InBlockParamReg, string InUnblockParamReg, string InDataTypeReg)
        {

            DescriptReg = InDescriptReg;
            RazdelReg = InRazdelReg;
            PathReg = InPathReg;
            BlockParamReg = InBlockParamReg;
            UnblockParamReg = InUnblockParamReg;
            DataTypeReg = InDataTypeReg;
        }
    }

    
    class clUnBlock
    {
        static public string DirPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        static public string DirName = "TaskMan";
        static public string DirDescription = "Logging soft TaskMan";

        static public string baseDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TaskMan\\Blok";
        static public string DirSoft = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TaskMan\\Blok\\BlokIcon";


    public Dictionary<string, BlokUnKey> dicReestr = new Dictionary<string, BlokUnKey>()
        {
            {"NoRun", new BlokUnKey("Скрыть кнопку Выполнить", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoCommonGroups", new BlokUnKey("Скрыть группы программ общего назначения", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoSetFolders", new BlokUnKey("Скрыть Панель управления и Принтеры", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoViewContextMenu", new BlokUnKey("Скрыть контексное меню на рабочем столе", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoTrayContextMenu", new BlokUnKey("Скрыть контексное меню на панели задач", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoSetTaskbar", new BlokUnKey("Блокировать изменния панели задач и Пуск", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoFind", new BlokUnKey("Скрыть поиск", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoDesktop", new BlokUnKey("Скрыть рабочий стол", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoSMHelp", new BlokUnKey("Скрыть пункт Справка и поддержка", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoControlPanel", new BlokUnKey("Скрыть Панель Управления", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoTrayItemsDisplay", new BlokUnKey("Скрыть область уведомлений", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoWinKeys", new BlokUnKey("Отключить Win клавиши", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoFolderOptions", new BlokUnKey("Скрыть свойства папки", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},

            {"NoDispCPL", new BlokUnKey("Скрыть настройку экрана", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","1","0","dword")},
            {"DisableRegistryTools", new BlokUnKey("Запрет на редактирование реестра", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","1","0","dword")},
            {"DisableLockWorkstation", new BlokUnKey("Запретить блокировку комп", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","1","0","dword")},
            {"DisableChangePassword", new BlokUnKey("Запрет изменения пароля", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System","1","0","dword")},

            {"NoUpdateCheck", new BlokUnKey("Запрет IE обновляться", "CU", "Software\\Microsoft\\Internet Explorer\\Main","1","0","dword")},

            {"EnableBalloonTips", new BlokUnKey("Скрыть Избранное", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced","0","1","dword")},
            {"StartMenuFavorites", new BlokUnKey("Скрыть уведомления", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced","0","1","dword")},

            {"NoEntireNetwork", new BlokUnKey("Скрыть информацию о комп. сети", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Network","1","0","dword")},
            {"NoWorkgroupContents", new BlokUnKey("Скрыть информацию о составе сети", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoNetHood", new BlokUnKey("Скрыть net", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoComputersNearMe", new BlokUnKey("Скрыть значок 'Соседние компьютеры'", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoNetworkConnections", new BlokUnKey("Удаление пункта Сетевые соединения", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"NoStartMenuNetworkPlaces", new BlokUnKey("Удаление Сетевого Окружения", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},
            {"Start_ShowNetPlaces", new BlokUnKey("Удаление пункта Сетевые окружение", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Advanced","0","1","dword")},

            


            {"NoDrives", new BlokUnKey("Спрятать HDD", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","67108863","0","dword")},

            {"Debugger", new BlokUnKey("Подмена Диспетчера Задач", "LM", "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\taskmgr.exe"," "," ","str")},

            //{"Programs",new BlokUnKey("Перенаправление папки Programs", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders",@"\\BlockIcon",@"%USERPROFILE%\Start Menu\Programs","str")},
            //{"Programs",new BlokUnKey("Перенаправление папки Programs", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders",@"\\BlockIcon",@"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs","str")},
            //{"NoStartMenuMorePrograms", new BlokUnKey("Удалить пункт Все программы", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer","1","0","dword")},

            {"Programs",new BlokUnKey("Перенаправление папки Programs", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders",DirSoft,"","str")},
            {"Start Menu",new BlokUnKey("Перенаправление папки Все программы", "CU", "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders",baseDir,@"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu","str")},
        };

        //clLog log = new clLog();

        public clUnBlock()
        {
            
        }

        public bool BlockAllUblock(bool block)
        {

            try
            {
                            
                foreach (var item in dicReestr)
                {
                #region без функции 

                //Console.WriteLine("clUnBlock  -  " + item.Value.DescriptReg);

                //if (item.Value.DataTypeReg == "dword")
                //{
                //    if (item.Value.RazdelReg == "CU")
                //    {
                //        if (block)
                //        {

                //            #region ПРоизводим блокировку
                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, item.Value.BlockParamReg, RegistryValueKind.DWord);
                //            //BlockAllLog.Trace("Блокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5));
                //            //log.Write(false, item.Value.RazdelReg, item.Value.BlockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            #endregion

                //        }
                //        else
                //        {
                //            #region производим разблокировку
                //            //Console.WriteLine("Разблокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(6));
                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, item.Value.UnblockParamReg, RegistryValueKind.DWord);
                //            Console.WriteLine("Разблокировка {0}{1} = {2}", item.Value.PathReg, item.Key, item.Value.UnblockParamReg);
                //            //BlockAllLog.Trace("Разблокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(6));
                //            //log.Write(false, item.Value.RazdelReg, item.Value.UnblockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            #endregion
                //        }

                //    }

                //}
                //else if (item.Value.DataTypeReg == "str")
                //{
                //    if (item.Value.RazdelReg == "LM")
                //    {
                //        if (block)
                //        {
                //            #region ПРоизводим блокировку
                //            Registry.LocalMachine.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "PerfMonitor.exe", RegistryValueKind.String);
                //            //BlockAllLog.Trace("Блокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "PerfMonitor.exe");
                //            //log.Write(false, item.Value.RazdelReg, item.Value.BlockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            #endregion
                //        }
                //        else
                //        {
                //            #region производим разблокировку
                //            Registry.LocalMachine.DeleteSubKey(@item.Value.PathReg);
                //            //BlockAllLog.Trace("Удаление ветки - {0}", sdr.GetString(3));
                //            //log.Write(false, item.Value.RazdelReg, item.Value.UnblockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            #endregion
                //        }
                //    }else  if (item.Value.RazdelReg == "CU")
                //    {
                //        if (block)
                //        {
                //            #region ПРоизводим блокировку

                //            if (!(Directory.Exists(item.Value.BlockParamReg))) //Если папка не существует ТО
                //            {
                //                //Console.WriteLine("Такого пути нет " + item.Value.BlockParamReg);
                //                Directory.CreateDirectory(item.Value.BlockParamReg); //Создаем папку, И ПОСЛЕ ЭТОГО
                //                //Console.WriteLine("Создаем путь " + item.Value.BlockParamReg);
                //            }



                //            //После того как проверили что папка существует создаем запись в реестре где меняем стандартное расположение папки на НАШЕ
                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, item.Value.BlockParamReg, RegistryValueKind.String);
                //            log.Reestr(item.Key, item.Value.BlockParamReg, item.Value.PathReg);


                //            #endregion
                //        }
                //        else
                //        {
                //            #region производим разблокировку

                //            string Ver;
                //            //Определяем версию компьютера 
                //            // для ХР(32) - 5.1
                //            // Windows 7  - 6.1
                //            // Windows 8  - 6.2
                //            int majorVer = Environment.OSVersion.Version.Major;
                //            int minorVer = Environment.OSVersion.Version.Minor;

                //            if (majorVer == 5)
                //            {
                //                Ver = @"%USERPROFILE%\Start Menu\Programs";
                //                Console.WriteLine("XP");
                //            }
                //            else
                //            {
                //                Ver = @"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs";
                //                Console.WriteLine("не ХР");
                //            }


                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, Ver, RegistryValueKind.String);
                //            log.Reestr(item.Key, Ver, item.Value.PathReg);
                //            #endregion
                //        }
                //    }
                //}
                #endregion
                #region Для блкировки и разблокировки используем bit(блокировка/разблокировка) и словарь с заданными значениями 
                    bool result = BlockUnBlock(block, item.Key, item.Value.DescriptReg, item.Value.RazdelReg, item.Value.PathReg, item.Value.BlockParamReg, item.Value.UnblockParamReg, item.Value.DataTypeReg);
                    if (result)
                    {
                        //log.Reestr(item.Key, block?item.Value.BlockParamReg:item.Value.UnblockParamReg, item.Value.PathReg);
                    }
                    else
                    {
                        //log.Reestr("Error - "+item.Key, block ? item.Value.BlockParamReg : item.Value.UnblockParamReg, item.Value.PathReg);
                    }
                #endregion
                }
                ShareFolder();
                return true;
            }
            catch (Exception e)
            {

                //BlockAllLog.Error("All Block Error -"+e.Message);
                Console.WriteLine(e.Message);
                return false;
            }
        }

    #region Функция отвечающая за внесение измений в зависимости от переданных значений
    
    static public bool BlockUnBlock(bool block,string Key, string Desc, string Razdel, string Path, string BlockParam, string UnBlockParam, string type)
        {
            try
            {

                #region работаем с реестром (сначала по типу, потом по Разделу)
                //if (type == "dword")
                //{
                //    if (Razdel == "CU")
                //    {
                //        if (block)
                //        {

                //            #region ПРоизводим блокировку
                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, item.Value.BlockParamReg, RegistryValueKind.DWord);
                //            //BlockAllLog.Trace("Блокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5));
                //            //log.Write(false, item.Value.RazdelReg, item.Value.BlockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            #endregion

                //        }
                //        else
                //        {
                //            #region производим разблокировку
                //            //Console.WriteLine("Разблокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(6));
                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, item.Value.UnblockParamReg, RegistryValueKind.DWord);
                //            Console.WriteLine("Разблокировка {0}{1} = {2}", item.Value.PathReg, item.Key, item.Value.UnblockParamReg);
                //            //BlockAllLog.Trace("Разблокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(6));
                //            //log.Write(false, item.Value.RazdelReg, item.Value.UnblockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            #endregion
                //        }

                //    }

                //}
                //else if (type == "str")
                //{
                //    if (Razdel == "LM")
                //    {
                //        if (block)
                //        {
                //            #region ПРоизводим блокировку
                //            Registry.LocalMachine.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "PerfMonitor.exe", RegistryValueKind.String);
                //            //BlockAllLog.Trace("Блокировка {0}{1} = {2}", sdr.GetString(3), sdr.GetString(4), System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "PerfMonitor.exe");
                //            //log.Write(false, item.Value.RazdelReg, item.Value.BlockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.BlockParamReg, item.Value.PathReg);
                //            #endregion
                //        }
                //        else
                //        {
                //            #region производим разблокировку
                //            Registry.LocalMachine.DeleteSubKey(@item.Value.PathReg);
                //            //BlockAllLog.Trace("Удаление ветки - {0}", sdr.GetString(3));
                //            //log.Write(false, item.Value.RazdelReg, item.Value.UnblockParamReg, item.Value.PathReg);
                //            //log.Write(true, item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            log.Reestr(item.Key, item.Value.UnblockParamReg, item.Value.PathReg);
                //            #endregion
                //        }
                //    }
                //    else if (item.Value.RazdelReg == "CU")
                //    {
                //        if (block)
                //        {
                //            #region ПРоизводим блокировку

                //            if (!(Directory.Exists(item.Value.BlockParamReg))) //Если папка не существует ТО
                //            {
                //                //Console.WriteLine("Такого пути нет " + item.Value.BlockParamReg);
                //                Directory.CreateDirectory(item.Value.BlockParamReg); //Создаем папку, И ПОСЛЕ ЭТОГО
                //                                                                     //Console.WriteLine("Создаем путь " + item.Value.BlockParamReg);
                //            }



                //            //После того как проверили что папка существует создаем запись в реестре где меняем стандартное расположение папки на НАШЕ
                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, item.Value.BlockParamReg, RegistryValueKind.String);
                //            log.Reestr(item.Key, item.Value.BlockParamReg, item.Value.PathReg);


                //            #endregion
                //        }
                //        else
                //        {
                //            #region производим разблокировку

                //            string Ver;
                //            //Определяем версию компьютера 
                //            // для ХР(32) - 5.1
                //            // Windows 7  - 6.1
                //            // Windows 8  - 6.2
                //            int majorVer = Environment.OSVersion.Version.Major;
                //            int minorVer = Environment.OSVersion.Version.Minor;

                //            if (majorVer == 5)
                //            {
                //                Ver = @"%USERPROFILE%\Start Menu\Programs";
                //                Console.WriteLine("XP");
                //            }
                //            else
                //            {
                //                Ver = @"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs";
                //                Console.WriteLine("не ХР");
                //            }


                //            Registry.CurrentUser.CreateSubKey(@item.Value.PathReg).SetValue(item.Key, Ver, RegistryValueKind.String);
                //            log.Reestr(item.Key, Ver, item.Value.PathReg);
                //            #endregion
                //        }
                //    }
                //}
                #endregion

                #region Работаем с реестром(сначала по разделу, а внутри по типу)
                if (Razdel=="CU")
                {
                    if (type == "dword")
                    {
                        if (block)
                        {
                            #region ПРоизводим блокировку
                            Registry.CurrentUser.CreateSubKey(@Path).SetValue(Key, BlockParam, RegistryValueKind.DWord);
                            #endregion

                        }
                        else
                        {
                            #region производим разблокировку
                            Registry.CurrentUser.CreateSubKey(@Path).SetValue(Key, UnBlockParam, RegistryValueKind.DWord);
                            #endregion
                        }
                    }
                    else if (type == "str")
                    {
                        if (block)
                        {
                            #region ПРоизводим блокировку
                                            
                                if (!(Directory.Exists(BlockParam))) //Если папка не существует ТО
                                {
                                    Directory.CreateDirectory(BlockParam); //Создаем папку, И ПОСЛЕ ЭТОГО
                                                                                         
                                }

                                //После того как проверили что папка существует создаем запись в реестре где меняем стандартное расположение папки на НАШЕ
                                Registry.CurrentUser.CreateSubKey(@Path).SetValue(Key, BlockParam, RegistryValueKind.String);
                                #endregion
                        }
                        else
                        {
                                #region производим разблокировку
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
                                   // Console.WriteLine("XP");
                                }
                                else
                                {
                                    Ver = @"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs";
                                   // Console.WriteLine("не ХР");
                                }

                                Registry.CurrentUser.CreateSubKey(@Path).SetValue(Key, Ver, RegistryValueKind.String);
                                #endregion
                        }
                        
                    }

                }
                else if (Razdel == "LM")
                {
                    if (type == "dword")
                    {
                        if (block)
                        {

                        }
                    }
                    else if (type == "str")
                    {
                        if (block)
                        {

                        #region ПРоизводим блокировку
                            //"Debugger" = "\"E:\\TOTALCMD_IT\\UTILITES\\-=ADMIN=-\\-=Äèñïåò÷åðÇàäà÷=-\\PROCESSEXPLORER\\PROCEXP.EXE\""
                            string keyReg ="\"" + System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "TaskMan.exe"+"\"";
                            //Console.WriteLine(keyReg);
                            Registry.LocalMachine.CreateSubKey(@Path).SetValue(Key, keyReg, RegistryValueKind.String);
                            #endregion
                        }
                        else
                        {
                            #region производим разблокировку
                            Registry.LocalMachine.DeleteSubKey(@Path);
                            #endregion
                        }
                           
                    }
                }
                #endregion

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    #endregion

    #region проверяем на наличие прав
    public static bool IsAdmin()
        {
            System.Security.Principal.WindowsIdentity id = System.Security.Principal.WindowsIdentity.GetCurrent();

            System.Security.Principal.WindowsPrincipal p = new System.Security.Principal.WindowsPrincipal(id);

            return p.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
    #endregion

    #region Запускаем программу с правами амдинистратора
    
    public static void RunAsAdmin(string aFileName, string anArguments)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
                processInfo.FileName = aFileName;
                processInfo.Arguments = anArguments;
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                System.Diagnostics.Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error "+ ex.Message);
            }

        

    }

    public static void RunAsAdminNoParam()
    {
        System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo(System.Reflection.Assembly.GetEntryAssembly().CodeBase);
        processStartInfo.UseShellExecute = true;
        processStartInfo.Verb = "runas";
        try
        {
            System.Diagnostics.Process.Start(processStartInfo);
        }
        catch
        {


        }
    }
    #endregion

    #region ShareFolder
    //public static void ShareFolder(string FolderPath, string ShareName, string Description)
    public static void ShareFolder()
    {
        try
        {
            ManagementClass managementClass = new ManagementClass("Win32_Share");
            ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
            ManagementBaseObject outParams;

            inParams["Description"] = DirDescription;
            inParams["Name"] = DirName;
            inParams["Path"] = DirPath;
            inParams["Type"] = 0x0;

            outParams = managementClass.InvokeMethod("Create", inParams, null);

            if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
            {
                throw new Exception("Unable to share directory.");
            }

        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message, "error!");
        }
    }
    #endregion
}

