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
    public partial class DepCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDepartmentEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DepMst mst = new DepMst();
                mst.Dept_Name = txtdepartmentname.Text.Trim();

                DepMsts obj = new DepMsts();
                String strerr = obj.CreateDep(mst);
                if (strerr == "0")
                {
                    Response.Redirect("~/Department/DepDetails", false);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}