using Business;
using Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMEntityWeb.Employee
{
    public partial class EmployeeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeMst mst = new EmployeeMst();

                mst.FirstName = txtfirstname.Text.Trim();
                mst.MiddleName = txtmiddlename.Text.Trim();
                mst.LastName = txtlastname.Text.Trim();
                mst.DateOfBirth = txtDATEBIRTH.Text.Trim();
                mst.JoiningDate = txtjoiningdate.Text.Trim();
                mst.Emp_Code = txtemployeecode.Text.Trim();

                String[] strUpload;
                if (FUpload.HasFile)
                {
                    strUpload = Upload(FUpload);
                    if (strUpload[0] == "0")
                    {
                        mst.Image = strUpload[1];
                    }
                    else
                    {
                        string message = Convert.ToString(strUpload[1]);
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("jAlert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "jAlert", sb.ToString());
                        return;
                    }
                }

                mst.Gender = rdlgender.SelectedValue.Trim();
                mst.EmailID = txtemailid.Text.Trim();
                mst.MobileNo = txtmobilenumber.Text.Trim();

                EmployeeMsts employee = new EmployeeMsts();
                String strerr = employee.CreateEmployee(mst);
                if (strerr == "0")
                {
                    Response.Redirect("~/Employee/EmployeeDetails", false);
                    //string message = "Request Processed Successfully.";
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("<script type = 'text/javascript'>");
                    //sb.Append("window.onload=function(){");
                    //sb.Append("jAlert('");
                    //sb.Append(message);
                    //sb.Append("')};");
                    //sb.Append("</script>");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "jAlert", sb.ToString());
                    //return;
                }

            }
            catch(Exception ex)
            {
                
            }

        }

        #region uploadfile

        private String[] Upload(FileUpload FileUpload_NAME)
        {

            String[] arrResponse = new String[2];
            bool IsExt = false;
            String lstrPath = Server.MapPath("~/EmpImages/");

            String lstrFileName = "";
            try
            {
                if (FileUpload_NAME.PostedFile != null)
                {
                    String lstrSizeToUpload = ConfigurationManager.AppSettings["MaxSizeForUpload"].ToString();

                    if (FileUpload_NAME.PostedFile.ContentLength > 1)
                    {
                        if (FileUpload_NAME.PostedFile.ContentLength > Convert.ToInt64(lstrSizeToUpload))
                        {

                            arrResponse[0] = "1";

                            arrResponse[1] = "<b>The Size of file (" + FileUpload_NAME.PostedFile.ContentLength / 1000000 + " MB ) is greater than 4 MB.</b>";

                        }
                        else
                        {
                            String lstrExtension = Path.GetExtension(FileUpload_NAME.PostedFile.FileName);
                            String TimeStamp = DateTime.Now.ToString("ddMMMyyyy_HHmmss");
                            lstrFileName = Path.GetFileNameWithoutExtension(FileUpload_NAME.PostedFile.FileName) + "_" + TimeStamp + lstrExtension;

                            if (ConfigurationManager.AppSettings["CERT_EXT"] != null)
                            {
                                string[] ext = ConfigurationManager.AppSettings["CERT_EXT"].ToString().Split(',');
                                if (ext.Length > 0)
                                {
                                    for (int i = 0; i < ext.Length; i++)
                                    {
                                        if (lstrExtension.ToUpper() == "." + ext[i].ToUpper())
                                        {
                                            DirectoryInfo thisFolder = new DirectoryInfo(lstrPath);
                                            if (!thisFolder.Exists)
                                            {
                                                thisFolder.Create();

                                            }
                                            FileUpload_NAME.PostedFile.SaveAs(lstrPath + lstrFileName);
                                            arrResponse[0] = "0";
                                            arrResponse[1] = lstrFileName;
                                            IsExt = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                arrResponse[0] = "2";
                                arrResponse[1] = "* Please specify extensions in Web.Config";
                            }
                            if (IsExt == false)
                            {
                                arrResponse[0] = "3";
                                arrResponse[1] = "* You can only upload these file Extensions " + ConfigurationManager.AppSettings["CERT_EXT"].ToString();
                            }

                        }//Content length check.
                    }
                }
                return arrResponse;
            }
            catch (Exception ex)
            {
                arrResponse[0] = "3";
                arrResponse[1] = "Run Time Exception";
                throw ex;
            }
        }

        #endregion uploadfile

    }
}