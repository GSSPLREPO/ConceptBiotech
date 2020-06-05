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
    public class ProductsBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Product SelectAll

        public ApplicationResult Product_SelectAll()
        {
            try
            {
                pSqlParameter = new SqlParameter[0];

                sSql = "usp_tbl_ProductMasters_SelectAll";
                DataTable dtProduct = new DataTable();
                dtProduct = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtProduct);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Product Select By ID

        public ApplicationResult Product_Select(int ID)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@PK_ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = ID;

                sSql = "usp_tbl_ProductMasters_Select";
                DataTable dtProduct = new DataTable();
                dtProduct = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtProduct);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Product Delete

        public ApplicationResult Product_Delete(int intID, int intLastModifiedBy, DateTime strLastModifiedDate)
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

            sSql = "usp_tbl_ProductMasters_Delete";
            DataTable dtProduct = new DataTable();
            dtProduct = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

            ApplicationResult objResults = new ApplicationResult(dtProduct);
            objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
            return objResults;
        }

        #endregion

        #region Product Insert

        public ApplicationResult Product_Insert(ProductMaster objProductBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[13];

                pSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objProductBo.ProductName;

                pSqlParameter[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objProductBo.Code;

                pSqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objProductBo.CreatedBy;

                pSqlParameter[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objProductBo.CreatedDate;

                pSqlParameter[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objProductBo.ModifiedBy;

                pSqlParameter[5] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objProductBo.ModifiedDate;

                pSqlParameter[6] = new SqlParameter("@Status", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objProductBo.Status;

                pSqlParameter[7] = new SqlParameter("@Description", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objProductBo.Description;

                pSqlParameter[8] = new SqlParameter("@SellingRate", SqlDbType.Decimal);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objProductBo.SellingRate;

                pSqlParameter[9] = new SqlParameter("@PurchaseRate", SqlDbType.Decimal);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objProductBo.PurchaseRate;

                pSqlParameter[10] = new SqlParameter("@UnitName", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objProductBo.UnitName;

                pSqlParameter[11] = new SqlParameter("@ShopId", SqlDbType.BigInt);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objProductBo.ShopId;

                pSqlParameter[12] = new SqlParameter("@ImagePath", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objProductBo.ImagePath;



                sSql = "usp_tbl_ProductMasters_Insert";
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
                objProductBo = null;
            }
        }

        #endregion

        #region Product Update

        public ApplicationResult Product_Update(ProductMaster objProductBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[14];

                pSqlParameter[0] = new SqlParameter("@PK_Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objProductBo.PK_Id;

                pSqlParameter[1] = new SqlParameter("@Code", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objProductBo.Code;

                pSqlParameter[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objProductBo.CreatedBy;

                pSqlParameter[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objProductBo.CreatedDate;

                pSqlParameter[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objProductBo.ModifiedBy;

                pSqlParameter[5] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objProductBo.ModifiedDate;

                pSqlParameter[6] = new SqlParameter("@Status", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objProductBo.Status;

                pSqlParameter[7] = new SqlParameter("@Description", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objProductBo.Description;

                pSqlParameter[8] = new SqlParameter("@SellingRate", SqlDbType.Decimal);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objProductBo.SellingRate;

                pSqlParameter[9] = new SqlParameter("@PurchaseRate", SqlDbType.Decimal);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objProductBo.PurchaseRate;

                pSqlParameter[10] = new SqlParameter("@UnitName", SqlDbType.VarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objProductBo.UnitName;

                pSqlParameter[11] = new SqlParameter("@ShopId", SqlDbType.BigInt);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objProductBo.ShopId;


                pSqlParameter[12] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objProductBo.ProductName;

                pSqlParameter[13] = new SqlParameter("@ImagePath", SqlDbType.VarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objProductBo.ImagePath;

                sSql = "usp_tbl_ProductMasters_Update";
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
                objProductBo = null;
            }
        }
        #endregion

        #region Validation
        public ApplicationResult Product_ValidateName(int intID, string strName)
        {

            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intID;

                pSqlParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strName;

                //pSqlParameter[2] = new SqlParameter("@NetworkID", SqlDbType.Int);
                //pSqlParameter[2].Direction = ParameterDirection.Input;
                //pSqlParameter[2].Value = NetworkID;

                strStoredProcName = "usp_tbl_ProductMasters_ValidateName";

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
