<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ConceptBiotech.Web.ClientUI.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainBody" runat="server">
    <div class="col-md-12">
        <div id="divSearch" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Order List"></asp:Label></h4>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <%--<div class="row no-gutters">
                    <div class="text-center">
                        <label class="col-md-offset-2 col-md-7" style="margin-top: 1%"></label>
                    </div>
                    <div class="col-md-offset-1 col-md-2">
                        <div style="float: left">
                            <asp:ImageButton runat="server" ImageUrl="~/Images/adobe.PNG" ID="imbtnPDF" OnClick="imbtnPDF_Click" />
                        </div>
                        <div style="float: left">
                            <asp:ImageButton runat="server" ImageUrl="~/Images/excel.PNG" ID="imbtnEXCEL" OnClick="imbtnEXCEL_Click" />
                        </div>
                        <div style="float: left">
                            <asp:ImageButton runat="server" ImageUrl="~/Images/word.PNG" ID="imbtnWORD" OnClick="imbtnWORD_Click" />
                        </div>
                    </div>
                </div>--%>
                <%--<div class="row">

                    <label class="col-md-2">Client Name</label>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCustomer_OnselectedIndex"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ControlToValidate="ddlCustomer" ErrorMessage="Select Customer."
                            InitialValue="-1" ValidationGroup="g1"> </asp:RequiredFieldValidator>
                        <asp:HiddenField runat="server" ID="hfClientId" />
                        <asp:HiddenField runat="server" ID="hfClientName" />
                        <asp:HiddenField runat="server" ID="hfClientAddress" />
                        <asp:HiddenField runat="server" ID="hfInvoiceNo" />
                        <asp:HiddenField runat="server" ID="hfVatNo" />
                    </div>

                </div>--%>

                <%--     <div class="row">
                    <label class="col-md-2">Invoice Date</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtDate"  runat="server" CssClass="form-control dtpicker" onkeypress="return false;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Please Select From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Button id="btnGenerateInvoice" runat="server" CssClass="btn btn-success col-md-8" Text="Generate Invoice" OnClick="btnGenerateInvoice_Click"/>
                    </div>
                    <div class="col-md-3">
                        <asp:ImageButton runat="server" ImageUrl="~/Images/adobe.PNG" ID="imbtnPDF" OnClick="imbtnPDF_Click" />
                    </div>
                </div>--%>
                <br />
                <%-- <div class="row">
                    <div class="col-md-offset-11 col-md-1">
                        <div class="input-group">

                            <asp:Button runat="server" Text="Print" CssClass="form-control" id="btnPrint" OnClick="btnPrint_Click"/>
                            <asp:ImageButton runat="server" ImageUrl="~/Images/adobe.PNG" ID="imbtnPDF" OnClick="imbtnPDF_Click" />
                            <asp:LinkButton runat="server" ID="btnGo" CssClass="btn btn-success" Text="Go" ValidationGroup="g1" OnClick="btnGo_Click">Search</asp:LinkButton>
                        </div>
                    </div>
                </div>--%>
                <%--  <div class="row">
                    <div class="col-md-12">
                        <span style="color:red"><asp:Label ID="lblEmptyEmailCustomer" runat="server" Font-Bold="true" CssClass="hyphenate"></asp:Label></span>
                    </div>
                </div>--%>
                <%-- <br />
                <asp:Label ID="lblDobleIMEICount" runat="server" Font-Bold="true" CssClass="hyphenate" Visible="false"></asp:Label>
                
                <br />--%>
                <div class="row">
                    <div class="col-md-2">Search User</div>
                    <div class="col-md-10">
                        <input id="id_search" style="width: 40%" type="text" class="form-control" placeholder="Search User Name Here" onkeydown="return (event.keyCode!=13);" />
                    </div>
                </div>
                <br />
                <div class="row"></div>


                <asp:GridView runat="server" ID="gvCustomer" CssClass="table table-hover table-striped" Style=""
                    AutoGenerateColumns="False" ShowFooter="true" GridLines="Both" OnRowDataBound="gvCustomer_RowDataBound">

                    <Columns>
                        <%--  <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblId" Text='<%#Eval("UIDN")%>' Visible="false" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:BoundField DataField="Id" Visible="false"></asp:BoundField> --%>
                        <%--<asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAll" runat="server"></asp:CheckBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" CssClass="ItemCheckBox" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:BoundField HeaderText="User Name" DataField="Name"></asp:BoundField>
                        <%--<asp:BoundField HeaderText="Total Amount" DataField="TAmt"></asp:BoundField>--%>
                        <asp:BoundField HeaderText="Order Date" DataField="ODt"></asp:BoundField>
                        <asp:TemplateField HeaderText="Total Amount" >
                            <ItemTemplate><%#Eval("TAmt")%></ItemTemplate>
                            <FooterTemplate >

                                <asp:Label ID="lblCostTotal" runat="server"></asp:Label>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

                <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptDeclaration" runat="server">
    <script type="text/javascript">

        $(function () {
            $('#id_search').quicksearch('table#<%=gvCustomer.ClientID%> tbody tr');
        })

        $('[id*="chkSelectAll"]').change(function () {
            debugger;
            if ($(this).prop("checked") == true) {
                $('[id*="chkSelect"]').prop("checked", true);
            }
            else {
                $('[id*="chkSelect"]').prop("checked", false);
            }
        });
    </script>
</asp:Content>

