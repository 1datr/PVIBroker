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

        private WebServiceHost serviceHost;
        public static PVITree_Root Root;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            cpuWatcher1.Activate();
            backgroundWorker1.RunWorkerAsync();
            Root = new PVITree_Root();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serviceHost.Close();
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

        private void cpuWatcher1_OnChangeVar(Variable var)
        {
            propGrid1.PrintProperty(var.Name, var.Value);
            if (Varlist == null)
            {
                Varlist = new Dictionary<string, Variable>();
            }
            if (Changed == null)
            {
                Changed = new Dictionary<string, bool>();
            }
            String varidx = cpuWatcher1.Srvname+ "_"+var.Name.ToString();

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
            Application.Exit();
        }
    }
}
