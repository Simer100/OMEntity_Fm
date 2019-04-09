<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="StateCreate.aspx.cs" Inherits="OMEntityWeb.State.StateCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>State Creation</title>
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
            
            var txtstatename = $('#<%=txtstatename.ClientID%>').val();
            if (txtstatename == "") {
                jAlert('Kindly Enter State name', 'Alert Dialog');
                $('#<%=txtstatename.ClientID%>').focus();
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
                        <td style="width: 60%; padding-left: 20px;" class="Page_Header"><b>State Creation</b> </td>
                    </tr>
                </table>
                <table style="border-collapse: collapse; border-width: 0" width="50%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <br />
                            <table border='0' cellpadding="4" width="80%">
                                <tr>
                                     <td class="Display_Caption" align="left">&nbsp;&nbsp;&nbsp;&nbsp;State Name</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtstatename" runat="server" CssClass="textbox" Width="135px"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>&nbsp;</td>
                                </tr>
                               
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Button ID="btnstate" runat="server" CssClass="button-new"
                                            Text="Create State" OnClientClick="return checkfield();" OnClick="btnstate_Click"  ></asp:Button><br />
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
