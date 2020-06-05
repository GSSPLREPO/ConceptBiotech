using ConceptBiotech.BL;
using ConceptBiotech.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ConceptBiotech.Web.WebMethods
{
    /// <summary>
    /// Summary description for ValidateName
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ValidateName : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region Validate Material Name
        [WebMethod]
        public string ValidateMaterialName(int intId, string strName)
        {
            try
            {
                ProductsBL objMaterialBl = new ProductsBL();
                ApplicationResult objResult = new ApplicationResult();
                objResult = objMaterialBl.Product_ValidateName(intId, strName);
                if (objResult != null)
                {
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        return "Not Available";
                    }
                    else
                    {
                        return "Available";
                    }
                }
                return "Try Again";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        #endregion
    }
}
