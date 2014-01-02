//Copyright 2011 Jared Faris

//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at

//    http://www.apache.org/licenses/LICENSE-2.0

//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.
using System;
using BR.AN.PviServices;
using BR.AN;
using LibPVITree;

namespace PVIBroker
{
    public class PVIBJsonpService : IPVIBJsonpService
    {
        private bool wait_connect = false;
        
        public int mkservice(string srvname)
        {
            Form1.Root.addService(srvname);
            return 0;
        }

        public int connect_cpu_tcpip(string srvname, string ip, int port, string cpuname)
        {
            /*Cpu cpu = new Cpu(Form1.ServList[srvname],cpuname);
            cpu.Connection.DeviceType = DeviceType.TcpIp;
            cpu.Connection.TcpIp.DestinationIpAddress = ip;
            cpu.Connection.TcpIp.DestinationPort = short.Parse(port.ToString());
            cpu.Connect();*/
            return 0;
        }

        public int watch_var(string srvname, string cpuname, string varname)
        {
            return 0;
        }

        public string get_var(string srvname, string varname) 
        {
            if (Form1.Varlist.ContainsKey(srvname + "_" + varname))
                return Form1.Varlist[srvname + "_" + varname].Value.ToString();
            else
                return null;
        }

        public int set_var(string srvname, string varname, string varval) 
        {
            if (Form1.Varlist.ContainsKey(srvname + "_" + varname))
            {                
                //Form1.Varlist[srvname + "_" + varname].Value = varval;
             //   Form1.Varlist[srvname + "_" + varname].IECDataType == IECDataTypes.
                object obj = null;
                switch (Form1.Varlist[srvname + "_" + varname].Value.DataType)
                {
                    case DataType.Boolean: break;
                    case DataType.Byte: break;
                    case DataType.Data: break;
                    case DataType.Date: break;
                    case DataType.DateTime: break;
                    case DataType.Double: break;
                    case DataType.DT: break;
                    case DataType.DWORD: break;
                    case DataType.Int16: break;
                    case DataType.Int32: break;
                    case DataType.Int64: break;
                    case DataType.LWORD: break;
                    case DataType.SByte: break;
                    case DataType.Single: break;
                    case DataType.String: break;
                    case DataType.TimeOfDay: break;
                    case DataType.TimeSpan: break;
                    case DataType.TOD: break;
                    case DataType.UInt16:
                        obj = System.Convert.ToInt16(varval);
                        break;
                    case DataType.UInt32:
                        obj = System.Convert.ToInt32(varval);
                        break;
                    case DataType.UInt64:
                        obj = System.Convert.ToInt64(varval);
                        break;
                    case DataType.UInt8:
                        obj = uint.Parse(varval);
                        break;
                    case DataType.WORD:
                        obj = System.Convert.ToInt32(varval);
                        break;
                    case DataType.WString: break;
                }
                Form1.Varlist[srvname + "_" + varname].Value = new Value(obj);
            }
            else
                return -1;
            return 0;
        }

        void Error(object sender, PviEventArgs e)
        {
            wait_connect = false;
        }

        void service_Connected(object sender, PviEventArgs e)
        {
            wait_connect = false;
        }
    }
}