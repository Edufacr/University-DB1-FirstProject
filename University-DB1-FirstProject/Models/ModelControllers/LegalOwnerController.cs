using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class LegalOwnerController
    {
        private SqlConnection connection;
        
        private SqlCommand InsertLegalOwner;
        private SqlCommand UpdateLegalOwner;

        private SqlCommand GetActiveLegalOwners;
        private SqlCommand GetLegalOwnerByDocValue;
        
        public LegalOwnerController(SqlConnection pConnection)
        {
            connection = pConnection;
            
            InsertLegalOwner = new SqlCommand("SP_insertLegalOwner", connection);
            InsertLegalOwner.CommandType = CommandType.StoredProcedure;
            
            
            UpdateLegalOwner = new SqlCommand("SP_updateLegalOwner", connection);
            UpdateLegalOwner.CommandType = CommandType.StoredProcedure;
            
            
            GetActiveLegalOwners = new SqlCommand("SP_getActiveLegalOwners", connection);
            GetActiveLegalOwners.CommandType = CommandType.StoredProcedure;
            
            GetLegalOwnerByDocValue = new SqlCommand("SP_getLegalOwnerInfoByDocValue", connection);
            GetLegalOwnerByDocValue.CommandType = CommandType.StoredProcedure;
        }


        public int ExecuteInsertLegalOwner(LegalOwnerRegisterModel legalOwner)
        {
            InsertLegalOwner.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value = legalOwner.ResponsibleName;
            InsertLegalOwner.Parameters.Add("@pResp_DocType_Id", SqlDbType.Int).Value = legalOwner.RespDocTypeId;
            InsertLegalOwner.Parameters.Add("@pResp_DocValue", SqlDbType.VarChar, 30).Value = legalOwner.RespDocValue;
            InsertLegalOwner.Parameters.Add("@pLegalOwner_DocValue", SqlDbType.VarChar, 30).Value = legalOwner.DocValue;
            
            return ExecuteNonQueryCommand(InsertLegalOwner);
            
        }
        
        public int ExecuteUpdateLegalOwner(LegalOwnerDisplayModel legalOwner)
        {
            UpdateLegalOwner.Parameters.Add("@pNewResponsibleName", SqlDbType.VarChar, 50).Value =
                legalOwner.ResponsibleName;
            UpdateLegalOwner.Parameters.Add("@pNewResp_DocId_type", SqlDbType.Int).Value = legalOwner.RespDocType;
            UpdateLegalOwner.Parameters.Add("@pNewResp_DocValue", SqlDbType.VarChar, 30).Value = legalOwner.RespDocValue;
            UpdateLegalOwner.Parameters.Add("@pLegalOwner_DocValue", SqlDbType.VarChar, 30).Value = legalOwner.DocValue;
            
            return ExecuteNonQueryCommand(UpdateLegalOwner);
        }

        public List<LegalOwnerDisplayModel> ExecuteGetActiveLegalOwners()
        {
            List<LegalOwnerDisplayModel> result = ExecuteQueryCommand(GetActiveLegalOwners);
            return result;
        }
        
        public List<LegalOwnerDisplayModel> ExecuteGetLegalOwnerByDocValue(LegalOwnerDisplayModel legalOwner)
        {
            GetLegalOwnerByDocValue.Parameters.Add("@pDocValue", SqlDbType.VarChar, 30).Value = legalOwner.DocValue;
            List<LegalOwnerDisplayModel> result = ExecuteQueryCommand(GetLegalOwnerByDocValue);
            return result;
            
        }
        
        public int ExecuteNonQueryCommand(SqlCommand command)
        {
            var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int result = (int)returnParameter.Value;
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        
        public List<LegalOwnerDisplayModel> ExecuteQueryCommand(SqlCommand command)
        {

            List<LegalOwnerDisplayModel> result = new List<LegalOwnerDisplayModel>();
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LegalOwnerDisplayModel legalOwner = new LegalOwnerDisplayModel();
                    
                    legalOwner.Name = Convert.ToString(reader["LegalName"]);
                    legalOwner.DocValue = Convert.ToString(reader["LegalDocValue"]);
                    legalOwner.ResponsibleName = Convert.ToString(reader["ResponsibleName"]);
                    legalOwner.RespDocValue = Convert.ToString(reader["RespDocValue"]);
                    legalOwner.RespDocType = Convert.ToString(reader["RespDocType"]);
                    
                    result.Add(legalOwner);
                    
                }
                
                connection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            return result;

        }
        

    }
}