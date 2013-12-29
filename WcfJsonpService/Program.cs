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
using System.Windows.Forms; 
using System.ServiceModel.Web;
using BR.AN.PviServices;
using BR.AN;
using System.Threading;

namespace WcfJsonpService
{   
    class Program
    {
        static private Thread ServerThread;

        static void ListenClient()
        {
            using (var serviceHost = new WebServiceHost(typeof(ExampleJsonpService)))
            {
                serviceHost.Open();

                Console.WriteLine("WCF REST JSONP service is running...");
                Console.ReadLine();

                serviceHost.Close();
            }
        }

        static Service service;
        static Cpu cpu;
        public static Variable variable;

        static void Main(string[] args)
        {
            ServerThread = new Thread(ListenClient);
            ServerThread.Start();

            Console.WriteLine("Connecting Service ...");
			service = new Service("Service");
            service.Error += new PviEventHandler(Error);
            service.Connected += new PviEventHandler(service_Connected);
            service.Connect();

            // Message loop
            Application.Run(); 
        }

        static void service_Connected(object sender, PviEventArgs e)
        {
            Console.WriteLine("Service Connected Error=" + e.ErrorCode.ToString());
            cpu = new Cpu(service, "Cpu");
            cpu.Connection.DeviceType = DeviceType.TcpIp;
            cpu.Connection.TcpIp.DestinationIpAddress = "127.0.0.1";
            cpu.Connection.TcpIp.DestinationPort = 11160;
     
            cpu.Connected += new PviEventHandler(cpu_Connected);
            Console.WriteLine("Connecting Cpu ...");
            cpu.Connect();
        }

        static void cpu_Connected(object sender, PviEventArgs e)
        {
            Console.WriteLine("Cpu Connected Error=" + e.ErrorCode.ToString());
            variable = new Variable(cpu, "gOPC.Output.Xpos");
            variable.Active = true;
            variable.ValueChanged += new VariableEventHandler(ValueChanged);
            variable.Connected += new PviEventHandler(variable_Connected);
            Console.WriteLine("Connecting Variable ...");
            variable.Connect();
        }

        static void variable_Connected(object sender, PviEventArgs e)
        {
            Console.WriteLine("Variable Connected Error=" + e.ErrorCode.ToString());
        }

        static void Error(object sender, PviEventArgs e)
        {
            Console.WriteLine(String.Format("Error:{0}", e.ErrorText));
            //Application.Exit();
        }

        /// <summary>
        /// Write variable value to the console
        /// </summary>
        static void ValueChanged(object sender, VariableEventArgs e)
        {
            Variable var = (Variable)sender;
            Console.WriteLine("Value={0}", var.Value.ToString());
        }   
    }
}
