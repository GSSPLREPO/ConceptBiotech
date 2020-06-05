using ConceptBiotech.BL;
using ConceptBiotech.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.Web.ClientUI
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        decimal grdTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindCustomer();
                }
                catch (Exception ex)
                {
                    log.Error("Page_Load", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
                }
            }
        }

        #region BindCustomer
        private void BindCustomer()
        {
            ApplicationResult objResult = new ApplicationResult();
            objResult = new OrderBL().Order_Select(0);

            if (objResult != null)
            {
                if (objResult.resultDT.Rows.Count > 0)
                {
                    gvCustomer.DataSource = objResult.resultDT;
                    gvCustomer.DataBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>return alert('Please Add Customer First.');</script>");
                }
                //ddlCustomer.Items.Insert(0, new ListItem("- None -", "-1"));
                //ddlCustomer.SelectedIndex = 0;
            }
        }
        #endregion

        protected void gvCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)

            {
                decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TAmt"));
                grdTotal = grdTotal + rowTotal;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblCostTotal");
                lbl.Text = grdTotal.ToString();
            }
        }
    }
}