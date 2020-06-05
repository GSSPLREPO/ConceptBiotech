<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ConceptBiotech.Web.ClientUI.Products" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Product"></asp:Label></h4>
                    </div>
                    <div id='search-form' class="col-md-3 form-group">
                        <div class="input-group">
                            <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                            <input id="id_search" type="text" class="form-control" placeholder="search" onkeydown=" return (event.keyCode !== 13); " />
                        </div>
                    </div>
                    <div class="col-md-1 right">
                        <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New" OnClick="btnAddNew_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="gvPrdouct" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True" OnPreRender="gvProducts_PreRender" OnRowCommand="gvProducts_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Product Name" DataField="ProductName" ItemStyle-Width="80%" HeaderStyle-Width="80%">
                            <HeaderStyle Width="80%"></HeaderStyle>

                            <ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField HeaderText="Network" DataField="Name" ItemStyle-Width="80%" HeaderStyle-Width="80%">
                            <HeaderStyle Width="80%"></HeaderStyle>

                            <ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("PK_Id") %>' ItemStyle-Width="10%" ImageUrl="../Images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>

                            <HeaderStyle Width="10%"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("PK_Id") %>' ItemStyle-Width="10%" ImageUrl="../Images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>

                            <HeaderStyle Width="10%"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="panel panel-default" runat="server" id="divPanel">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-11">
                        <h4 class="box-title">Products</h4>
                    </div>
                    <div class="col-md-1">
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-warning pull-right btn-addnew" data-original-title="View" data-placement="bottom" data-toggle="tooltip" ToolTip="View List" OnClick="btnViewList_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row" style="padding-top: 20px;">
                    <div class="form-group has-error">
                        <label class="col-md-2">Product Name</label>
                        <div class="col-md-4">
                            <div class="">
                                <%--  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Enter Product Code or Product Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvVendor" runat="server" ControlToValidate="txtProductName" ErrorMessage="Enter Product Name" SetFocusOnError="true" ValidationGroup="g1" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <span id="chkMaterialName"></span>

                        </div>
                        <label class="col-md-2">Selling Price</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <%--<span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>--%>
                                <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="form-control" placeholder="Enter Selling Price" onkeypress="return PreventDecimalPoint(event)"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvSellingPrice" runat="server" ControlToValidate="txtSellingPrice" ErrorMessage="Enter Selling Price" SetFocusOnError="true" ValidationGroup="g1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-top: 10px;">
                    <div class="form-group has-error">
                        <label class="col-md-2">PurchasePrice</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <%--<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                                <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="form-control" placeholder="Enter PurchasePrice" onkeypress="return PreventDecimalPoint(event)"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPurchasePrice" ErrorMessage="Enter PurchasePrice" SetFocusOnError="true" ValidationGroup="g1" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Unit Name</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <%--<span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>--%>
                                <asp:TextBox ID="txtUnitName" runat="server" CssClass="form-control" placeholder="Enter UserName"></asp:TextBox>
                            </div>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRRP" ErrorMessage="Enter RRP Price" SetFocusOnError="true" ValidationGroup="g1" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 10px;">
                    <div class="form-group">
                        <label class="col-md-2">Description :</label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine" placeholder="Description"
                                Rows="4" Style="text-transform: uppercase;" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Upload File</label>
                        <div class="col-md-4">
                            <div>
                                <div class="input-group has-error">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-arrow-up"></i></span>

                                    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control dtpicker" onkeypress="return false;" placeholder="Enter Purchase Date" MaxLength="10"></asp:TextBox>--%>
                                    <asp:FileUpload ID="FULogo" runat="server" CssClass="form-control" />
                                </div>
                                <br />
                                <div class="col-md-6">
                                    <div id="imgLogo">
                                        <asp:Image ID="imgCLogo" runat="server" ImageUrl="~/Images/NoImage-big.jpg" Width="150" Height="150" BorderWidth="1" BorderColor="Black" BorderStyle="Solid" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-offset-10 col-md-1">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptDeclaration" runat="server">
    <script src="../JS/jquery.quicksearch.js"></script>
    <link href="../CSS/jquery-ui.css" rel="stylesheet" />
    <script src="../JS/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvPrdouct.ClientID%> tbody tr');
        });

        $("#<%=txtSellingPrice.ClientID%>").change(function () {
            var SellingPrice = $(this).val();
            SellingPrice = parseFloat(SellingPrice).toFixed(2);
            $("#<%=txtSellingPrice.ClientID%>").val(SellingPrice);
        });

        $("#<%=txtPurchasePrice.ClientID%>").change(function () {
            var SellingPrice = $(this).val();
            SellingPrice = parseFloat(SellingPrice).toFixed(2);
            $("#<%=txtPurchasePrice.ClientID%>").val(SellingPrice);
        });

        $(document).ready(function () {
            $("#<%=txtProductName.ClientID%>").change(function () {
                var txtName = $("#<%=txtProductName.ClientID%>").val();
                var intId = '<%=ViewState["ID"].ToString() %>';
                if (txtName != "") {
                    $("#chkMaterialName").html = "";
                    $.ajax({
                        type: "POST",
                        url: "../WebMethods/ValidateName.asmx/ValidateMaterialName",
                        data: '{intId: "' + intId + '", strName: "' + txtName + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            if (response.d == "Available") {
                                $("#chkMaterialName").html('<font color="green">Available</font>');
                            }
                            else if (response.d == "Not Available") {
                                $("#chkMaterialName").html('<font color="red">Not Available</font>');
                            }
                        },
                        failure: function (response) {
                            alert(response);
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
