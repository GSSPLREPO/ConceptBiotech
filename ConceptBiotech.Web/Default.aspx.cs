using ConceptBiotech.BL;
using ConceptBiotech.Business;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Web.UI;

namespace ConceptBiotech.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                UserService objuserService = new UserService();

                User user = new User();
                user.Password = HelperMethods.Encrypt(txtPassword.Text, true);
                ApplicationResult objResult = new ApplicationResult();
                objResult = new UserBL().Employee_Select_ForLogin(txtUsername.Text.Trim(), user.Password);
                if (objResult != null)
                {
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        Session[ApplicationSession.USERID] = objResult.resultDT.Rows[0]["PK_ID"];
                        Session[ApplicationSession.USERNAME] = txtUsername.Text.Trim();
                        Session[ApplicationSession.ORGANISATIONID] = 1;
                        Session[ApplicationSession.ORGANISATIONNAME] = "";

                        Session[ApplicationSession.EMPLOYEENAME] = objResult.resultDT.Rows[0]["UserName"];
                        //if (Session[ApplicationSession.EMPLOYEENAME].ToString() != "")
                        //{
                        //    lblWelcome.Text = Session[ApplicationSession.EMPLOYEENAME].ToString();
                        //}
                        Response.Redirect("ClientUI/Dashboard.aspx", false);
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Username or Password";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid Username or Password";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("Default Page", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Opps!Something went Wrong.Contact Your Administrator.');</script>");
            }
        }
    }
}