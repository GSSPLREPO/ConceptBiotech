using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    /// <summary>
    /// Summary description for Application Result.
    /// </summary>
    public class ApplicationResult
    {
        public CommonStatusType status;
        public string errorException;
        public DataTable resultDT;
        public DataSet resultDS;
        public object resultObj;
        public int resultInt = 0;


        public enum CommonStatusType
        {
            FAILURE = 0,
            SUCCESS = 1,
            RECORD = 2,
            RECORD_EXISTS = 3,
            RECORD_NOTEXISTS = 4,
            RECORD_FK_VIOLATION = 5

        }


        public ApplicationResult()
        {
            status = CommonStatusType.SUCCESS;
            errorException = null;
            resultDT = null;
            resultDS = null;
            resultObj = null;
            resultInt = 0;
        }


        public ApplicationResult(DataTable dt)
        {
            //
            // TODO: Add constructor logic here
            //
            status = CommonStatusType.SUCCESS;
            errorException = null;
            resultDT = dt;
            resultObj = null;
            resultInt = 0;
        }

        public ApplicationResult(DataSet ds)
        {
            //
            // TODO: Add constructor logic here
            //
            status = CommonStatusType.SUCCESS;
            errorException = null;
            //resultDT = dt;
            resultDS = ds;
            resultObj = null;
            resultInt = 0;
        }


        public ApplicationResult(string errMsg)
        {
            //
            // TODO: Add constructor logic here
            //
            status = CommonStatusType.FAILURE;
            errorException = errMsg;
            resultDT = null;
            resultDS = null;
            resultObj = null;
            resultInt = 0;

        }

        public ApplicationResult(int integerresult)
        {
            //
            // TODO: Add constructor logic here
            //
            status = CommonStatusType.SUCCESS;
            errorException = null;
            resultDT = null;
            resultDS = null;
            resultObj = null;
            resultInt = integerresult;
        }

        public ApplicationResult(object objResult)
        {
            status = CommonStatusType.SUCCESS;
            errorException = null;
            resultDT = null;
            resultDS = null;
            resultObj = objResult;
            resultInt = 0;
        }
    }
}
