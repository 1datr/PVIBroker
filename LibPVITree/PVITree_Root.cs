using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BR.AN.PviServices;
using BR.AN;
  

namespace LibPVITree
{
    public class PVITree_Root
    {
        private Dictionary<String, PVITree_Service> fServiceList;
        public Dictionary<String, PVITree_Service> ServiceList
        {
            get {
                return fServiceList;
            }
            set {
                fServiceList = value;
            }
        }

        public void addService(String servname)
        {
            PVITree_Service Srv = new PVITree_Service(servname);
            Srv.Connect();
            if (ServiceList == null) ServiceList = new Dictionary<String, PVITree_Service>();
            ServiceList.Add(servname, Srv);
        }

        
    }
    
    
}
