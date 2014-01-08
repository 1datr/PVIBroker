using BR.AN.PviServices;
using System.Collections.Generic;
using System.ComponentModel;

namespace Broker
{
    public delegate void OnVarChange(Variable var, string servname);

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
           // Console.WriteLine(String.Format("Error:{0}", e.ErrorText));
            //Application.Exit();
        }

        /// <summary>
        /// Write variable value to the console
        /// </summary>
        void ValueChanged(object sender, VariableEventArgs e)
        {
            if(OnChangeVar_hndlr!=null)
                OnChangeVar_hndlr((Variable)sender,this.Srvname);
          /*  Variable var = (Variable)sender;
            Console.WriteLine("Value={0}", var.Value.ToString());
            Application.Exit();*/
        }

        void service_Connected(object sender, PviEventArgs e)
        {
           // Console.WriteLine("Service Connected Error=" + e.ErrorCode.ToString());
            if(cpu==null)
                cpu = new Cpu(service, "Cpu");
            //cpu.Connection.DeviceType = DeviceType.Serial;
            cpu.Connection.DeviceType = DeviceType.TcpIp;
            cpu.Connection.TcpIp.DestinationIpAddress = "127.0.0.1";
            cpu.Connection.TcpIp.DestinationPort = 11160;
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
            f_connected = false;
            
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

        public void Activate()
        {
            service = new Service(this.fSrvname);
            service.Error += new PviEventHandler(Error);
            service.Connected += new PviEventHandler(service_Connected);
            service.Connect();
        }

        private OnVarChange OnChangeVar_hndlr;
        [DisplayName("При изменении переменных")]
        [Description("Если значение изменилось")]
        public event OnVarChange OnChangeVar
        {
            add { lock (this) { OnChangeVar_hndlr += value; } }
            remove { lock (this) { OnChangeVar_hndlr -= value; } }
        }

        #endregion
    }
}
