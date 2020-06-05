<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ConceptBiotech.WebForm.ClientUI.Product" %>

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
                <asp:GridView runat="server" ID="gvPrdouct" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" ShowHeaderWhenEmpty="True">
                    <%-- OnPreRender="gvProducts_PreRender" OnRowCommand="gvProducts_RowCommand">--%>
                    <Columns>
                        <asp:BoundField HeaderText="Product Code/Name" DataField="Code" ItemStyle-Width="80%" HeaderStyle-Width="80%">
                            <HeaderStyle Width="80%"></HeaderStyle>

                            <ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Network" DataField="Name" ItemStyle-Width="80%" HeaderStyle-Width="80%">
                            <HeaderStyle Width="80%"></HeaderStyle>

                            <ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("ID") %>' ItemStyle-Width="10%" ImageUrl="../Images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>

                            <HeaderStyle Width="10%"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("ID") %>' ItemStyle-Width="10%" ImageUrl="../Images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
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

                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Network</label>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlNetworkType" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlNetworkType" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Please Select Network Type" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Code</label>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control" placeholder="Enter Product Code or Product Name"></asp:TextBox>

                            </div>
                        </div>
                        <span id="chkProductCode"></span>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-offset-10 col-md-1">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                            <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductCode" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Product Code" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptDeclaration" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvPrdouct.ClientID%> tbody tr');
        });
       <%-- $(document).ready(function () {
            $("#<%=txtProductCode.ClientID%>").change(function () {

                if ($("[id$=ddlNetworkType]").val() != "-1") {
                    var txtName = $("#<%=txtProductCode.ClientID%>").val();
                    var intId = '<%=ViewState["ID"].ToString() %>';
                    var NetworkID = $("[id$=ddlNetworkType]").val();
                    if (txtName != "") {
                        $("#chkProductCode").html = "";
                        $.ajax({
                            type: "POST",
                            url: "../WebMethods/ValidateName.asmx/ValidateProductCode",
                            data: '{intProductCodeID: "' + intId + '", strName: "' + txtName + '",NetworkID: "' + NetworkID + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                if (response.d == "Available") {
                                    $("#chkProductCode").html('<font color="green">Available</font>');
                                }
                                else if (response.d == "Not Available") {
                                    $("#chkProductCode").html('<font color="red">Not Available</font>');
                                }
                            },
                            failure: function (response) {
                                alert(response);
                            }
                        });
                    }
                }
                else {
                    alert("Please Select Network Type");
                }
            });
            $("#<%=btnSave.ClientID%>").click(function (e) {
                var validateName = $("#chkProductCode").text();
                if (validateName == "Not Available") {
                    alert("Product Code Already Available");
                    e.preventDefault();
                }
            });
        });--%>
    </script>
</asp:Content>
