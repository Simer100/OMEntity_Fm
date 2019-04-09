using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Database;

namespace OMEntityWeb.Employee
{
    public partial class EmployeeDetails : System.Web.UI.Page
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
            EmployeeMsts msts = new EmployeeMsts();
            List<EmployeeMst> employees = msts.FullDetails();
            grdEmployeeInfo.DataSource = employees;
            grdEmployeeInfo.DataBind();
        }

        protected void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/EmployeeCreate", false);
        }

        protected void makelink_delete(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;

            EmployeeMsts msts = new EmployeeMsts();
            String strerr = msts.DeleteEmployee(Convert.ToInt32(strparm));
            BindGridView();

        }

        protected void makelink_View(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;
            Response.Redirect("empview?EID=" + strparm);
        }

        protected void makelink_edit(object sender, EventArgs e)
        {
            string strparm = (sender as ImageButton).CommandArgument;
            Response.Redirect("EmployeeEdit?EID=" + strparm);
        }

        protected void download(object sender, EventArgs e)
        {
            String fil = ((ImageButton)sender).CommandArgument.ToString();
            String lstrFolderPath = Server.MapPath("~/EmpImages/");

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(lstrFolderPath+ fil);

            if (fileInfo.Exists)
            {
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + fileInfo.Name + "\"");
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.TransmitFile(fileInfo.FullName);
                Response.Flush();
                Response.End();
            }

        }

    }
}