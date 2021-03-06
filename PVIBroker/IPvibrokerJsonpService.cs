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
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace PVIBroker
{
    
    [ServiceContract]
    public interface IPVIBJsonpService
    {
        

        [OperationContract]
        [WebGet(UriTemplate = "mkserv_tcpip/?srvname={srvname}&ip={ip}&port={port}&pmode={pmode}&subspage={subspage}",
            ResponseFormat = WebMessageFormat.Json)]
        bool mkserv_tcpip(string srvname, string ip, int port, bool pmode=true, string subspage="");

        [OperationContract]
        [WebGet(UriTemplate = "mkserv_com/?srvname={srvname}&comparams={comparams}&pmode={pmode}&subspage={subspage}",
            ResponseFormat = WebMessageFormat.Json)]
        bool mkserv_com(string srvname, string comparams, bool pmode = true, string subspage = "");


        [OperationContract]
        [WebGet(UriTemplate = "srv_status/?srvname={srvname}",
            ResponseFormat = WebMessageFormat.Json)]
        int srv_status(string srvname);

        [OperationContract]
        [WebGet(UriTemplate = "endservice/?srvname={srvname}",
            ResponseFormat = WebMessageFormat.Json)]
        bool endservice(string srvname);

        [OperationContract]
        [WebGet(UriTemplate = "watch_var/?srvname={srvname}&varname={varname}",
            ResponseFormat = WebMessageFormat.Json)]
        int watch_var(string srvname, string varname);

        [OperationContract]
        [WebGet(UriTemplate = "get_var/?srvname={srvname}&varname={varname}",
            ResponseFormat = WebMessageFormat.Json)]
        string get_var(string srvname, string varname);

        [OperationContract]
        [WebGet(UriTemplate = "set_var/?srvname={srvname}&varname={varname}&varval={varval}",
            ResponseFormat = WebMessageFormat.Json)]
        int set_var(string srvname, string varname, string varval);
        
        [OperationContract]
        [WebGet(UriTemplate = "varlist/?srvname={srvname}",
            ResponseFormat = WebMessageFormat.Json)]
        //Dictionary<String, PVIVariable> var_list(string srvname);
        String var_list(string srvname);

        [OperationContract]
        [WebGet(UriTemplate = "varchanged/?srvname={srvname}",
            ResponseFormat = WebMessageFormat.Json)]
        String varchanged(string srvname);
        
    }

    [DataContract]
    [Serializable]
    public class PVIVariable
    {
        [DataMember]
        public bool changed;
        [DataMember]
        public string name;
        [DataMember]
        public object value;
    }
    
}