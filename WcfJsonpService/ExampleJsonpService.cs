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

namespace PVIB
{


    public class PVIBJsonpService : IPVIBJsonpService
    {
        public string GetWithOne(string input)
        {
            return String.Format("The (jsonp) input string was: {0}", input);
        }

        public string GetWithTwo(string input1, string input2)
        {
            return String.Format("(jsonp) Input one: {0}, Input two: {1}", input1, input2);
        }

        public bool mkservice(string srvname)
        {
            Service srv = new Service(srvname);
            srv.Connect();
            Program.ServList.Add(srvname,srv);
            return true;
        }

        public bool connect_cpu_tcpip(string srvname, string ip, int port, string cpuname)
        {
            return true;
        }

        public bool watch_var(string srvname, string cpuname, string varname)
        {
            return true;
        }

        public string get_var(string srvname, string cpuname, string varname) 
        {
            return "";
        }

        public bool set_var(string srvname, string cpuname, string varname, object varval) 
        {
            return true;
        }
    }
}