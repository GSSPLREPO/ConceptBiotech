<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="ConceptBiotech.Web.ClientUI.User" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:label id="lblHeading" runat="server" text="Mobile App Users"></asp:label>
                        </h4>
                    </div>
                    <div id='search-form' class="col-md-3 form-group">
                        <div class="input-group">
                            <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                            <input id="id_search" type="text" class="form-control" placeholder="search" onkeydown=" return (event.keyCode !== 13); " />
                        </div>
                    </div>
                   
                </div>
            </div>
            <div class="panel-body">
                <asp:gridview runat="server" id="gvPrdouct" cssclass="table table-hover table-striped" autogeneratecolumns="False" gridlines="None" showheaderwhenempty="True" onprerender="gvUsers_PreRender" onrowcommand="gvUsers_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="40%" HeaderStyle-Width="40%">
                            <HeaderStyle Width="40%"></HeaderStyle>
                            <ItemStyle Width="40%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Mobile" DataField="Mobile" ItemStyle-Width="20%" HeaderStyle-Width="20%">
                            <HeaderStyle Width="20%"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField HeaderText="Address1" DataField="Address1" ItemStyle-Width="20%" HeaderStyle-Width="20%">
                            <HeaderStyle Width="20%"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                         <asp:BoundField HeaderText="Promotion Code" DataField="PromotionCode" ItemStyle-Width="20%" HeaderStyle-Width="20%">
                            <HeaderStyle Width="20%"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                    <%--     <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-Width="20%" HeaderStyle-Width="20%">
                            <HeaderStyle Width="20%"></HeaderStyle>
                            <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>--%>
                       <%-- <asp:TemplateField HeaderText="Active" ItemStyle-Width="10%" HeaderStyle-Width="10%">
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
                </asp:gridview>
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

        
    </script>
</asp:Content>

