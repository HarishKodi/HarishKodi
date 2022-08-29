<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication12.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 586px;
            height: 345px;
            margin-left: 197px;
            background-color: #00FFFF;
        }
        .auto-style2 {
            font-size: x-large;
        }
        .auto-style3 {
            background-color: #3333CC;
        }
        .auto-style4 {
            color: #0066FF;
            text-decoration: underline;
        }
        .auto-style5 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <span class="auto-style2"><strong><span class="auto-style3">Login Form</span></strong></span><br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            User Name :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" CssClass="auto-style5" ErrorMessage="Please Enter Userid"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Password :&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" CssClass="auto-style5" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            New User?<asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style4" NavigateUrl="~/WebForm3.aspx">Signup!</asp:HyperLink>
&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style4" NavigateUrl="~/WebForm4.aspx">Forgot Password!</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Admin Login!<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/WebForm5.aspx">Login</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
