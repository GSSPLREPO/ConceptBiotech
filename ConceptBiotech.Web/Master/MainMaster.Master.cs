using ConceptBiotech.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.Web.Master
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session[ApplicationSession.USERID] != null)
                {
                    int flagMaster = 1;
                    if (flagMaster == 1)
                    {
                        liMaster.Visible = true;
                    }
                    else
                    {
                        liMaster.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("../Default.aspx", false);
                }
            }
        }

    }

}


