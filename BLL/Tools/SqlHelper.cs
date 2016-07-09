using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    public static
 class SqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static DataTable GetDataTable(string sqlcommand, params SqlParameter[]pars)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlcommand, conn))
                {
                    if (pars != null)
                    {
                        sda.SelectCommand.Parameters.AddRange(pars);
                    }
                    sda.SelectCommand.CommandType = CommandType.Text;
                    DataTable da = new DataTable();
                    sda.Fill(da);
                    return da;
                }
            }
        }
    }
}
