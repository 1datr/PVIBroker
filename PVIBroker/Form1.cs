using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.ServiceModel.Web;
using BR.AN.PviServices;
using BR.AN;

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
            using (var serviceHost = new WebServiceHost(typeof(PVIBJsonpService)))
            {
                serviceHost.Open();

             /*   Console.WriteLine("WCF REST JSONP service is running...");
                Console.ReadLine();
                */
                serviceHost.Close();
            }
        }

        private WebServiceHost serviceHost;
        public static Dictionary<String, Service> ServList;

        private void Form1_Load(object sender, System.EventArgs e)
        {
           // backgroundWorker1.RunWorkerAsync();
            ServList = new Dictionary<string, Service>();
            serviceHost = new WebServiceHost(typeof(PVIBJsonpService));
            serviceHost.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serviceHost.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
