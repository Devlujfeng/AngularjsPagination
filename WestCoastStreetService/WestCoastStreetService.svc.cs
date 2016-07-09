using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL.FacadeLayer;
using BLL.Models;

namespace WestCoastStreetService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WestCoastStreetService : IWestCoastStreetService
    {
        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string getAllData()
        {
            return "httpd";
        }
        public string getAllData2(string data)
        {
            return "rrr";
        }

        public List<ServiceRequestEntity> GetAllRequisition(int index, int pageSize)
        {
            int start = (index-1) * pageSize+1;
            int end = index * pageSize;
            RequisitionFacade rf = new RequisitionFacade();
            return rf.GetRequisitionByIndex(start,end);
        }
    }
}
