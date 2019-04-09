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
    public partial class EmpAddEdit : System.Web.UI.Page
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
            EmpAddressDets msts = new EmpAddressDets();
            EmpAddressDet employees = msts.Details(Convert.ToInt32(Request.QueryString["EID"].ToString()));
            txtaddress1.Text = employees.Address1;
            txtaddress2.Text = employees.Address2;
            ddlemployee.SelectedValue = employees.EmployeeID.ToString();
            ddlstate.SelectedValue = employees.StateID.ToString();
            txtpincode.Text = employees.PinCode.ToString();
           
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

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnbak_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpAddDetails", false);
        }

        protected void btnUpdateAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                EmpAddressDet mst = new EmpAddressDet();
                mst.AddressID = Convert.ToInt32(Request.QueryString["EID"].ToString());
                mst.Address1 = txtaddress1.Text.Trim();
                mst.Address2 = txtaddress2.Text.Trim();
                mst.EmployeeID = Convert.ToInt32(ddlemployee.SelectedValue.Trim());
                mst.StateID = Convert.ToInt32(ddlstate.SelectedValue.Trim());
                mst.PinCode = Convert.ToInt32(txtpincode.Text.Trim());

                EmpAddressDets employee = new EmpAddressDets();
                String strerr = employee.EditEmpAdd(mst);
                if (strerr == "0")
                {
                    Response.Redirect("~/EmployeeAdd/EmpAddDetails", false);
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}