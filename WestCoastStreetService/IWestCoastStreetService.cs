using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL.Models;

namespace WestCoastStreetService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWestCoastStreetService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "getData",
            ResponseFormat = WebMessageFormat.Json)]
        string getAllData();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "postData",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string getAllData2(string data);

        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "GetRequistion?pageIndex={index}&?pageSize={pageSize}",
        ResponseFormat = WebMessageFormat.Json)]
        List<ServiceRequestEntity> GetAllRequisition(int index, int pageSize);

        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "CreateNewRequisition",
        ResponseFormat = WebMessageFormat.Json)]
        Boolean CreateNewRequisition(ServiceRequestEntity se);

        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "UpdateRequisition",
        ResponseFormat = WebMessageFormat.Json)]
        Boolean UpdateRequisition(ServiceRequestEntity se);


        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
