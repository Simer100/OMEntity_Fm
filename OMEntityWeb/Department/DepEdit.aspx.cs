using Business;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMEntityWeb.Department
{
    public partial class DepEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindControl();
            }
        }

        private void BindControl()
        {
            DepMsts msts = new DepMsts();
            DepMst obj = msts.Details(Convert.ToInt32(Request.QueryString["DID"].ToString()));
            txtdepartmentname.Text = obj.Dept_Name;
        }

        protected void btnDepartmentup_Click(object sender, EventArgs e)
        {
            try
            {
                DepMst mst = new DepMst();
                mst.Dept_ID = Convert.ToInt32(Request.QueryString["DID"].ToString());
                mst.Dept_Name = txtdepartmentname.Text.Trim();


                DepMsts obj = new DepMsts();
                String strerr = obj.EditDep(mst);
                if (strerr == "0")
                {
                    Response.Redirect("~/Department/DepDetails", false);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnbak_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepDetails", false);
        }

    }
}