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
    public partial class EnrollEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDrop();
                BindControl();
            }
        }
        private void BindControl()
        {
            Enrollments msts = new Enrollments();
            Enrollment employees = msts.Details(Convert.ToInt32(Request.QueryString["EID"].ToString()));
            txtsalary.Text = employees.Salary.ToString();
            ddldepartment.SelectedValue = employees.Dept_ID.ToString();
            ddlemployee.SelectedValue = employees.EmployeeID.ToString();
            ddlstate.SelectedValue = employees.StateID.ToString();
           
        }
        private void BindDrop()
        {
            try
            {
                EmployeeMsts msts = new EmployeeMsts();
                List<EmployeeMst> employees = msts.FullDetails();

                ddlemployee.DataTextField = "FirstName";
                ddlemployee.DataValueField = "EmployeeID";
                ddlemployee.DataSource = employees;
                ddlemployee.DataBind();
                ddlemployee.Items.Insert(0, new ListItem("-Select-", "0"));

                StateMsts mst = new StateMsts();
                List<StateMst> obj = mst.FullDetails();

                ddlstate.DataTextField = "State_Name";
                ddlstate.DataValueField = "StateID";
                ddlstate.DataSource = obj;
                ddlstate.DataBind();
                ddlstate.Items.Insert(0, new ListItem("-Select-", "0"));

                DepMsts msts2 = new DepMsts();
                List<DepMst> obj1 = msts2.FullDetails();

                ddldepartment.DataTextField = "Dept_Name";
                ddldepartment.DataValueField = "Dept_ID";
                ddldepartment.DataSource = obj1;
                ddldepartment.DataBind();
                ddldepartment.Items.Insert(0, new ListItem("-Select-", "0"));

            }
            catch (Exception ex)
            {

            }
        }
        protected void btnbak_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpAddDetails", false);
        }
        protected void btnUpdateEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                Enrollment mst = new Enrollment();
                mst.EnrollmentID = Convert.ToInt32(Request.QueryString["EID"].ToString());
                mst.Salary = Convert.ToDecimal(txtsalary.Text.Trim());
                mst.Dept_ID = Convert.ToInt32(ddldepartment.SelectedValue.Trim());
                mst.EmployeeID = Convert.ToInt32(ddlemployee.SelectedValue.Trim());
                mst.StateID = Convert.ToInt32(ddlstate.SelectedValue.Trim());

                Enrollments employee = new Enrollments();
                String strerr = employee.EditEnroll(mst);
                if (strerr == "0")
                {
                    Response.Redirect("~/Enroll/EnrollDetails", false);
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}