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
namespace WcfJsonpService
{
    using System;

    public class ExampleJsonpService : IExampleJsonpService
    {
        public string GetWithOne(string input)
        {
            return Program.variable.Value.ToString();
            //return String.Format("The (jsonp) input string was: {0}", input);
        }

        public string GetWithTwo(string input1, string input2)
        {
            return String.Format("(jsonp) Input one: {0}, Input two: {1}", input1, input2);
        }
    }
}