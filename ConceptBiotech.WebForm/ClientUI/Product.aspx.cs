using System;
using System.Web.UI;
using log4net;
using System.Net.Http;
using System.Configuration;
using ConceptBiotech.UIEntity;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace ConceptBiotech.WebForm.ClientUI
{
    public partial class Product : PageBase
    {
        #region Declaration
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                ViewState["Mode"] = "Save";
                ViewState["ID"] = -1;
            }
        }

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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["PaymentURL"]);
                ListFilter filter = new ListFilter();
              //  filter.ShopId = Convert.ToInt32(Session["SHOPID"].ToString());
                HttpResponseMessage response = client.PostAsJsonAsync("v1/productmaster/Getall", filter).Result;
                if (response.IsSuccessStatusCode)
                {
                    var serializer = new JavaScriptSerializer();
                    var jsonObj = JsonConvert.DeserializeObject<RootObjectProduct>(response.Content.ReadAsStringAsync().Result);

                  //  RootObjectProduct[] jsonObj = JsonConvert.DeserializeObject<RootObjectProduct[]>(response.Content.ReadAsStringAsync().Result);

                    if (jsonObj != null)
                    {
                        //gvPrdouct.DataSource = jsonObj.data;
                        //gvPrdouct.DataBind();
                        PanelVisibility(blDivGrid: true, blDivPanel: false);
                    }
                    else
                    {
                        PanelVisibility(blDivGrid: false, blDivPanel: true);
                    }
                }
                //ApplicationResult objResult = new ApplicationResult(0);
                //objResult = new ProductsBL().Product_SelectAll();
                //DataTable objProductdt = new DataTable();
                //if (objResult != null)
                //{
                //    if (objResult.resultDT.Rows.Count > 0)
                //    {
                //        objProductdt = objResult.resultDT;
                //        gvPrdouct.DataSource = objProductdt;
                //        gvPrdouct.DataBind();
                //        PanelVisibility(blDivGrid: true, blDivPanel: false);
                //    }
                //    else
                //    {
                //        PanelVisibility(blDivGrid: false, blDivPanel: true);
                //    }
                //}
            }
        }
        #endregion

        #region BindProducts
        private void BindProducts()
        {
            //ApplicationResult objResult = new ApplicationResult();
            //objResult = new NetworksBL().Networks_SelectAll();

            //if (objResult != null)
            //{
            //    if (objResult.resultDT.Rows.Count > 0)
            //    {
            //        Controls objControls = new Controls();
            //        objControls.BindDropDown_ListBox(objResult.resultDT, ddlNetworkType, "Name", "ID");
            //    }
            //    else
            //    {
            //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>return alert('Please Add Product Group First.');</script>");
            //    }
            //    ddlNetworkType.Items.Insert(0, new ListItem("- None -", "-1"));
            //    ddlNetworkType.SelectedIndex = 1;
            //}
        }

        #region Clear All Control
        private void ClearAll()
        {
            //Controls objcontrol = new Controls();
            //objcontrol.ClearForm(Master.FindControl("MainBody"));
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
            //ViewState["Mode"] = "Save";
            //ViewState["ID"] = -1;
            PanelVisibility(false, true);
        }

        #endregion

        #region Save Button Event

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //ApplicationResult objResult = new ApplicationResult();
                //ProductsBO objProductBo = new ProductsBO();

                //objProductBo.code = txtProductCode.Text;
                //objProductBo.NetworkID = Convert.ToInt32(ddlNetworkType.SelectedValue);
                //objProductBo.IsDeleted = false;
                //objProductBo.IsActive = true;
                //objProductBo.CreatedDate = DateTime.UtcNow;
                //objProductBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID].ToString());
                //objProductBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.USERID].ToString());
                //objProductBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5);
                //if (ViewState["Mode"].ToString() == "Save")
                //{
                //    objResult = new ProductsBL().Product_Insert(objProductBo);
                //    if (objResult != null)
                //    {
                //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", objResult.status == ApplicationResult.CommonStatusType.SUCCESS
                //        ? "<script>alert('Record Saved Successfully.');</script>"
                //        : "<script>alert('Product is already exist for this Network.');</script>");
                //        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                //        {
                //            btnViewList_Click(sender, e);
                //        }
                //    }
                //}
                //else if (ViewState["Mode"].ToString() == "Edit")
                //{
                //    objProductBo.ID = Convert.ToInt32(ViewState["ID"].ToString());
                //    objResult = new ProductsBL().Product_Update(objProductBo);
                //    if (objResult != null)
                //    {
                //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", objResult.status == ApplicationResult.CommonStatusType.SUCCESS
                //        ? "<script>alert('Record Updated Successfully.');</script>"
                //        : "<script>alert('Product is already exist for this Network.');</script>");
                //        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                //        {
                //            btnViewList_Click(sender, e);
                //        }
                //    }

                //}
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