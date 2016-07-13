using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class ServiceRequestEntity
    {
        public short SRStatusID { get; set; }
        public string RequestedBy { get; set; }
        public string SRNo { get; set; }
        public short SRType { get; set; }
        public string RequestDate { get; set; }
        public string ShopName { get; set; }
        public string Remark { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Feedback { get; set; }
    }
}