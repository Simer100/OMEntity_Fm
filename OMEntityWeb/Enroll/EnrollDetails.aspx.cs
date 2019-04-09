using Business;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMEntityWeb.Enroll
{
    public partial class EnrollDetails : System.Web.UI.Page
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
            Enrollments msts = new Enrollments();
            List<Enrollment> employees = msts.FullDetails();
            grdEmployeeInfo.DataSource = employees;
            grdEmployeeInfo.DataBind();
        }

        protected void btnCreateEmpEnroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Enroll/EnrollCreate", false);
        }

        protected void makelink_delete(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;

            Enrollments msts = new Enrollments();
            String strerr = msts.DeleteEnroll(Convert.ToInt32(strparm));
            BindGridView();

        }

        protected void makelink_edit(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;
            Response.Redirect("EnrollEdit?EID=" + strparm);
        }


    }
}