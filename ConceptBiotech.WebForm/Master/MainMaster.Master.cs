using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.WebForm.Master
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["USERID"] != null)
                {
                    //lblUserName.Text = Session[ApplicationSession.USERNAME].ToString();
                    #region Manage Role Rights


                    //string sPath = Page.Page.AppRelativeVirtualPath;
                    //string sRet = sPath.Substring(sPath.LastIndexOf('/') + 1);

                    //RightBl objRoleRightsBL = new RightBl();
                    //ApplicationResult objResults = new ApplicationResult();

                    //int flagMaster = 0;
                    //int flagReport = 0;
                    //int flagTransaction = 0;
                    //int flagReportTransaction = 0;
                    //int flag = 0;

                    //objResults = objRoleRightsBL.RoleRights_SelectAll_ForAuthorization(Convert.ToInt32(Session[ApplicationSession.ROLEID].ToString()), 1);

                    //if (objResults != null)
                    //{
                    //    for (int i = 0; i < objResults.resultDT.Rows.Count; i++)
                    //    {
                    //        #region Menu Hide
                    //        Control MyList = FindControl("cssmenu");
                    //        foreach (Control MyControl in MyList.Controls)
                    //        {
                    //            if (MyControl is HtmlGenericControl)
                    //            {
                    //                HtmlGenericControl li = MyControl as HtmlGenericControl;

                    //                if (li.ID == objResults.resultDT.Rows[i]["DisplayName"].ToString())
                    //                {
                    //                    li.Visible = true;
                    //                    break;
                    //                }
                    //            }
                    //        }

                    //        // Masters

                    //        if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Attribute_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Branch_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Customer_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Customer_Type_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "MaterialGroup_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Material_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Employee_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Organisation_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Role_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Ref_Person_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Unit_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Unit_Category_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Supplier_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Inquiry_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Manufacturer_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "RoleRights_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Tax")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "StockUpdation")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Networks_Master")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Supplier")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Product")
                    //            flagMaster = 1;
                    //        else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CommisionType")
                    //            flagMaster = 1;

                    //        ////Transaction

                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PurchaseInvoice")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "MaterialReturn")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Invoice")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CostInvoice")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PayIn")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PayOut")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SimStockOut")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SimStockReturn")
                    //        //    flagTransaction = 1;
                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "EmployeeProductTemplate")
                    //        //    flagTransaction = 1;

                    //        //// Report 

                    //        //if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Customer_Report")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Vendor_Report")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "Material_Report")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SupplierWise_PurchaseBill_Report")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "StockReport")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "VATReport")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CurrentStockReport")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CustomerPayInReport")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "MultiCustomerSelfBillingInvoiceReport")
                    //        //    flagReport = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SupplierPayOutReport")
                    //        //    flagReport = 1;

                    //        ////else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "List_Of_Audit_Report")
                    //        ////    flagReport = 1;

                    //        //// Report Transaction

                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "ClientWiseBillReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "DateWiseMaterialBillReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "MaterialReturnReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CancleBillReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SalesReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PayInReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PayOutReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CostInvoiceReport")
                    //        //    flagReportTransaction = 1;

                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "EmployeeStockOutReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "StockDetails")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SimCardActivationReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PurchaseInvoiceReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "PurchaseInvoiceDatewiseReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SimStockOutReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SimStockOutReturnReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "SelfBillingInvoice")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "EmployeeSelfBillingReport")
                    //        //    flagReportTransaction = 1;

                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "CustomerWiseActivationReport")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "BillingTransaction")
                    //        //    flagReportTransaction = 1;
                    //        //else if (objResults.resultDT.Rows[i]["DisplayName"].ToString() == "DynamicBillingReport")
                    //        //    flagReportTransaction = 1;


                    //        #endregion
                    //    }
                    //    if (sRet != "NotAuthorized.aspx")
                    //    {
                    //        for (int j = 0; j < objResults.resultDT.Rows.Count; j++)
                    //        {
                    //            #region Not Authorized

                    //            if (sRet == "Home.aspx")
                    //            {
                    //                flag = 0;
                    //                break;
                    //            }
                    //            if (objResults.resultDT.Rows[j]["ScreenName"].ToString() == sRet)
                    //            {
                    //                flag = 0;
                    //                break;
                    //            }
                    //            flag = 1;
                    //            #endregion
                    //        }
                    //    }
                    //    if (flagMaster == 1)
                    //    {
                    //        liMaster.Visible = true;
                    //    }
                    //    else
                    //    {
                    //        liMaster.Visible = false;
                    //    }
                        
                    //    if (flag == 1)
                    //    {
                    //        Response.Redirect("../ClientUI/NotAuthorized.aspx", false);
                    //    }
                    //}
                    #endregion

                }
                else
                {
                    Response.Redirect("../Default.aspx", false);
                }
            }
        }
    }
}