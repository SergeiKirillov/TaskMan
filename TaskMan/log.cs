using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Linq;
using System.Windows;
//using System.Text;


class log
{
    //Конструктор
    public log()
    { 

    }

    public void write(bool File, byte Status, long TimeStatus,  string Message) 
    //1-true вывод в файл, false - в БД
    //2-true статус ping - ОК, false - статус ping - Error 
    //3-ip адрес
    {
        if (File)
        {
            #region В случае с выводом в файл  
            //В файл
            ////1-вариант
            //XDocument documentOut = XDocument.Load("CompPingOut.xml");
            //XElement root = documentOut.Element("IPLog");
            //foreach (XElement itemIP in root.Elements("id").ToList())
            //{
            //    string ipfile = itemIP.Element("ip").Value;
            //         Console.WriteLine("file->"+ipfile);
            //    if (itemIP.Element("ipfile").Value == ip)
            //    {
            //        Console.WriteLine("запись!");
            //        itemIP.Element("State").Value = "1";
            //        itemIP.Element("DateTimePing").Value = DateTime.Now.ToString();
            //    }
            //}

            //2-вариант

            XDocument documentOut = XDocument.Load("Log.xml");
            

            var items = from item in documentOut.Descendants("id")
                        where item.Element("ip").Value == Message
                        select item;
            foreach (XElement itemElement in items)
            {
                //Console.WriteLine("запись!->"+Message+" Статус->"+Status);
                itemElement.SetElementValue("State",Status);
                itemElement.SetElementValue("DateTimePing", DateTime.Now.ToString());
            }
            documentOut.Save("Log.xml");
       
            #endregion
        }
        else
        {
        #region Запись лога в БД


            string strConnect = "";
            //string info = "";
            string BDname = "";
            netDKL net = new netDKL();//вызов конструктора класса netDKL
            strConnect = net.NetCheck(); //В зависимости от сети выбирается автоматически строка подключения

            using (SqlConnection connect = new SqlConnection(strConnect)) //Строка подключения
            {


                try
                {
                    #region Подключение к БД для поиска таблицы для пингов
                    connect.Open(); //Создаем соединение
                    string BDnameNow = "pingIP-" + DateTime.Today.ToShortDateString();
                    BDname = "pingIP-" + DateTime.Today.AddDays(1).ToShortDateString(); //База на следующий день


                    //string sqlCom2 = "select * from sys.tables where type_desc = 'USER_TABLE' and name = '"+ BDnameNow + "'";
                    string sqlCom2 = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" + BDname + "') SELECT 1 AS res ELSE SELECT 0 AS res";
                    SqlCommand sqlBD = new SqlCommand(sqlCom2, connect);
                    System.Data.SqlClient.SqlDataReader SQLRead = sqlBD.ExecuteReader();
                    while (SQLRead.Read())//считываем банные
                    {
                        //Console.WriteLine(SQLRead.GetValue(0));

                        //if (SQLRead.GetInt32(0) == 1)
                        //{
                        //    //Если True талица существует
                        //    Console.WriteLine("База существует!");
                        //}
                        //else 
                        int i = SQLRead.GetInt32(0);
                        if (SQLRead.GetInt32(0) == 0)
                        {
                            Console.WriteLine("Таблица на следующий день для пингов НЕ существует!");
                            #region создание новой таблицы на следующий день
                            using (SqlConnection connect3 = new SqlConnection(strConnect))
                            {
                                connect3.Open();
                                //string sqlCom3 = "CREATE TABLE [dbo].[IPLog0]([id] [int] IDENTITY(1,1) NOT NULL,[DateTimePing] [datetime] NOT NULL,[ip] [char](15) NOT NULL,[NameComp] [text] NULL,[description] [text] NULL,[Domain] [bit] NOT NULL,[State] [bit] NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];ALTER TABLE[dbo].[IPLog0] ADD CONSTRAINT[DF_IPLog0_DateTimePing]  DEFAULT(getdate()) FOR[DateTimePing]";
                                //string sqlCom3 = "CREATE TABLE [dbo].[" + BDname + "]([id] [int] IDENTITY(1,1) NOT NULL,[DateTimePing] [datetime] NOT NULL,[ip] [char](15) NOT NULL,[NameComp] [text] NULL,[description] [text] NULL,[Domain] [bit] NOT NULL,[State] [bit] NULL) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];ALTER TABLE[dbo].[" + BDname + "] ADD CONSTRAINT[DF_" + BDname + "_DateTimePing]  DEFAULT(getdate()) FOR[DateTimePing]";
                                string sqlCom3 = "CREATE TABLE[dbo].[" + BDname + "]([id][bigint] IDENTITY(1, 1) NOT NULL,[strIP] [ntext] NOT NULL,[dtPing] [datetime] NOT NULL,[bStatus] [bit] NULL, [biTime] [bigint] NULL) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]; ALTER TABLE[dbo].[" + BDname + "] ADD CONSTRAINT[DF_" + BDname + "_dtPing]  DEFAULT(getdate()) FOR[dtPing]";
                                SqlCommand sqlBD3 = new SqlCommand(sqlCom3, connect3);
                                int number = sqlBD3.ExecuteNonQuery();
                                if (number != 0) //Если создание таблицы произошло нормально то выводим сообщение
                                {
                                    Console.WriteLine("Таблица " + BDname + " успешно создана!");
                                }
                                else
                                {
                                    //Если таблица не создана то Диалоговое окно и выход из программы

                                    if (MessageBox.Show("База " + BDname + " не создана!", "Ошибка создания создания таблицы", MessageBoxButton.OK) == MessageBoxResult.OK)
                                    {
                                        System.Environment.Exit(0);
                                    }
                                }
                                connect3.Close();
                            }
                            #endregion
                        }
                    }
                    connect.Close();
                    #endregion
                    #region Сохраняем в БД состояния хостов
                    connect.Open();

                    //TODO В БД pingIP-(+текущий день)

                    long TimePing = 100 - TimeStatus;

                    string sqlCom = "INSERT INTO [dbo].[" + BDnameNow + "] (strIP, bStatus, biTime) VALUES('" + Message.Trim() + "', '" + Status + "', '" + TimePing + "')";
                    //Console.WriteLine(sqlCom);
                    SqlCommand sqlInsertMessage = new SqlCommand(sqlCom, connect);
                    int numberInsert = sqlInsertMessage.ExecuteNonQuery();
                    Console.WriteLine("Добавлено записей: {0}", numberInsert);
                    //writeLog(sqlCom); //Запись в лог файл

                    #endregion




                    //// Вывод информации о подключении
                    ////Console.WriteLine("Свойства подключения:");
                    ////Console.WriteLine("\tСтрока подключения: {0}", connect.ConnectionString);
                    ////Console.WriteLine("\tБаза данных: {0}", connect.Database);
                    ////Console.WriteLine("\tСервер: {0}", connect.DataSource);
                    ////Console.WriteLine("\tВерсия сервера: {0}", connect.ServerVersion);
                    ////Console.WriteLine("\tСостояние: {0}", connect.State);
                    ////Console.WriteLine("\tWorkstationld: {0}", connect.WorkstationId);
                    //string WorkId = connect.WorkstationId;

                    //string sqlCom = "UPDATE IPLog Set State=" + Status + ", DateTimePing=CURRENT_TIMESTAMP where ip='" + ip + "'";
                    //SqlCommand sqlInsertMessage = new SqlCommand(sqlCom, connect);
                    //int number = sqlInsertMessage.ExecuteNonQuery();
                    //if (number==0)//Если обновление не прошло(такого ip нет в БД), то производим вставку новой строки с новым ip
                    //{
                    //    sqlCom= "INSERT INTO IPLog(ip, State) VALUES('" + ip + "', '" + Status + "')";
                    //    sqlInsertMessage = new SqlCommand(sqlCom, connect);
                    //    int numberInsert = sqlInsertMessage.ExecuteNonQuery();
                    //    Console.WriteLine("Добавлено записей: {0}", numberInsert);

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Обновлено записей: {0}", number);
                    //}

                }
                catch (Exception err)
                {
                    #region В случае с ошибкой подключения БД скидываем сообщения в файл 
                    //Если не удачно то записываем в локальный файл
                    DateTime currenttime = DateTime.Now;
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"SQLlogERROR.txt", true))
                    {
                        string tmptxt = String.Format("{0:yyMMdd HH:mm:ss} {1}", currenttime, err);
                        file.WriteLine(tmptxt);
                        file.Close();
                    }
                    #endregion
                }
                finally
                {
                    #region Закрываем подключение к БД в любом случае
                    // закрываем подключение
                    connect.Close();
                    //Console.WriteLine("Подключение закрыто...");
                    #endregion

                }

            }
            #endregion
        }
    }

    public static void writeLog(string message)
    {
        try
        {
            //Если не удачно то записываем в локальный файл
            DateTime currenttime = DateTime.Now;
            string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "TaskManLog.txt";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathProg, true))
            {
                string tmptxt = String.Format("{0:dd.MM.yyyy HH:mm:ss} {1}", currenttime, message);
                file.WriteLine(tmptxt);
                file.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            
        }
        
        
    }
}





