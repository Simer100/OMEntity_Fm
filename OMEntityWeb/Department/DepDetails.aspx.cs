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
    public partial class DepDetails : System.Web.UI.Page
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
            DepMsts msts = new DepMsts();
            List<DepMst> obj = msts.FullDetails();
            grddepInfo.DataSource = obj;
            grddepInfo.DataBind();
        }

        protected void makelink_delete(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;

            DepMsts msts = new DepMsts();
            String strerr = msts.DeleteDep(Convert.ToInt32(strparm));
            BindGridView();

        }

        protected void makelink_edit(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;
            Response.Redirect("DepEdit?DID=" + strparm);
        }

        protected void btnCreateDep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Department/DepCreate", false);
        }

    }
}