using Business;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMEntityWeb.EmployeeAdd
{
    public partial class EmpAddDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            EmpAddressDets msts = new EmpAddressDets();
            List<EmpAddressDet> employees = msts.FullDetails();
            grdEmployeeInfo.DataSource = employees;
            grdEmployeeInfo.DataBind();
        }

        protected void btnCreateEmployeeAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeeAdd/EmpAddCreate", false);
        }

        protected void makelink_delete(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;

            EmpAddressDets msts = new EmpAddressDets();
            String strerr = msts.DeleteEmpAdd(Convert.ToInt32(strparm));
            BindGridView();

        }

        protected void makelink_edit(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;
            Response.Redirect("EmpAddEdit?EID=" + strparm);
        }


    }
}