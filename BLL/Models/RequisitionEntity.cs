using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RequisitionEntity
    {
        public int requisitionId { get; set; }
        public string departmentId { get; set; }
        public System.DateTime requestDate { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string rejectReason { get; set; }
        public string status_dept { get; set; }

        //public virtual department department { get; set; }
        //public virtual users users { get; set; }
        //public virtual ICollection<requsiiton_item> requsiiton_item { get; set; }
    }
}
