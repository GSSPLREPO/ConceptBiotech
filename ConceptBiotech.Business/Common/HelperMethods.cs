using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ConceptBiotech.Business
{
    public class HelperMethods
    {

        private static readonly string[] UnitsMap = new[]
{
    "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN",
    "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN",
    "EIGHTEEN", "NINETEEN"
};

        private static readonly string[] TensMap = new[]
        {
    "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY",
    "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
};

        private static readonly string[] ScaleMap = new[]
        { "", " THOUSAND", " MILLION", " BILLION", " TRILLION", " QUADRILLION" };

        static IEnumerable<int> SplitIntoThousands(long number)
        {
            while (number != 0)
            {
                yield return (int)(number % 1000);
                number /= 1000;
            }
        }

        static string SmallNumberToWords(int number)
        {
            string result = null;

            if (number > 0)
            {
                if (number >= 100)
                {
                    var hundrets = SmallNumberToWords(number / 100);
                    var tens = SmallNumberToWords(number % 100);

                    result = hundrets + " HUNDRED";

                    if (tens != null)
                        result += ' ' + tens;
                }
                else if (number < 20)
                    result = UnitsMap[number];
                else
                {
                    result = TensMap[number / 10];
                    if ((number % 10) > 0)
                        result += "-" + UnitsMap[number % 10];
                }
            }

            return result;
        }

        public static string ConvertNumbertoWords(long number)
        {
            if (number == 0)
                return "ZERO";

            if (number < 0)
                return "MINUS " + -number;

            var thousands = SplitIntoThousands(number).ToArray();

            var result = new StringBuilder();

            for (int i = thousands.Length - 1; i >= 0; i--)
            {
                var word = SmallNumberToWords(thousands[i]);

                if (word != null)
                {
                    if (result.Length > 0)
                    {
                        if (i == 0)
                            result.Append(" AND ");
                        else
                            result.Append(' ');
                    }
                    result.Append(word);
                    result.Append(ScaleMap[i]);
                }
            }

            return result.ToString();
        }


        //METHODS FOR ENCRYPT AND DECRYPT PASSWORD
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string saveImageOnfile(string imgs, string basePath, string imageLocation)
        {
            if (imgs != null)
            {
                imgs = saveSingleImageOnfile(imgs, basePath, imageLocation);
                //for (int i = 0; i < imgs.Count(); i++)
                //{
                //    imgs[i] = saveSingleImageOnfile(imgs[i], basePath, imageLocation);
                //}
                return imgs;//.Where(a => a.operationType != 1).ToList();
            }
            else
            {
                return null;
            }
        }

        public static string saveSingleImageOnfile(string imgs, string basePath, string imageLocation)
        {
            string filename = imgs;

           // string format = filename.Substring(filename.LastIndexOf('.') + 1);



           // if (imgs.operationType == 0) //added
            {
                filename = filename.Substring(0, filename.LastIndexOf('.'));
                if (!Directory.Exists(basePath + imageLocation))
                {
                    Directory.CreateDirectory(basePath + imageLocation);

                }
                //check exists here -- imgs.name
                if (File.Exists(basePath + imageLocation + filename + "." + "png"))
                {
                    filename = filename + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss_tt") + "." + "png";
                }
                else
                {
                    filename = filename + "." + "png";
                }


                string base64 = imgs.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64);

                //if (format.ToLower() == "xls" || format.ToLower() == "xlsx")
                //{
                //    File.WriteAllBytes(string.Format("{0}{1}{2}", basePath, imageLocation, filename), bytes);
                //}
                //else
                {
                    //using (System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(bytes)))
                    //{
                    //    //image.Save(string.Format("{0}{1}{2}", basePath, imageLocation, filename));
                    //    CompressImage(image, 30, basePath, imageLocation, filename);

                    //}
                }
               // imgs.name = filename;
                imgs = string.Format("{0}{1}{2}", ConfigurationManager.AppSettings["basePath"], imageLocation, filename);


            }
            //if (imgs.operationType == 1)
            //{
            //    if (File.Exists(basePath + imageLocation + filename))
            //    {
            //        File.Delete(basePath + imageLocation + filename);
            //    }
            //}

            return imgs;
        }

        public static System.Drawing.Image Base64ToImage(string Base64String)
        {
            try
            {
                //byte[] imageBytes = Convert.FromBase64String(Base64String);
                byte[] imageBytes = Convert.FromBase64String(Base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
            }
            catch (Exception ex)
            {
                return null;
                //log.Error("Lead Select All", ex);
                //return "Try Again";
            }
        }

        public void ClearForm(Control Container)
        {
            foreach (Control ctrl in Container.Controls)
            {
                if (Container.Controls.Count > 0)
                {
                    ClearForm(ctrl);
                }
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = "";
                }
                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).SelectedIndex = -1;
                }
                if (ctrl is HtmlInputHidden)
                {
                    ((HtmlInputHidden)ctrl).Value = "";
                }
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }

            }
        }
        public void ValidatorsHandle(Control Container)
        {
            foreach (Control ctrl in Container.Controls)
            {
                if (Container.Controls.Count > 0)
                {
                    ValidatorsHandle(ctrl);
                }
                if (ctrl is RequiredFieldValidator)
                {
                    ((RequiredFieldValidator)ctrl).Enabled = true;
                    ((RequiredFieldValidator)ctrl).Text = "*";
                }
                if (ctrl is CompareValidator)
                {
                    ((CompareValidator)ctrl).Enabled = true;
                    ((CompareValidator)ctrl).Text = "*";
                }
                if (ctrl is RegularExpressionValidator)
                {
                    ((RegularExpressionValidator)ctrl).Enabled = true;
                    ((RegularExpressionValidator)ctrl).Text = "*";
                }
                if (ctrl is CustomValidator)
                {
                    ((CustomValidator)ctrl).Enabled = true;
                    ((CustomValidator)ctrl).Text = "*";
                }
            }
        }

        public void DisableValidatorsHandle(Control Container)
        {
            foreach (Control ctrl in Container.Controls)
            {
                if (Container.Controls.Count > 0)
                {
                    DisableValidatorsHandle(ctrl);
                }
                if (ctrl is RequiredFieldValidator)
                {
                    ((RequiredFieldValidator)ctrl).Enabled = true;
                    ((RequiredFieldValidator)ctrl).Text = "";
                }
                if (ctrl is CompareValidator)
                {
                    ((CompareValidator)ctrl).Enabled = true;
                    ((CompareValidator)ctrl).Text = "";
                }
                if (ctrl is RegularExpressionValidator)
                {
                    ((RegularExpressionValidator)ctrl).Enabled = true;
                    ((RegularExpressionValidator)ctrl).Text = "";
                }
                if (ctrl is CustomValidator)
                {
                    ((CustomValidator)ctrl).Enabled = true;
                    ((CustomValidator)ctrl).Text = "";
                }
            }
        }
        public void ClearFormWithoutReadOnlyControl(Control Container)
        {
            foreach (Control ctrl in Container.Controls)
            {
                //if (Container.Controls.Count > 0)
                //{
                //    ClearForm(ctrl);
                //}
                if (ctrl is TextBox)
                {
                    if (((TextBox)ctrl).ReadOnly == false)
                    {
                        ((TextBox)ctrl).Text = "";
                    }
                }

            }
        }

        public void BindDropDown_ListBox(DataTable dt, Control ctrl, string DataTextField, string DataValueField)
        {
            if (ctrl is DropDownList)
            {
                ((DropDownList)ctrl).DataSource = dt;
                ((DropDownList)ctrl).DataTextField = DataTextField;
                ((DropDownList)ctrl).DataValueField = DataValueField;
                ((DropDownList)ctrl).DataBind();

            }
            else if (ctrl is ListBox)
            {
                ((ListBox)ctrl).DataSource = dt;
                ((ListBox)ctrl).DataTextField = DataTextField;
                ((ListBox)ctrl).DataValueField = DataValueField;
                ((ListBox)ctrl).DataBind();
            }
            else if (ctrl is CheckBoxList)
            {
                ((CheckBoxList)ctrl).DataSource = dt;
                ((CheckBoxList)ctrl).DataTextField = DataTextField;
                ((CheckBoxList)ctrl).DataValueField = DataValueField;
                ((CheckBoxList)ctrl).DataBind();
            }
            else if (ctrl is RadioButtonList)
            {
                ((RadioButtonList)ctrl).DataSource = dt;
                ((RadioButtonList)ctrl).DataTextField = DataTextField;
                ((RadioButtonList)ctrl).DataValueField = DataValueField;
                ((RadioButtonList)ctrl).DataBind();
            }
        }

    }
}
