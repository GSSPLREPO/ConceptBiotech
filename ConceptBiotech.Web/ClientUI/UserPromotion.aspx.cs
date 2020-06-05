using ConceptBiotech.BL;
using ConceptBiotech.Business;
using ConceptBiotech.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.Web.ClientUI
{
    public partial class UserPromotion : System.Web.UI.Page
    {
        #region Declaration
        UserPromo userPromotion = new UserPromo();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                BindUserType();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
            }
        }

        #region BindUserType
        private void BindUserType()
        {
            ApplicationResult objResult = new ApplicationResult();
            objResult = new UserBL().User_SelectAll();
            if (objResult != null)
            {
                if (objResult.resultDT.Rows.Count > 0)
                {
                    HelperMethods objControls = new HelperMethods();
                    objControls.BindDropDown_ListBox(objResult.resultDT, ddlUserList, "Name", "ID");
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>return alert('Please Add Users First.');</script>");
                }
                ddlUserList.Items.Insert(0, new ListItem("- Select User Type -", "-1"));
                ddlUserList.SelectedIndex = 1;
            }
        }
        #endregion

        #region Panel Visiblity
        private void PanelVisibility(bool blDivGrid, bool blDivPanel)
        {
            divGrid.Visible = blDivGrid;
            divPanel.Visible = blDivPanel;
        }

        #endregion

        #region Bind Grid View
        private void BindGrid()
        {
            ApplicationResult objResult = new ApplicationResult(0);
            objResult = new UserPromotionBL().UserPromotions_SelectAll();
            DataTable objProductdt = new DataTable();
            if (objResult != null)
            {
                if (objResult.resultDT.Rows.Count > 0)
                {
                    objProductdt = objResult.resultDT;
                    gvPrdouct.DataSource = objProductdt;
                    gvPrdouct.DataBind();
                    PanelVisibility(blDivGrid: true, blDivPanel: false);
                }
                else
                {
                    PanelVisibility(blDivGrid: false, blDivPanel: true);
                }
            }
        }

        #endregion


        #region Clear All Control
        private void ClearAll()
        {
            HelperMethods objcontrol = new HelperMethods();
            objcontrol.ClearForm(Master.FindControl("MainBody"));
        }
        #endregion


        #region Gridview

        #region Product RowCommand
        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ApplicationResult objResult = new ApplicationResult();
            ViewState["ID"] = e.CommandArgument;
            if (e.CommandName == "Edit1")
            {
                //BindProducts();
                objResult = new UserPromotionBL().UserPromotions_Select(Convert.ToInt16(ViewState["ID"].ToString()));
                DataTable objProductdt = new DataTable();
                if (objResult != null)
                {
                    objProductdt = objResult.resultDT;
                    if (objProductdt.Rows.Count > 0)
                    {
                        txtCode.Text = objProductdt.Rows[0]["Code"].ToString();
                        ddlUserList.SelectedValue= objProductdt.Rows[0]["UserId"].ToString();
                        ViewState["Mode"] = "Edit";
                        PanelVisibility(false, true);
                    }
                }
            }
            else if (e.CommandName == "Delete1")
            {
                objResult = new UserPromotionBL().UserPromotions_Delete(Convert.ToInt32(ViewState["ID"].ToString()), Convert.ToInt32(Session[ApplicationSession.USERID].ToString()), DateTime.UtcNow);
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

        #region Product PreRender
        protected void gvProducts_PreRender(object sender, EventArgs e)
        {
            if (gvPrdouct.Rows.Count <= 0) return;
            gvPrdouct.UseAccessibleHeader = true;
            gvPrdouct.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion
        #endregion

        #region BUtton Event

        #region ViewList Button Event
        protected void btnViewList_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                log.Error("View List Button", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
            }
        }
        #endregion

        #region Add Button Event
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            ViewState["Mode"] = "Save";
            ViewState["ID"] = -1;
            PanelVisibility(false, true);
        }

        #endregion

        #region Save Button Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                //ProductsBO objProductBo = new ProductsBO();

                userPromotion.Code = txtCode.Text;
                userPromotion.UserId = Convert.ToInt32(ddlUserList.SelectedValue);
                userPromotion.IsAvailable = true;
                userPromotion.Status = RecordStatus.Active;
                userPromotion.CreatedDate = DateTime.UtcNow;
                userPromotion.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID].ToString());
                userPromotion.ModifiedBy = Convert.ToInt32(Session[ApplicationSession.USERID].ToString());
                userPromotion.ModifiedDate = DateTime.UtcNow.AddHours(5.5);

               
                if (ViewState["Mode"].ToString() == "Save")
                {
                    objResult = new UserPromotionBL().UserPromotions_Insert(userPromotion);
                    if (objResult != null)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", objResult.status == ApplicationResult.CommonStatusType.SUCCESS
                        ? "<script>alert('Record Saved Successfully.');</script>"
                        : "<script>alert('Product is already exist for this Network.');</script>");
                        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            btnViewList_Click(sender, e);
                        }
                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    userPromotion.PK_Id = Convert.ToInt32(ViewState["ID"].ToString());
                    objResult = new UserPromotionBL().UserPromotions_Update(userPromotion);
                    if (objResult != null)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", objResult.status == ApplicationResult.CommonStatusType.SUCCESS
                        ? "<script>alert('Record Updated Successfully.');</script>"
                        : "<script>alert('Product is already exist for this Network.');</script>");
                        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            btnViewList_Click(sender, e);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Save_Button", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
            }
        }

        #endregion

        #endregion

    }
}