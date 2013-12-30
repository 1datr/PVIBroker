using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BR.AN.PviServices;
using BR.AN;


namespace LibPVITree
{
    public class PVITree_Service
    {
        private Dictionary<String,Cpu> CPUList;
        private bool wait_connect = false;
        private Service service;
        private int Errcode;

        public PVITree_Service(String servname)
        {
            this.service = new Service(servname);
            this.service.Error += new PviEventHandler(Error);
            this.service.Connected += new PviEventHandler(service_Connected);
        }

        public bool Connected()
        {
            return !wait_connect;
        }

        public void Connect()
        {
            wait_connect = true;
            
            
            service.Connect();
        }

        private void Error(object sender, PviEventArgs e)
        {
            wait_connect = false;
            Errcode = e.ErrorCode;
        }

        private void service_Connected(object sender, PviEventArgs e)
        {
            wait_connect = false;
            Errcode = 0;
        }

        public int ErrorCode()
        {
            return Errcode;
        }
    }
}
