using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace ConceptBiotech.WebAPI
{
    /// <summary>
    /// Common Funcionalities for Api Project
    /// </summary>
    public class Common
    {
        /// <summary>
        /// sets default values For record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetDefaultValues<T>(T obj) where T : BaseEntity
        {
            long userId = 0;
            if (System.Threading.Thread.CurrentPrincipal != null)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    userId = basicAuthenticationIdentity.UserId;
                }
            }
            obj.CBy = userId;
            if (obj.CBy > 0)
            {
                obj.CBy = userId;
                obj.St = UIRecordStatus.Active;
            }
            if (obj.CDt == null)
            {
                obj.CDt = DateTime.Now;
            }
            obj.MBy = userId;
            obj.MDt = DateTime.Now;

            return obj;
        }

        /// <summary>
        /// sets default values For record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetMultiDefaultValues<T>(IEnumerable<T> obj) where T : BaseEntity
        {
            long userId = 0;
            if (System.Threading.Thread.CurrentPrincipal != null)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    userId = basicAuthenticationIdentity.UserId;
                }
            }
            foreach (var item in obj)
            {
                item.CBy = userId;
                if (item.CBy > 0)
                {
                    item.CBy = userId;
                }
                if (item.CDt == null)
                {
                    item.CDt = DateTime.Now;
                }
                item.MBy = userId;
                item.MDt = DateTime.Now;
                item.St = UIRecordStatus.Active;
            }
            return obj;
        }

        /// <summary>
        /// Get Current Ip Address
        /// </summary>
        /// <returns></returns>
        public static string GetIpAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        /// <summary>
        /// Reeturns Current User Agent Details
        /// </summary>
        /// <returns></returns>
        public static string GetUserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static tokenData getBasetokenData(bool addRoleData = false)
        {
            tokenData _tokenData = new tokenData();
            if (System.Threading.Thread.CurrentPrincipal != null)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    _tokenData.UserName = basicAuthenticationIdentity.UserName;
                    _tokenData.gblUserId = basicAuthenticationIdentity.UserId;
                }
            }
            return _tokenData;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string EncryptAES(string plainText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    plainText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return plainText;

        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string DecryptAES(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;

        }

    }



    /// <summary>
    ///
    /// </summary>
    public class tokenData
    {
        public string UserName { get; set; }

        /// <summary>
        /// GlobalCompanyId
        /// </summary>
        public long glbShopId { get; set; }

        ///// <summary>
        ///// GlobalSignupId
        ///// </summary>
        //public long glbSignup { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public long gblUserId { get; set; }



        /// <summary>
        /// 
        /// </summary>
        public UserTypeUI userType { get; set; }
    }
}