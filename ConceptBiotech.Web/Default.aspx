<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConceptBiotech.Web.Default" %>

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
            <a href="#" class="brand">
                    <span>
                        <img src="../Images/Conceptbiotechlogo.jpeg" height="50" /></span>
                </a>
            <h2 class="fadeInUp animation-delay8" style="font-weight: bold">
                
                <span class="text-success">ORDER</span> <span style="color: #ccc; text-shadow: 0 1px #fff">MONITORING SYSTEM</span>
            </h2>
        </div>
        <div class="login-widget animation-delay1">
            <div class="panel panel-default">
                <div class="panel-heading clearfix">
                    <div class="pull-left">
                        <i class="fa fa-lock fa-lg"></i>Login
                    </div>

                </div>
                <div class="panel-body">
                    <form class="form-login" runat="server" defaultbutton="btnLogin">
                        <div class="form-group">
                            <label>Username</label>
                            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" class="form-control input-sm bounceIn animation-delay2" />
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" class="form-control input-sm bounceIn animation-delay4" />
                        </div>
                        <div class="form-group">
                            <label class="label-checkbox inline">
                                <input type="checkbox" class="regular-checkbox chk-delete" />
                                <span class="custom-checkbox info bounceIn animation-delay4"></span>
                            </label>
                            Remember me		
                        </div>
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" />
                        <hr />
                        <a class="pull-left" href="http://www.garimasystem.com"  target="_blank">Powered By :
						    <img src="../Images/garimalogo.gif" /></a>
                        <asp:LinkButton CssClass="btn btn-success btn-sm bounceIn animation-delay5 login-link pull-right" ID="btnLogin" runat="server" OnClick="btnLogin_Click"><i class="fa fa-sign-in"></i> Sign in</asp:LinkButton>
                    </form>
                </div>
            </div>
            <!-- /panel -->
        </div>
        <!-- /login-widget -->
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
