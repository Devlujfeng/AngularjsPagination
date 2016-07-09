using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using System.Data.SqlClient;
using System.Data;
using BLL.Tools;
namespace BLL.FacadeLayer
{
    public class RequisitionFacade
    {
        FMDBEntities fe = new FMDBEntities();
        public List<ServiceRequestEntity> GetAllRequisition()
        {
            var t = (from x in fe.ServiceRequest
                     select new ServiceRequestEntity
                     {
                         SRNo = x.SRNo,
                         SRType = x.SRType,
                         RequestDate = x.RequestDate,
                         ShopName = x.ShopName,
                         Remark = x.Remark,
                         Email = x.Email,
                         ContactNumber = x.ContactNumber
                     }).ToList();
            return t;
        }
        public List<ServiceRequestEntity> GetRequisitionByIndex(int start, int end)
        {
            string SqlCommand = "select * from(select *,row_number()over(order by SRNo) as num from ServiceRequest) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] pars = { 
                                  new SqlParameter("@start",SqlDbType.Int),
                                  new SqlParameter("@end",SqlDbType.Int)
                                  };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = SqlHelper.GetDataTable(SqlCommand, pars);
            List<ServiceRequestEntity> lsre = new List<ServiceRequestEntity>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow x in dt.Rows)
                {
                    ServiceRequestEntity sre = new ServiceRequestEntity();
                    sre.SRNo = x["SRNo"].ToString();
                    sre.SRType = short.Parse(x["SRType"].ToString());
                    sre.RequestDate = x["RequestDate"].ToString();
                    sre.ShopName = x["ShopName"].ToString();
                    sre.Remark = x["Remark"].ToString();
                    sre.Email = x["Email"].ToString();
                    sre.ContactNumber = x["ContactNumber"].ToString();
                    lsre.Add(sre);
                }
            }
            return lsre;
        }
    }
}
