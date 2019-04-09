using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Database;

namespace OMEntityWeb.Employee
{
    public partial class empview : System.Web.UI.Page
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
            EmployeeMst employees = msts.Details(Convert.ToInt32(Request.QueryString["EID"].ToString()));
            lblName.Text = employees.FirstName + " " + employees.MiddleName + " " + employees.LastName;
            lblemail.Text = employees.EmailID;
            lblGender.Text = employees.Gender;
            lblJoinDate.Text = employees.JoiningDate;
            lblMobile.Text = employees.MobileNo;
            empImg.ImageUrl = "~/EmpImages/" + employees.Image;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeDetails");
        }
    }
}