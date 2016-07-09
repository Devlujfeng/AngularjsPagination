using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BLL.Models
{
    public class ShopEntity
    {
        [DataMember]
        public string shopId { get; set; }
        [DataMember]
        public string shopName { get; set; }
        [DataMember]
        public string shpOwner { get; set; }
    }
}
