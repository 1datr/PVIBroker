using BR.AN.PviServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Web;



namespace Broker
{
    public delegate void OnVarChange(Variable var, string servname);
    public delegate void OnServiceConnect(CPUWatcher w, string servname);
    public delegate void OnCPUConnect(CPUWatcher w, string servname);
    public delegate void OnCPUConnectError(CPUWatcher w, string servname, int Errcode);

    partial class CPUWatcher
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        /// 
        void Error(object sender, PviEventArgs e)
        {
            // отчитаться субскрайберу о коннекте
            if (this.SubsPage != "")
            {
                WebRequest reqPOST = System.Net.WebRequest.Create(this.SubsPage);
                reqPOST.Method = "POST"; // Устанавливаем метод передачи данных в POST
                reqPOST.Timeout = 120000; // Устанавливаем таймаут соединения
                reqPOST.ContentType = "application/x-www-form-urlencoded"; // указываем тип контента
                // передаем список пар параметров / значений для запрашиваемого скрипта методом POST
                // здесь используется кодировка cp1251 для кодирования кирилицы и спец. символов в значениях параметров
                // Если скрипт должен принимать данные в utf-8, то нужно выбрать Encodinf.UTF8
                byte[] sentData = Encoding.GetEncoding(1251).GetBytes("service=" + this.Srvname + "&result=" + e.ErrorCode + ":" + e.ErrorText + "&event=srv_connection_error");
                reqPOST.ContentLength = sentData.Length;
                System.IO.Stream sendStream = reqPOST.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }
        }

        /// <summary>
        /// Write variable value to the console
        /// </summary>
        void ValueChanged(object sender, VariableEventArgs e)
        {
            // отчитаться субскрайберу о коннекте
            if (this.SubsPage != "")
            {
                WebRequest reqPOST = System.Net.WebRequest.Create(this.SubsPage);
                reqPOST.Method = "POST"; // Устанавливаем метод передачи данных в POST
                reqPOST.Timeout = 120000; // Устанавливаем таймаут соединения
                reqPOST.ContentType = "application/x-www-form-urlencoded"; // указываем тип контента
                // передаем список пар параметров / значений для запрашиваемого скрипта методом POST
                // здесь используется кодировка cp1251 для кодирования кирилицы и спец. символов в значениях параметров
                // Если скрипт должен принимать данные в utf-8, то нужно выбрать Encodinf.UTF8
                Variable Var = (Variable)sender;
                byte[] sentData = Encoding.GetEncoding(1251).GetBytes("service=" + this.Srvname + "&varname=" + Var.Name + "&value="+Var.Value.ToString()+"&event=srv_var_changed");
                reqPOST.ContentLength = sentData.Length;
                System.IO.Stream sendStream = reqPOST.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }
            if(OnChangeVar_hndlr!=null)
                OnChangeVar_hndlr((Variable)sender,this.Srvname);
          /*  Variable var = (Variable)sender;
            Console.WriteLine("Value={0}", var.Value.ToString());
            Application.Exit();*/
        }

        [DisplayName("Сервер подписки")]
        [Description("Куда отправлять подписные сообщения")]
        public string SubsPage { get; set; }

