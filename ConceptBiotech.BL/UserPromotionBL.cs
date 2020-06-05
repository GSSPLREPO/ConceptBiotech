using ConceptBiotech.Business;
using ConceptBiotech.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.BL
{
    public class UserPromotionBL
    {

        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region UserPromotions SelectAll

        public ApplicationResult UserPromotions_SelectAll()
        {
            try
            {
                pSqlParameter = new SqlParameter[0];

                sSql = "usp_tbl_UserPromotions_SelectAll";
                DataTable dtUserPromotions = new DataTable();
                dtUserPromotions = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtUserPromotions);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UserPromotions Select By ID

        public ApplicationResult UserPromotions_Select(int ID)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@PK_ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = ID;

                sSql = "usp_tbl_UserPromotions_Select";
                DataTable dtUserPromotions = new DataTable();
                dtUserPromotions = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtUserPromotions);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UserPromotions Delete
        public ApplicationResult UserPromotions_Delete(int intID, int intLastModifiedBy, DateTime strLastModifiedDate)
        {
            pSqlParameter = new SqlParameter[3];

            pSqlParameter[0] = new SqlParameter("@PK_ID", SqlDbType.Int);
            pSqlParameter[0].Direction = ParameterDirection.Input;
            pSqlParameter[0].Value = intID;

            pSqlParameter[1] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
            pSqlParameter[1].Direction = ParameterDirection.Input;
            pSqlParameter[1].Value = intLastModifiedBy;

            pSqlParameter[2] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
            pSqlParameter[2].Direction = ParameterDirection.Input;
            pSqlParameter[2].Value = strLastModifiedDate;

            sSql = "usp_tbl_UserPromotions_Delete";
            DataTable dtUserPromotions = new DataTable();
            dtUserPromotions = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

            ApplicationResult objResults = new ApplicationResult(dtUserPromotions);
            objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
            return objResults;
        }
        #endregion

        #region UserPromotions Insert
        public ApplicationResult UserPromotions_Insert(UserPromo objUserPromotionsBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[8];

                pSqlParameter[0] = new SqlParameter("@UserId", SqlDbType.BigInt);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objUserPromotionsBo.UserId;

                pSqlParameter[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objUserPromotionsBo.Code;

                pSqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objUserPromotionsBo.CreatedBy;

                pSqlParameter[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objUserPromotionsBo.CreatedDate;

                pSqlParameter[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objUserPromotionsBo.ModifiedBy;

                pSqlParameter[5] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objUserPromotionsBo.ModifiedDate;

                pSqlParameter[6] = new SqlParameter("@Status", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objUserPromotionsBo.Status;

                pSqlParameter[7] = new SqlParameter("@IsAvailable", SqlDbType.Bit);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objUserPromotionsBo.IsAvailable;

                sSql = "usp_tbl_UserPromotions_Insert";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.FAILURE;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserPromotionsBo = null;
            }
        }
        #endregion

        #region UserPromotions Update
        public ApplicationResult UserPromotions_Update(UserPromo objUserPromotionsBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[9];

                pSqlParameter[0] = new SqlParameter("@PK_Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objUserPromotionsBo.PK_Id;

                pSqlParameter[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objUserPromotionsBo.Code;

                pSqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objUserPromotionsBo.CreatedBy;

                pSqlParameter[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objUserPromotionsBo.CreatedDate;

                pSqlParameter[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objUserPromotionsBo.ModifiedBy;

                pSqlParameter[5] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objUserPromotionsBo.ModifiedDate;

                pSqlParameter[6] = new SqlParameter("@Status", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objUserPromotionsBo.Status;

                pSqlParameter[7] = new SqlParameter("@UserId", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objUserPromotionsBo.Code;

                pSqlParameter[8] = new SqlParameter("@IsAvailable", SqlDbType.Bit);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objUserPromotionsBo.IsAvailable;

                sSql = "usp_tbl_UserPromotions_Update";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.FAILURE;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserPromotionsBo = null;
            }
        }
        #endregion

        #region Validation
        public ApplicationResult UserPromotions_ValidateName(int intID, string strName)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intID;

                pSqlParameter[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                //pSqlParameter[2] = new SqlParameter("@NetworkID", SqlDbType.Int);
                //pSqlParameter[2].Direction = ParameterDirection.Input;
                //pSqlParameter[2].Value = NetworkID;

                strStoredProcName = "usp_tbl_UserPromotions_ValidateName";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
