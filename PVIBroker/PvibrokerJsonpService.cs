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
using System.Collections.Generic;
using System.Web.Script.Serialization;
using LibPVITree;

namespace PVIBroker
{
    public class PVIBJsonpService : IPVIBJsonpService
    {
        private bool wait_connect = false;
        
        public bool mkserv_tcpip(string srvname, string ip, int port)
        {
            // инициализировать очередь команд
            if (Form1.QConnQueries == null)
                Form1.QConnQueries = new Dictionary<string, LibPVITree.PVIBCommand>();
            if (Form1.QConnQueries.ContainsKey(srvname)) return false;
            PVIBCommand pvibc = new LibPVITree.PVIBCommand();
            pvibc.TcpIpSettings = new TcpIp();
            pvibc.TcpIpSettings.DestinationIpAddress = ip;
            pvibc.TcpIpSettings.DestinationPort = short.Parse(port.ToString());
            pvibc.servname = srvname;            
            Form1.QConnQueries.Add(srvname, pvibc);
            return true;
        }

        public bool mkserv_com(string srvname, string ip, int port)
        {
            // инициализировать очередь команд
            if (Form1.QConnQueries == null)
                Form1.QConnQueries = new Dictionary<string, LibPVITree.PVIBCommand>();
            if (Form1.QConnQueries.ContainsKey(srvname)) return false;
            PVIBCommand pvibc = new LibPVITree.PVIBCommand();
            
            pvibc.TcpIpSettings.DestinationIpAddress = ip;
            pvibc.TcpIpSettings.DestinationPort = short.Parse(port.ToString());
            pvibc.servname = srvname;
            Form1.QConnQueries.Add(srvname, pvibc);
            return true;
        }

        public int watch_var(string srvname, string varname)
        {
            PVIBCommand pvibc = new LibPVITree.PVIBCommand();
            pvibc.cmdtype = "addvar";
            pvibc.varname = varname;
            pvibc.servname = srvname;
            Form1.QConnQueries.Add(srvname+"."+varname, pvibc);
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

        private object GetVar(Variable V)
        {
            Object obj = null;
            switch (V.Value.DataType)
                {
                    case DataType.Boolean:
                        obj = System.Convert.ToBoolean(V.Value.ToString());
                        break;
                    case DataType.Byte:
                        obj = System.Convert.ToByte(V.Value.ToString());
                        break;
                    case DataType.Data: break;
                    case DataType.Date:
                        obj = DateTime.Parse(V.Value.ToString());
                        break;
                    case DataType.DateTime:
                        obj = System.Convert.ToDateTime(V.Value.ToString());
                        break;
                    case DataType.Double:
                        obj = System.Convert.ToDouble(V.Value.ToString());
                        break;
                    case DataType.DT: break;
                    case DataType.DWORD: 
                        
                        break;
                    case DataType.Int16:
                        obj = System.Convert.ToInt16(V.Value.ToString());
                        break;
                    case DataType.Int32:
                        obj = System.Convert.ToInt32(V.Value.ToString());
                        break;
                    case DataType.Int64:
                        obj = System.Convert.ToInt64(V.Value.ToString());
                        break;
                    case DataType.LWORD:
                        obj = long.Parse(V.Value.ToString());
                        break;
                    case DataType.SByte:
                        obj = System.Convert.ToSByte(V.Value.ToString());
                        break;
                    case DataType.Single:
                        obj = System.Convert.ToSingle(V.Value.ToString());
                        break;
                    case DataType.String:
                        obj = V.Value.ToString();
                        break;
                    case DataType.TimeOfDay: break;
                    case DataType.TimeSpan: break;
                    case DataType.TOD: break;
                    case DataType.UInt16:
                        obj = System.Convert.ToUInt16(V.Value.ToString());
                        break;
                    case DataType.UInt32:
                        obj = System.Convert.ToUInt32(V.Value.ToString());
                        break;
                    case DataType.UInt64:
                        obj = System.Convert.ToUInt64(V.Value.ToString());
                        break;
                    case DataType.UInt8:
                        obj = uint.Parse(V.Value.ToString());
                        break;
                    case DataType.WORD:
                        obj = System.Convert.ToInt32(V.Value.ToString());
                        break;
                    case DataType.WString: break;
                }
            return obj;
        }

        //public Dictionary<String, PVIVariable> var_list(string srvname)
        public String var_list(string srvname)
        {
            Dictionary<String, PVIVariable> vars = new Dictionary<string, PVIVariable>();
            foreach (KeyValuePair<string, Variable> kvp in Form1.Varlist)
            {
                PVIVariable v = new PVIVariable();
                String varname = kvp.Key.Substring(srvname.Length + 2);
                if (kvp.Key.Substring(0, srvname.Length + 1) == srvname + "_")
                {
                    v.value = this.GetVar(kvp.Value);
                    v.changed = Form1.Changed[kvp.Key];
                    v.name = varname;
                }
                vars.Add(varname, v);
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(vars);
            //return vars;
        }

        public String varchanged(string srvname)
        {
            Dictionary<String, PVIVariable> vars = new Dictionary<string, PVIVariable>();
            foreach (KeyValuePair<string, Variable> kvp in Form1.Varlist)
            {
                
                if (kvp.Key.Substring(0, srvname.Length + 1) == srvname + "_")
                {
                    if (Form1.Changed[kvp.Key])
                    {
                        String varname = kvp.Key.Substring(srvname.Length + 2);
                        PVIVariable v = new PVIVariable();
                        v.value = this.GetVar(kvp.Value);
                        v.name = varname;
                        v.changed = Form1.Changed[kvp.Key];
                        Form1.Changed[kvp.Key] = false;
                        vars.Add(varname, v);
                    }
                }
                
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(vars);
        }
    }
}