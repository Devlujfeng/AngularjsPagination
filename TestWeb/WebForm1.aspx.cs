using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.FacadeLayer;
namespace TestWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequisitionFacade rf = new RequisitionFacade();
            GridView1.DataSource = rf.GetAllRequisition();
            GridView1.DataBind();
        }
    }
}