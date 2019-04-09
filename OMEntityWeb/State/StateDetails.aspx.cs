using Business;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMEntityWeb.State
{
    public partial class StateDetails : System.Web.UI.Page
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
            StateMsts msts = new StateMsts();
            List<StateMst> obj = msts.FullDetails();
            grddepInfo.DataSource = obj;
            grddepInfo.DataBind();
        }

        protected void makelink_delete(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;

            StateMsts msts = new StateMsts();
            String strerr = msts.DeleteState(Convert.ToInt32(strparm));
            BindGridView();

        }

        protected void makelink_edit(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;
            Response.Redirect("StateEdit?SID=" + strparm);
        }

        protected void btnCreateState_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/State/StateCreate", false);
        }
        
    }
}