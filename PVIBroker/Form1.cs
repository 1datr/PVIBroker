using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel.Web;
using BR.AN.PviServices;
using BR.AN;
using LibPVITree;
using Broker;

namespace PVIBroker
{   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            serviceHost = new WebServiceHost(typeof(PVIBJsonpService));
            serviceHost.Open();
        }

        public static Dictionary<String,PVIBCommand> QConnQueries;  // Очередь заявок 
        public static Dictionary<String, ClientInfo> Hosters; // Словарь клиентов-основателей сервисов
        private WebServiceHost serviceHost;
        public static PVITree_Root Root;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            /*
            cpuWatcher1.Activate();*/
            backgroundWorker1.RunWorkerAsync();
            Varlist = new Dictionary<string, Variable>();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            
        }

        static void service_Connected(object sender, PviEventArgs e)
        {

        }

        static void Error(object sender, PviEventArgs e)
        {
           
        }

        public static Variable GetVar(String varname)
        {
            return null;
        }

        public static Dictionary<string, Variable> Varlist;
        public static Dictionary<string, bool> Changed; // изменилось значение

        private void cpuWatcher1_OnChangeVar(Variable var,string servname)
        {
            first_start = false;
            propGrid1.PrintProperty(var.Name, var.Value.ToString());
            if (Varlist == null)
            {
                Varlist = new Dictionary<string, Variable>();
            }
            if (Changed == null)
            {
                Changed = new Dictionary<string, bool>();
            }
            String varidx = servname + "_" + var.Name.ToString();

            if (Varlist.ContainsKey(varidx))
                Varlist[varidx] = var;
            else
                Varlist.Add(varidx, var);

            if (Changed.ContainsKey(varidx))
                Changed[varidx] = true;
            else
                Changed.Add(varidx, true);
        }

        private void входToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeapp = true;
            Application.Exit();
        }

        private Dictionary<String, int> watchers;
        // добавить CPUWatcher
        private bool addCPUWatcher_TCPIP(PVIBCommand cmd,string srvname, string ip, int port)
        {
            if (watchers == null) watchers = new Dictionary<string, int>();
            if (watchers.ContainsKey(srvname)) return false;
            CPUWatcher w = new CPUWatcher();
            w.IP = ip;
            w.Port = port;
            w.Srvname = srvname;
            w.SubsPage = cmd.SubsUrl;
            w.OnChangeVar += new OnVarChange(cpuWatcher1_OnChangeVar);
            w.OnCPUConnect += new OnCPUConnect(this.cpuWatcher1_OnCPUConnect);
            w.OnCPUConnectError += new OnCPUConnectError(this.cpuWatcher1_OnCPUConnectError);
            components.Add(w);
            w.Activate();
            watchers.Add(srvname, components.Components.Count - 1);
            if (Hosters == null) Hosters = new Dictionary<string, ClientInfo>();
            Hosters.Add(cmd.servname, cmd.clientinfo);
            return true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private bool closeapp = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            notifyIcon1.Visible = true;
            if(!closeapp)
                e.Cancel = true;
        }
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeapp = true;
            Application.Exit();
        }

        private Boolean first_start = true;
        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            if (first_start)
            { 
                
                this.Hide();
                first_start = false;
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutPVIBrokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void aboutPVIBrokerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //addCPUWatcher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        public bool EndService(String servname)
        {
            return true;
        }
        private static List<String> MessList;
        public static void AddMess(String mes)
        {
            if(MessList==null) MessList = new List<string>();
            MessList.Add(mes);
        }

        private void DrawMessBuff()
        {
            lock(this){
            if (MessList != null)
            {
                foreach (string mess in MessList)
                {
                    tbConsole.Text = tbConsole.Text + mess + "\r\n";
                }
                MessList.Clear();
            }
            }
        }
        // Таймер. По таймеру обрабатываются основные команды
        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawMessBuff();
            if (QConnQueries == null) QConnQueries = new Dictionary<string, PVIBCommand>();
            if (QConnQueries.Count == 0) return;
            string lastkey = "";           
            foreach(var k in QConnQueries.Keys.Reverse()) {
                lastkey = k;
            }
            PVIBCommand cmd = QConnQueries[lastkey];
            CPUWatcher w = null;
            switch (cmd.cmdtype)
            {
                case "addservice":
                    addCPUWatcher_TCPIP(cmd,cmd.servname, cmd.TcpIpSettings.DestinationIpAddress, cmd.TcpIpSettings.DestinationPort);
                    QConnQueries.Remove(lastkey);
                    tbConsole.Text = tbConsole.Text + "\r\n" + "Added service " + cmd.servname;
                    break;
                case "addvar":
                    if (!watchers.ContainsKey(cmd.servname)) break;
                    w = (CPUWatcher)this.components.Components[this.watchers[cmd.servname]];
                    if (w.isConnected)
                    {
                        w.AddVar(cmd.varname);
                        tbConsole.Text = tbConsole.Text + "\r\n" + "Added variable "+cmd.varname+" to service "+cmd.servname;
                        QConnQueries.Remove(lastkey);
                    }
                    break;
                case "endservice":
                    if (!watchers.ContainsKey(cmd.servname)) break;
                    int watcher_idx = watchers[cmd.servname];
                    w = (CPUWatcher)this.components.Components[watcher_idx];               
                    //w.Dispose();
                    this.components.Remove(w);
                    watchers.Remove(cmd.servname);
                    QConnQueries.Remove(lastkey);
                    tbConsole.Text = tbConsole.Text + "\n\r" + "Aborted service " + cmd.servname;
                    // надо чтобы менялись номера в watches
                    break;
            }

            
        }
        public static Dictionary<string, int> ConnStatus;
        private void cpuWatcher1_OnCPUConnect(CPUWatcher w, string servname)
        {
            if (ConnStatus == null)
                ConnStatus = new Dictionary<string, int>();
            if (ConnStatus.ContainsKey(servname))
                ConnStatus[servname] = 0;
            else
                ConnStatus.Add(servname, 0);
        }

        private void cpuWatcher1_OnCPUConnectError(CPUWatcher w, string servname, int Errcode)
        {
            if (ConnStatus == null)
                ConnStatus = new Dictionary<string, int>();
            if (ConnStatus.ContainsKey(servname))
                ConnStatus[servname] = Errcode;
            else
                ConnStatus.Add(servname, Errcode);
        }
        
        
    }
}
