using ConceptBiotech.BL;
using ConceptBiotech.Business;
using ConceptBiotech.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.Web.ClientUI
{
    public partial class Products : System.Web.UI.Page
    {
        #region Declaration
        ProductMaster productmaster = new ProductMaster();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ViewState["ID"] = "-1";
                    ViewState["Mode"] = "Save";
                    PanelVisibility(false, true);
                    BindGrid();
                    //  BindProducts();
                }

                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
                }
            }
        }

        #region userDefined Function

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
            objResult = new ProductsBL().Product_SelectAll();
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


        #region BindProducts
        //private void BindProducts()
        //{
        //    ApplicationResult objResult = new ApplicationResult();
        //    objResult = new NetworksBL().Networks_SelectAll();

        //    if (objResult != null)
        //    {
        //        if (objResult.resultDT.Rows.Count > 0)
        //        {
        //            Controls objControls = new Controls();
        //            objControls.BindDropDown_ListBox(objResult.resultDT, ddlNetworkType, "Name", "ID");
        //        }
        //        else
        //        {
        //            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>return alert('Please Add Product Group First.');</script>");
        //        }
        //        ddlNetworkType.Items.Insert(0, new ListItem("- None -", "-1"));
        //        ddlNetworkType.SelectedIndex = 1;
        //    }
        //}

        #region Clear All Control
        private void ClearAll()
        {
            HelperMethods objcontrol = new HelperMethods();
            objcontrol.ClearForm(Master.FindControl("MainBody"));
        }
        #endregion

        #endregion

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
                objResult = new ProductsBL().Product_Select(Convert.ToInt16(ViewState["ID"].ToString()));
                DataTable objProductdt = new DataTable();
                if (objResult != null)
                {
                    objProductdt = objResult.resultDT;
                    if (objProductdt.Rows.Count > 0)
                    {
                        txtProductName.Text = objProductdt.Rows[0]["ProductName"].ToString();
                        txtUnitName.Text = objProductdt.Rows[0]["UnitName"].ToString();
                        txtProductName.Text = objProductdt.Rows[0]["ProductName"].ToString();
                        txtSellingPrice.Text = objProductdt.Rows[0]["SellingRate"].ToString();
                        txtPurchasePrice.Text = objProductdt.Rows[0]["PurchaseRate"].ToString();
                        txtDescription.Text = objProductdt.Rows[0]["Description"].ToString();
                        if (objProductdt.Rows[0]["ImagePath"].ToString() != "")
                        {
                            imgCLogo.ImageUrl = objProductdt.Rows[0]["ImagePath"].ToString();
                            //byte[] bytes = (byte[])objProductdt.Rows[0]["ImagePath"];
                            //ViewState["Logo"] = bytes;
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //imgCLogo.ImageUrl = "data:image/png;base64," + base64String;
                        }
                        ViewState["Mode"] = "Edit";
                        PanelVisibility(false, true);
                    }
                }
            }
            else if (e.CommandName == "Delete1")
            {
                objResult = new ProductsBL().Product_Delete(Convert.ToInt32(ViewState["ID"].ToString()), Convert.ToInt32(Session[ApplicationSession.USERID].ToString()), DateTime.UtcNow);
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

                productmaster.ProductName = txtProductName.Text;
                productmaster.UnitName = txtUnitName.Text;
                productmaster.Code = txtProductName.Text;
                productmaster.SellingRate = Convert.ToDecimal(txtSellingPrice.Text);
                productmaster.PurchaseRate = Convert.ToDecimal(txtPurchasePrice.Text);
                productmaster.ShopId = 1;
                productmaster.Description = txtDescription.Text;
                //objProductBo.NetworkID = Convert.ToInt32(ddlNetworkType.SelectedValue);
                productmaster.Status = RecordStatus.Active;
                productmaster.CreatedDate = DateTime.UtcNow;
                productmaster.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID].ToString());
                productmaster.ModifiedBy = Convert.ToInt32(Session[ApplicationSession.USERID].ToString());
                productmaster.ModifiedDate = DateTime.UtcNow.AddHours(5.5);

                if (FULogo.HasFile)
                {
                    // objOrganisationBo.Logo = FULogo.FileBytes;
                    #region Document Upload

                    string Extension;
                    Extension = Path.GetExtension(FULogo.FileName.ToLower());
                    string strFileName = FULogo.FileName.Replace(' ', '_');
                    int filesize = (FULogo.PostedFile.ContentLength) / 1024;
                    //lblmsg.Text = Convert.ToString(filesize);
                    //int imgHeight = 
                    System.Drawing.Image img = System.Drawing.Image.FromStream(FULogo.PostedFile.InputStream);
                    int height = img.Height;
                    int width = img.Width;
                    if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".gif" || Extension == ".png")
                    {
                        //if (filesize < 50 && height == 50 || width == 150)
                        //{
                        string imgName = FULogo.FileName.ToString();
                        string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/CompanyLogo");
                        string imgPath = "../CompanyLogo/" + strFileName;
                        string FilePathOther = folderPath + "\\" + imgName;
                        //string filePath = Server.MapPath("../images/") + DateTime.UtcNow.AddHours(5.5).ToString("ddMMyy_") + DateTime.UtcNow.AddHours(5.5).ToString("HH") + "_" + DateTime.Now.ToString("mm") + "_" + strFileName;
                        //byte[] imageBytes = Convert.FromBase64String(Entity.Image);

                        //File.WriteAllBytes(FilePathOther, imageBytes);
                        FULogo.PostedFile.SaveAs(FilePathOther);
                        productmaster.ImagePath = string.Format("{0}{1}{2}", ConfigurationManager.AppSettings["basePath"], ConfigurationManager.AppSettings["CompanyLogoPath"], imgName);


                        //string filePath = Server.MapPath("~/CompanyLogo") + strFileName;

                        //objOrgBo.Logo = DateTime.UtcNow.AddHours(5.5).ToString("ddMMyy_") + DateTime.UtcNow.AddHours(5.5).ToString("HH") + "_" + DateTime.Now.ToString("mm") + "_" + strFileName;
                        //  objOrganisationBo.Logo = imgPath;
                        //}
                        //else
                        //{
                        //    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('File size should be less than 50 KB and Dimensions sholud be 150px Height & 100px Width.');</script>");
                        //}

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('File format not supported.');</script>");
                        //lblMsg.Visible = true;
                        //lblMsg.Text = "File format not supported.";
                    }

                    #endregion
                }

                if (ViewState["Mode"].ToString() == "Save")
                {
                    objResult = new ProductsBL().Product_Insert(productmaster);
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
                    productmaster.PK_Id = Convert.ToInt32(ViewState["ID"].ToString());
                    objResult = new ProductsBL().Product_Update(productmaster);
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