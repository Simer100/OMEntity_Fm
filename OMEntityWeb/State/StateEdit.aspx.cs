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
    public partial class StateEdit : System.Web.UI.Page
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
            StateMsts msts = new StateMsts();
            StateMst obj = msts.Details(Convert.ToInt32(Request.QueryString["SID"].ToString()));
            txtstatename.Text = obj.State_Name;
        }

        protected void btnstateup_Click(object sender, EventArgs e)
        {
            try
            {
                StateMst mst = new StateMst();
                mst.StateID = Convert.ToInt32(Request.QueryString["SID"].ToString());
                mst.State_Name = txtstatename.Text.Trim();


                StateMsts obj = new StateMsts();
                String strerr = obj.EditState(mst);
                if (strerr == "0")
                {
                    Response.Redirect("~/State/StateDetails", false);
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