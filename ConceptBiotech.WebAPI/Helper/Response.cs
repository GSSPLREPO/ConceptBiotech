using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ConceptBiotech.WebAPI
{
    public class Response
    {/// <summary>
     /// represents code for custom error
     /// </summary>
        public int custom_code { get; set; }

        /// <summary>
        /// represents message according to response code
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// represents respose data
        /// </summary>
        public object data { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="custom_code"></param>
        /// <param name="result"></param>
        /// <param name="status_code"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static HttpResponseMessage CreateResponse(ResultCodes custom_code = 0, HttpStatusCode status_code = HttpStatusCode.OK, object result = null, Exception ex = null)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            if (status_code == HttpStatusCode.OK)
            {
                return request.CreateResponse(status_code, new Response(custom_code, result));
            }
            else if (ex != null)
            {
                return request.CreateErrorResponse(status_code, ex);
            }
            else
            {
                if (result == null)
                    return request.CreateErrorResponse(status_code, CodeMessage.ResponseMessage[custom_code].ToString());
                else
                    return request.CreateResponse(status_code, new Response(custom_code, result));
            }
        }

        /// <summary>
        /// Constructor to get message from code.
        /// </summary>
        /// <param name="customCode"></param>
        /// <param name="result"></param>
        public Response(ResultCodes customCode, dynamic result)
        {
            custom_code = (int)customCode;
            data = result;
            message = CodeMessage.ResponseMessage[customCode].ToString();
        }
    }

    /// <summary>
    /// Custom codes for api response
    /// </summary>
    public enum ResultCodes
    {
        /// <summary>
        /// Successsfull processed
        /// </summary>
        Success = 1000,

        /// <summary>
        /// Runtime Error
        /// </summary>
        InternalError = 1001,

        /// <summary>
        /// Used for name exists
        /// </summary>
        NameExist = 1002,

        /// <summary>
        /// Improper Data
        /// </summary>
        DataValidationError = 1003,

        /// <summary>
        /// No Records Found
        /// </summary>
        RecordsNotFound = 1004,

        /// <summary>
        /// UnAuthorized Request
        /// </summary>
        UnAuthorize = 1005,

        /// <summary>
        /// Already Exist
        /// </summary>
        AlreadyExist = 1006,
    }

    /// <summary>
    ///
    /// </summary>
    public class CodeMessage
    {
        private static readonly object lockObj = new object();
        private static Dictionary<ResultCodes, string> _res;

        /// <summary>
        ///
        /// </summary>
        public static Dictionary<ResultCodes, string> ResponseMessage
        {
            get
            {
                lock (lockObj)
                {
                    if (_res == null)
                    {
                        _res = new Dictionary<ResultCodes, string>();
                        _res.Add(ResultCodes.Success, "Successfully processed.");
                        _res.Add(ResultCodes.InternalError, "Some error occured, Please try again!.");
                        _res.Add(ResultCodes.NameExist, "User name already exists.");
                        _res.Add(ResultCodes.DataValidationError, "Please pass proper data");
                        _res.Add(ResultCodes.RecordsNotFound, "Records not found");
                        _res.Add(ResultCodes.UnAuthorize, "UnAuthorized Request");
                        _res.Add(ResultCodes.AlreadyExist, "Already Exist");
                    }
                }
                return _res;
            }
        }
    }
}