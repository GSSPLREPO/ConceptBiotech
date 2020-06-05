using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConceptBiotech.WebForm
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Register_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                lblMessage.Text = "";
                using (var client = new HttpClient())
                {
                    UserUI user = new UserUI();
                    user.UN = txtEmail.Text.ToString();
                    user.Pwd = txtPassword.Text.ToString();

                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["PaymentURL"]);
                    HttpResponseMessage response = client.PostAsJsonAsync("v1/user/Add", user).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var serializer = new JavaScriptSerializer();
                        var jsonObj = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                        var userModel = Mapper.Map<UserUI, User>(jsonObj.data);
                        //return userModel;

                        //UserUI userdata = (new JavaScriptSerializer()).Deserialize<UserUI>(response.Content.ReadAsStringAsync().Result);
                        if (userModel != null)
                        {
                            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
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