        void service_Connected(object sender, PviEventArgs e)
        {
            if ((this.SubsPage != "")&&(e.ErrorCode==0))
            {
                WebRequest reqPOST = System.Net.WebRequest.Create(this.SubsPage);
                reqPOST.Method = "POST"; // Устанавливаем метод передачи данных в POST
                reqPOST.Timeout = 120000; // Устанавливаем таймаут соединения
                reqPOST.ContentType = "application/x-www-form-urlencoded"; // указываем тип контента
                // передаем список пар параметров / значений для запрашиваемого скрипта методом POST
                // здесь используется кодировка cp1251 для кодирования кирилицы и спец. символов в значениях параметров
                // Если скрипт должен принимать данные в utf-8, то нужно выбрать Encodinf.UTF8
                byte[] sentData = Encoding.GetEncoding(1251).GetBytes("service="+this.Srvname+"&result="+e.ErrorCode+"&event=service_connected");
                reqPOST.ContentLength = sentData.Length;
                System.IO.Stream sendStream = reqPOST.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }
           // Console.WriteLine("Service Connected Error=" + e.ErrorCode.ToString());
            if(cpu==null)
                cpu = new Cpu(service, "Cpu");
            //cpu.Connection.DeviceType = DeviceType.Serial;
            cpu.Connection.DeviceType = DeviceType.TcpIp;
            cpu.Connection.TcpIp.DestinationIpAddress = this.IP;
            cpu.Connection.TcpIp.DestinationPort = short.Parse(this.Port.ToString());
            //cpu.Connection.Serial.Channel = 1;
            cpu.Connected += new PviEventHandler(cpu_Connected);
            cpu.Error += new PviEventHandler(cpu_Error);
            //Console.WriteLine("Connecting Cpu ...");
            cpu.Connect();
        }

        [DisplayName("Переменные")]
        [Description("Список переменных")]
        public string[] VarNames { get; set; }

        public Dictionary<string, Variable> VarDict;
        void cpu_Connected(object sender, PviEventArgs e)
        {
            // отчитаться субскрайберу о коннекте
            if ((this.SubsPage != "")&&(e.ErrorCode==0))
            {
                WebRequest reqPOST = System.Net.WebRequest.Create(this.SubsPage);
                reqPOST.Method = "POST"; // Устанавливаем метод передачи данных в POST
                reqPOST.Timeout = 120000; // Устанавливаем таймаут соединения
                reqPOST.ContentType = "application/x-www-form-urlencoded"; // указываем тип контента
                // передаем список пар параметров / значений для запрашиваемого скрипта методом POST
                // здесь используется кодировка cp1251 для кодирования кирилицы и спец. символов в значениях параметров
                // Если скрипт должен принимать данные в utf-8, то нужно выбрать Encodinf.UTF8
                byte[] sentData = Encoding.GetEncoding(1251).GetBytes("service=" + this.Srvname + "&result=" + e.ErrorCode + "&event=cpu_connected");
                reqPOST.ContentLength = sentData.Length;
                System.IO.Stream sendStream = reqPOST.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }

            if (e.ErrorCode > 0) return;
            if (this.OnCPUConnect_hndlr != null)
                this.OnCPUConnect_hndlr(this, this.Srvname);
            f_connected = true;
            VarDict = new Dictionary<string,Variable>();
            if(VarNames!=null)
            foreach(string varname in VarNames)
            {
                Variable variable = new Variable(cpu, varname);
                variable.Active = true;
                variable.ValueChanged += new VariableEventHandler(ValueChanged);
             //   variable.Connected += new PviEventHandler(variable_Connected);
               // Console.WriteLine("Connecting Variable ...");
                VarDict.Add(varname,variable);
                variable.Connect();            
            }
        }

        void cpu_Error(object sender, PviEventArgs e)
        {
            // отчитаться субскрайберу о коннекте
            if (this.SubsPage != "")
            {
                WebRequest reqPOST = System.Net.WebRequest.Create(this.SubsPage);
                reqPOST.Method = "POST"; // Устанавливаем метод передачи данных в POST
                reqPOST.Timeout = 120000; // Устанавливаем таймаут соединения
                reqPOST.ContentType = "application/x-www-form-urlencoded"; // указываем тип контента
                // передаем список пар параметров / значений для запрашиваемого скрипта методом POST
                // здесь используется кодировка cp1251 для кодирования кирилицы и спец. символов в значениях параметров
                // Если скрипт должен принимать данные в utf-8, то нужно выбрать Encodinf.UTF8
                byte[] sentData = Encoding.GetEncoding(1251).GetBytes("service=" + this.Srvname + "&result=" + e.ErrorCode + ":" + e.ErrorText + "&event=cpu_connection_error");
                reqPOST.ContentLength = sentData.Length;
                System.IO.Stream sendStream = reqPOST.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }

            f_connected = false;
            if (this.OnCPUConnectError_hndlr!=null)
                this.OnCPUConnectError_hndlr(this, this.Srvname, e.ErrorCode);
        }

