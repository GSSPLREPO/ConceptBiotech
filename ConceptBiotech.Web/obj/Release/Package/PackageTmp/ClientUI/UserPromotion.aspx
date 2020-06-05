<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="UserPromotion.aspx.cs" Inherits="ConceptBiotech.Web.ClientUI.UserPromotion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="User Promotion"></asp:Label></h4>
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
                        <asp:BoundField HeaderText="Promotion" DataField="Code" ItemStyle-Width="80%" HeaderStyle-Width="80%">
                            <HeaderStyle Width="80%"></HeaderStyle>

                            <ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="User Name" DataField="Name" ItemStyle-Width="80%" HeaderStyle-Width="80%">
                            <HeaderStyle Width="80%"></HeaderStyle>

                            <ItemStyle Width="80%"></ItemStyle>
                        </asp:BoundField>
                      <%--  <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("PK_Id") %>' ItemStyle-Width="10%" ImageUrl="../Images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>

                            <HeaderStyle Width="10%"></HeaderStyle>

                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:TemplateField>--%>
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
                        <h4 class="box-title">User Promotion</h4>
                    </div>
                    <div class="col-md-1">
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-warning pull-right btn-addnew" data-original-title="View" data-placement="bottom" data-toggle="tooltip" ToolTip="View List" OnClick="btnViewList_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row" style="padding-top: 20px;">
                    <div class="form-group has-error">
                        <label class="col-md-2">User Name</label>
                        <div class="col-md-4">
                            <div class="">
                                <asp:DropDownList ID="ddlUserList" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlUserList" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Please Select User" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                            </div>
                            <span id="chkMaterialName"></span>

                        </div>
                        <label class="col-md-2">Promotion Code</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <%--<span class="input-group-addon"><i class="glyphicon glyphicon-gbp"></i></span>--%>
                                <asp:TextBox ID="txtCode" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
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
</asp:Content>
