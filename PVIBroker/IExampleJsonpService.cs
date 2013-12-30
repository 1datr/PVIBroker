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
namespace PVIBroker
{
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IExampleJsonpService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetWithOne/{input}",
            ResponseFormat = WebMessageFormat.Json)]
        string GetWithOne(string input);

        [OperationContract]
        [WebGet(UriTemplate = "GetWithTwo/?input1={input1}&input2={input2}",
            ResponseFormat = WebMessageFormat.Json)]
        string GetWithTwo(string input1, string input2);

        [OperationContract]
        [WebGet(UriTemplate = "mkservice/?srvname={srvname}",
            ResponseFormat = WebMessageFormat.Json)]
        bool mkservice(string srvname);

        [OperationContract]
        [WebGet(UriTemplate = "connect_cpu_tcpip/?srvname={srvname}&ip={ip}&port={port}&cpuname={cpuname}",
            ResponseFormat = WebMessageFormat.Json)]
        bool connect_cpu_tcpip(string srvname,string ip, int port, string cpuname);

        [OperationContract]
        [WebGet(UriTemplate = "watch_var/?srvname={srvname}&cpuname={cpuname}&varname={varname}",
            ResponseFormat = WebMessageFormat.Json)]
        bool watch_var(string srvname, string cpuname, string varname);

        [OperationContract]
        [WebGet(UriTemplate = "watch_var/?getvar={srvname}&cpuname={cpuname}&varname={varname}",
            ResponseFormat = WebMessageFormat.Json)]
        string get_var(string srvname, string cpuname, string varname);

        [OperationContract]
        [WebGet(UriTemplate = "watch_var/?setvar={srvname}&cpuname={cpuname}&varname={varname}&varval={varval}",
            ResponseFormat = WebMessageFormat.Json)]
        bool set_var(string srvname, string cpuname, string varname, object varval);
    }
}