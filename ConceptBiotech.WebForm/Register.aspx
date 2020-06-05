<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ConceptBiotech.WebForm.Register" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Concept Biotech</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Awesome -->
    <link href="CSS/font-awesome.min.css" rel="stylesheet" />

    <!-- Endless -->
    <link href="CSS/endless.min.css" rel="stylesheet" />

</head>

<body style="background-color: #323447">
    <div class="login-wrapper">
        <div class="text-center">
            <h2 class="fadeInUp animation-delay8" style="font-weight: bold">
                <span class="text-success">Concept</span> <span style="color: #ccc; text-shadow: 0 1px #fff">Biotech</span>
            </h2>
        </div>
        <form class="form-login" runat="server">
            <div class="animation-delay1 row vertical-center-row">
                <div class="panel panel-default col-md-6 col-md-offset-3">

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <section id="loginForm">
                                    <div class="form-horizontal">
                                        <h4>Create a new account</h4>
                                        <hr />
                                        <%--  <asp:ValidationSummary runat="server" CssClass="text-danger" />--%>
                                        <div class="form-group">
                                            <%--<asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>--%>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="First Name" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="Enter First Name" />
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" placeholder="Middle Name" />

                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" placeholder="Last Name" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="Enter Last Name" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--<asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>--%>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" placeholder="Enter Email Id" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="The email field is required." />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control" TextMode="Number" placeholder="Enter Mobile No" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMobile" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="The Mobile No is required." />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--<asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label">UserName</asp:Label>--%>
                                            <div class="col-md-12">
                                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Address" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="Address is required." />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--<asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>--%>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" placeholder="Enter City" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtState" CssClass="form-control" placeholder="Enter State" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <%--<asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label">UserName</asp:Label>--%>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtPromotionCode" CssClass="form-control" placeholder="Enter Promotion Code" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter UserName" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="The Username is required." />
                                            </div>

                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Passsword" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ValidationGroup="g1"
                                                    CssClass="text-danger" ErrorMessage="The password field is required." />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Confirm password" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ValidationGroup="g1"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="ConfirmPassword" ValidationGroup="g1"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2 col-md-10">
                                                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2 col-md-10">
                                                <asp:Button runat="server" Text="Register" ID="Login" OnClick="Register_Click"
                                                    ValidationGroup="g1" CssClass="btn btn-default" />
                                                <%-- <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <p>
                                    </p>
                                    <p>
                                        <%-- Enable this once you have account confirmation enabled for password reset functionality
                        <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                                        --%>
                                    </p>
                                </section>
                            </div>

                        </div>
                    </div>
                </div>

                <!-- /panel -->
            </div>
            <!-- /login-widget -->
        </form>
    </div>
    <!-- /login-wrapper -->

    <script type="”text/javascript”">
function btnClick()
{
if (!Page_ClientValidate())
{
document.getElementById(“txtFirstName″).style.backgroundColor=”red”;
}
} 
function ClearBackGround()
{
document.getElementById(“txtFirstName″).style.backgroundColor=”";
}
    </script>
    <!-- Jquery -->
    <script src="JS/jquery-1.10.2.min.js"></script>

    <!-- Bootstrap -->
    <script src="JS/bootstrap/bootstrap.js"></script>

    <!-- Modernizr -->
    <script src="JS/modernizr.min.js"></script>

    <!-- Pace -->
    <script src="JS/uncompressed/pace.js"></script>

    <!-- Popup Overlay -->
    <script src="JS/jquery.popupoverlay.min.js"></script>

    <!-- Slimscroll -->
    <script src="JS/jquery.slimscroll.min.js"></script>

    <!-- Cookie -->
    <script src="JS/jquery.cookie.min.js"></script>

    <!-- Endless -->
    <script src="JS/endless/endless.js"></script>
</body>

</html>
