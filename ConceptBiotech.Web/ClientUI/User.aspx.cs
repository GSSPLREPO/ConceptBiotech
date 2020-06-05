using ConceptBiotech.BL;
using ConceptBiotech.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.Web.ClientUI
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ViewState["ID"] = "-1";
                    ViewState["Mode"] = "Save";
                    BindGrid();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
                }
            }
        }

        #region Bind Grid View
        private void BindGrid()
        {
            ApplicationResult objResult = new ApplicationResult();
            objResult = new UserBL().User_SelectAll();
            DataTable objProductdt = new DataTable();
            if (objResult != null)
            {
                if (objResult.resultDT.Rows.Count > 0)
                {
                    objProductdt = objResult.resultDT;
                    gvPrdouct.DataSource = objProductdt;
                    gvPrdouct.DataBind();
                }
            }
        }

        #endregion


        #region Product PreRender
        protected void gvUsers_PreRender(object sender, EventArgs e)
        {
            if (gvPrdouct.Rows.Count <= 0) return;
            gvPrdouct.UseAccessibleHeader = true;
            gvPrdouct.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion


        #region Product RowCommand
        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ApplicationResult objResult = new ApplicationResult();
            ViewState["ID"] = e.CommandArgument;
            if (e.CommandName == "Edit1")
            {
                objResult = new UserBL().User_Update_Status(Convert.ToInt32(ViewState["ID"].ToString()), 2);
                if (objResult != null)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", objResult.status == ApplicationResult.CommonStatusType.SUCCESS
                    ? "<script>alert('Record Status Update Successfully.');</script>"
                    : "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
                    BindGrid();
                }
            }
            else if (e.CommandName == "Delete1")
            {
                objResult = new UserBL().User_Update_Status(Convert.ToInt32(ViewState["ID"].ToString()), 0);
                if (objResult != null)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", objResult.status == ApplicationResult.CommonStatusType.SUCCESS
                    ? "<script>alert('Record Deleted Successfully.');</script>"
                    : "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
                    BindGrid();
                }
            }
        }
        #endregion

    }
}