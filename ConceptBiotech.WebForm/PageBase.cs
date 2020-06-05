using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptBiotech.WebForm
{
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["USERID"] == null)
            {
                Response.Redirect("../Default.aspx?SessionMode=Logout");
            }
        }
    }
}