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
    }
}