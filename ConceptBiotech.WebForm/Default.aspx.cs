using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace ConceptBiotech.WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            //if (!IsPostBack)
            //{ }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Email.Text.ToString().Trim() != "" && Password.Text.ToString().Trim() != "")
            {
                lblMessage.Text = "";
                using (var client = new HttpClient())
                {
                    UserUI user = new UserUI();
                    user.UN = Email.Text.ToString();
                    user.Pwd = Password.Text.ToString();

                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["PaymentURL"]);
                    HttpResponseMessage response = client.PostAsJsonAsync("v1/authenicate/Login", user).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var serializer = new JavaScriptSerializer();
                        var jsonObj = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                        //var userModel = Mapper.Map<UserUI, User>(jsonObj.data);
                        //return userModel;

                        //UserUI userdata = (new JavaScriptSerializer()).Deserialize<UserUI>(response.Content.ReadAsStringAsync().Result);
                        if (jsonObj.data != null)
                        {
                            Session["USERID"] = jsonObj.data.UIDN;
                            Session["SHOPID"] = "1";
                            Session["USERNAME"] = jsonObj.data.UN;
                           // RegisterHyperLink.NavigateUrl = "Product";
                            Response.Redirect("/ClientUI/Product.aspx");
                            // return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, userdata);
                        }
                        //else
                        {
                            // return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.BadGateway);
                        }
                    }
                    else
                    {
                        lblMessage.Text = "UserName and Password is wrong";
                    }
                }
            }
        }
    }
}