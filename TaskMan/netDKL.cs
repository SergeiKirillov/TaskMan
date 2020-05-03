using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets; //Для теста порта сети


class netDKL
    {
        public netDKL()
        {

        }


        public string NetCheck()
        {
            log logError = new log();

               
            //Получение имени компьютера--------------------------------------------------------------------------------------------------
            string host = System.Net.Dns.GetHostName();
                //Получение IP адреса
                System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                string[] IpHERE;
                IpHERE = ip.ToString().Split(new char[] { '.' }, 4);
                int IPnet1 = Int32.Parse(IpHERE[0].ToString());
                int IPnet2 = Int32.Parse(IpHERE[1].ToString());
                int IPnet3 = Int32.Parse(IpHERE[2].ToString());

        //Анализиуем сеть 
        if (IPnet1 == 10)    //Если доменная сеть, то строка подключения для доменной сети
        {
            if (TestForServer("10.21.168.42", 1433))
            {
                //return 1;
                return @"server=10.21.168.42;uid=log;pwd=159951;database=log";
            }
            else
            {
                log.writeLog("Соединение с базой в Домене отсутствует"); //в случае отсутствия соединения с БД записываем сообщение в текстовый файл
                //MessageBox.Show("Соединение с базой в Домене отсутствует", "Ошибка подключения к БД");
                //System.Environment.Exit(0); //В случае отсутствия соединения с БД выходим из программы
                return "";
            }

        }
        else if ((IPnet2 == 168) && (IPnet3 == 0))
        {
            //return 2;
            if (TestForServer("192.168.0.46", 1433))
            {
                //return 1;
                return @"server=192.168.0.46;uid=log;pwd=159951;database = log";
            }
            else if ((IPnet2 == 168) && (IPnet3 == 1))
            {
                if (TestForServer("localhost", 1433))
                {
                    //MessageBox.Show("Соединение с базой в Контролерной сети отсутствует. Подключаемся к локальной БД.", "Ошибка подключения к БД");
                    return @"server=OPC;uid=sa;pwd=159951";
                }
                else
                {
                    log.writeLog("Соединение с ЛОКАЛЬНОЙ базой отсутствует");
                    System.Environment.Exit(0);
                    return "";
                }
            }
            else
            {
                log.writeLog("Соединение с базой в cети отсутствует. IP не входит не в одну группу("+ip.ToString()+")");;

                //MessageBox.Show("Соединение с базой в cети отсутствует.", "Ошибка подключения к БД");
                System.Environment.Exit(0);
                return "";
            }
        }
        else
        {
            log.writeLog("Соединение с базой в cети отсутствует. IP не входит не в одну группу ("+ip.ToString()+")");
            //MessageBox.Show("Соединение с базой в cети отсутствует.", "Ошибка подключения к БД");
            System.Environment.Exit(0);
            return "";
        }
        
    }
   private bool TestForServer(string adress, int port)
    {
        int timeout = 500;
        var result = false;
        try
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IAsyncResult asyncResult = socket.BeginConnect(adress, port, null, null);
                result = asyncResult.AsyncWaitHandle.WaitOne(timeout, true);
                socket.Close();
            }
            return result;
        }
        catch
        {
            return false;
        }
    }
}

