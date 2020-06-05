<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConceptBiotech.WebForm._Default" %>

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
            <div class="login-widget animation-delay1">
                <div class="panel panel-default">

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <section id="loginForm">
                                    <div class="form-horizontal">
                                        <h4>Use a local account to log in.</h4>
                                        <hr />
                                        <%-- <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                            <p class="text-danger">
                                                <asp:Literal runat="server" ID="FailureText" />
                                            </p>
                                        </asp:PlaceHolder>--%>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                                            <div class="col-md-10">
                                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                                    CssClass="text-danger" ErrorMessage="The email field is required." />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                                            <div class="col-md-10">
                                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2 col-md-10">
                                                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" />
                                                <%--<div class="checkbox">
                                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                                </div>--%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-2 col-md-10">
                                                <asp:Button runat="server" OnClick="btnLogin_Click" Text="Log in" CssClass="btn btn-default" />
                                                <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                                            </div>
                                            <div class="col-md-offset-2 col-md-10">
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