        private bool f_connected = false;
        // есть коннект с ПЛК
        public bool isConnected 
        {
            get {
                return f_connected;
            }
        }

        public int AddVar(string varname)
        {
            Variable variable = new Variable(cpu, varname);
            variable.Active = true;
            variable.ValueChanged += new VariableEventHandler(ValueChanged);
            //   variable.Connected += new PviEventHandler(variable_Connected);
            // Console.WriteLine("Connecting Variable ...");
            if (VarDict.ContainsKey(varname)) return 1;
            VarDict.Add(varname, variable);
            variable.Connect();
            return 0;
        }

        private Cpu cpu;

        
        private string fIP;
        [DisplayName("IP")]
        [Description("IP CPU")]
        public string IP { get { return fIP; } set { fIP = value; } }
        
        private int fPort;
        [DisplayName("Порт")]
        [Description("Порт CPU")]
        public int Port { get { return fPort; } set { fPort = value; } }

        private string fSrvname;
        [DisplayName("Сервис")]
        [Description("Имя сервиса")]
        
        public string Srvname { get { return fSrvname; } set { fSrvname = value; } }

        Service service;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            /*
            if (!this.DesignMode)
            {
                
            }*/
        }
        // Выполнить цепочку подключению
        public void Activate()
        {
            if (service != null)
            {
                //service.Disconnect();
            }
            else
            {
                service = new Service(this.fSrvname);
                service.Error += new PviEventHandler(Error);
                service.Connected += new PviEventHandler(service_Connected);
            }
            if (!service.IsConnected)
                service.Connect();
            else
            {
                service.RefreshPviClientsList();

                if (cpu == null)
                    cpu = new Cpu(service, "Cpu");
                    //cpu.Connection.DeviceType = DeviceType.Serial;
                cpu.Connection.DeviceType = DeviceType.TcpIp;
                cpu.Connection.TcpIp.DestinationIpAddress = this.IP;
                cpu.Connection.TcpIp.DestinationPort = short.Parse(this.Port.ToString());
                    //cpu.Connection.Serial.Channel = 1;
                cpu.Connected += new PviEventHandler(cpu_Connected);
                cpu.Error += new PviEventHandler(cpu_Error);

                //Console.WriteLine("Connecting Cpu ...");
                cpu.Connect();
            }
        }

        private OnVarChange OnChangeVar_hndlr;
        [DisplayName("При изменении переменных")]
        [Description("Если значение изменилось")]
        public event OnVarChange OnChangeVar
        {
            add { lock (this) { OnChangeVar_hndlr += value; } }
            remove { lock (this) { OnChangeVar_hndlr -= value; } }
        }

        private OnServiceConnect OnServiceConnect_hndlr;
        [DisplayName("При коннекте к PVIMonitor")]
        [Description("Если окончательно сконнектилось с PVIMonitor")]
        public event OnServiceConnect OnServiceConnect
        { 
            add { lock (this) { OnServiceConnect_hndlr += value; } }
            remove { lock (this) { OnServiceConnect_hndlr -= value; } }
        }

        private OnCPUConnect OnCPUConnect_hndlr;
        [DisplayName("При коннекте к CPU")]
        [Description("Если окончательно сконнектилось с ЦПУ")]
        public event OnCPUConnect OnCPUConnect
        {
            add { lock (this) { OnCPUConnect_hndlr += value; } }
            remove { lock (this) { OnCPUConnect_hndlr -= value; } }
        }

        private OnCPUConnectError OnCPUConnectError_hndlr;
        [DisplayName("При ошибке коннекта с CPU")]
        [Description("Если произошла ошибка при коннекте с ЦПУ")]
        public event OnCPUConnectError OnCPUConnectError
        {
            add { lock (this) { OnCPUConnectError_hndlr += value; } }
            remove { lock (this) { OnCPUConnectError_hndlr -= value; } }
        }

        #endregion
    }
}
