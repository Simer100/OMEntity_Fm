<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="EmployeeEdit.aspx.cs" Inherits="OMEntityWeb.Employee.EmployeeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Employee Edition</title>
    <link href="../UIFiles/css/styles.css" rel="stylesheet" />
    <script src="../UIFiles/js/jquery-1.4.2.min.js"></script>
    <link href="../UIFiles/alertmsg/jquery.alerts.css" rel="stylesheet" />
    <script src="../UIFiles/alertmsg/jquery.alerts.js"></script>

    <script type="text/javascript">
        function numbersonly(e, decimal) {

            var key;
            var keychar;
            if (window.event) {
                key = window.event.keyCode;
            }
            else if (e) {
                key = e.which;
            }
            else {
                return true;
            }
            keychar = String.fromCharCode(key);
            if ((key == null) || (key == 0) || (key == 8) || (key == 9) || (key == 13) || (key == 27)) {
                return true;
            }
            else if ((("0123456789").indexOf(keychar) > -1)) {
                return true;
            }
            else if (decimal && (keychar == ".")) {
                return true;
            }
            else
                return false;
        }

        function checkfield() {
            

            var txtemployeecode = $('#<%=txtemployeecode.ClientID%>').val();
            if (txtemployeecode == "") {
                jAlert('Kindly Enter Employee Code', 'Alert Dialog');
                $('#<%=txtemployeecode.ClientID%>').focus();
                return false;
            }

           var txtfirstname = $('#<%=txtfirstname.ClientID%>').val();
            if (txtfirstname == "") {
                jAlert('Kindly Enter First Name', 'Alert Dialog');
                $('#<%=txtfirstname.ClientID%>').focus();
                return false;
            }

             var txtlastname = $('#<%=txtlastname.ClientID%>').val();
            if (txtlastname == "") {
                jAlert('Kindly Enter Last Name', 'Alert Dialog');
                $('#<%=txtlastname.ClientID%>').focus();
                return false;
            }

             var txtDATEBIRTH = $('#<%=txtDATEBIRTH.ClientID%>').val();
            if (txtDATEBIRTH == "") {
                jAlert('Kindly Enter Date Of Birth', 'Alert Dialog');
                $('#<%=txtDATEBIRTH.ClientID%>').focus();
                return false;
            }

              var txtjoiningdate = $('#<%=txtjoiningdate.ClientID%>').val();
            if (txtjoiningdate == "") {
                jAlert('Kindly Enter Date Of Joining', 'Alert Dialog');
                $('#<%=txtjoiningdate.ClientID%>').focus();
                return false;
            }

             var FUpload = $('#<%=FUpload.ClientID%>').val();
            if (FUpload == "") {
                jAlert('Kindly Upload File.', 'Alert Dialog');
                $('#<%=FUpload.ClientID%>').focus();
                return false;
            }

            
            var rdlgender = $('#<%=rdlgender.ClientID %> input:checked').val(); 
            if (rdlgender == "") {
                jAlert("Please Select Gender.", 'Alert Dialog');
                return false;
            }

            var txtemailid = $('#<%=txtemailid.ClientID%>').val();
            if (txtemailid == "") {
                jAlert('Kindly Enter Email ID', 'Alert Dialog');
                $('#<%=txtemailid.ClientID%>').focus();
                return false;
            }

            if (txtemailid != "") {
                var reg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
                if (!reg.test(txtemailid)) {
                    jAlert('Kindly Enter Valid Email', 'Alert Dialog');
                    $('#<%=txtemailid.ClientID%>').val('');
                    $('#<%=txtemailid.ClientID%>').focus();
                    return false;
                }
            }

            var txtmobilenumber = $('#<%=txtmobilenumber.ClientID%>').val();
            if (txtmobilenumber == "") {
                jAlert('Kindly Enter Mobile Number', 'Alert Dialog');
                $('#<%=txtmobilenumber.ClientID%>').focus();
                return false;
            }

           if (txtmobilenumber.length != 10) {
                jAlert('Kindly Enter 10 Digit Mobile Number', 'Alert Dialog');
                $('#<%=txtmobilenumber.ClientID%>').val('');
                $('#<%=txtmobilenumber.ClientID%>').focus();
                return false;
            }


        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
     <table style="border-collapse: collapse; border-width: 0" width="100%" border="0"
        cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <br />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 60%; padding-left: 20px;" class="Page_Header"><b>Employee Edition</td>
                    </tr>
                </table>
                <table style="border-collapse: collapse; border-width: 0" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <br />
                            <table border='0' cellpadding="4" width="90%">
                                <tr>
                                     <td class="Display_Caption" align="left">Employee Code</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtemployeecode" runat="server" CssClass="textbox" Width="135px"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="Display_Caption" align="left">First Name</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtfirstname" runat="server" CssClass="textbox" Width="135px"></asp:TextBox>
                                    </td>
                                    <td class="Display_Caption" align="left">Middle Name</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtmiddlename" runat="server" CssClass="textbox" Width="135px"></asp:TextBox>
                                    </td>
                                     <td class="Display_Caption" align="left">Last Name</td>
                                     <td align="left">
                                        <asp:TextBox ID="txtlastname" runat="server" CssClass="textbox" Width="135px"></asp:TextBox>
                                     </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="Display_Caption" align="left">Date Of Birth</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDATEBIRTH" runat="server" CssClass="textbox" Width="110px" placeholder="dd-MMM-yyyy" ></asp:TextBox>
                                    </td>
                                    <td class="Display_Caption" align="left">Joining Date</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtjoiningdate" runat="server" CssClass="textbox" Width="135px" placeholder="dd-MMM-yyyy"></asp:TextBox>
                                    </td>
                                    <td class="Display_Caption" align="left">Image Upload</td>
                                    <td align="left">
                                        <asp:FileUpload ID="FUpload" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="Display_Caption" align="left">Gender</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rdlgender" runat="server" RepeatDirection="Horizontal" CellSpacing="5">
                                            <asp:ListItem Text="Male" Value="MALE"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="FEMALE"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                     <td class="Display_Caption" align="left">Email ID</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtemailid" runat="server" CssClass="textbox" Width="135px"></asp:TextBox>
                                    </td>
                                     <td class="Display_Caption" align="left">Mobile Number</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtmobilenumber" runat="server" CssClass="textbox" Width="135px" onKeyPress="return numbersonly(event, false)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Button ID="btnEditionEmployee" runat="server" CssClass="button-new"
                                            Text="Update" OnClientClick="return checkfield();" OnClick="btnEditionEmployee_Click" ></asp:Button>&nbsp;
                                        <asp:Button ID="btnbak" runat="server" Text="Back" CssClass="button-new" OnClick="btnbak_Click"/><br />
                                        <asp:Label ID="lblErrMsg1" runat="server" Text="" ForeColor="red" Font-Bold="true"
                                            Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
