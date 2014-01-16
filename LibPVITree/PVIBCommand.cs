using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BR.AN.PviServices;

namespace LibPVITree
{
    public class ClientInfo 
    {
        public string ip { get; set; }
        public int port { get; set; }
    }

    public class PVIBCommand
    {
        public String cmdtype = "addservice";   // тип команды
        public String servname;                 // имя сервиса - для команды добавления сервиса
        public String varname;                  // имя переменной - для команды добавления переменной
        public TcpIp TcpIpSettings;             // 
        public Serial SerialSettings;

        public ClientInfo clientinfo;           // данные о клиенте
    }
}
