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
            InsertLegalOwner.Parameters.Add("@pResp_DocValue", SqlDbType.Int).Value = legalOwner.RespDocValue;
            InsertLegalOwner.Parameters.Add("@pLegalOwner_DocValue", SqlDbType.Int).Value = legalOwner.DocValue;
            
            return ExecuteNonQueryCommand(InsertLegalOwner);
            
        }
        
        public int ExecuteUpdateLegalOwner(LegalOwnerDisplayModel legalOwner)
        {
            UpdateLegalOwner.Parameters.Add("@pNewResponsibleName", SqlDbType.VarChar, 50).Value =
                legalOwner.ResponsibleName;
            UpdateLegalOwner.Parameters.Add("@pNewResp_DocId_type", SqlDbType.Int).Value = legalOwner.RespDocType;
            UpdateLegalOwner.Parameters.Add("@pNewResp_DocValue", SqlDbType.Int).Value = legalOwner.RespDocValue;
            UpdateLegalOwner.Parameters.Add("@pLegalOwner_DocValue", SqlDbType.Int).Value = legalOwner.DocValue;
            
            return ExecuteNonQueryCommand(UpdateLegalOwner);
        }

        public List<LegalOwnerDisplayModel> ExecuteGetActiveLegalOwners()
        {
            List<LegalOwnerDisplayModel> result = ExecuteQueryCommand(GetActiveLegalOwners);
            return result;
        }
        
        public List<LegalOwnerDisplayModel> ExecuteGetLegalOwnerByDocValue(LegalOwnerDisplayModel legalOwner)
        {
            GetActiveLegalOwners.Parameters.Add("@pDocValue", SqlDbType.Int).Value = legalOwner.DocValue;
            List<LegalOwnerDisplayModel> result = ExecuteQueryCommand(GetLegalOwnerByDocValue);
            return result;
            
        }
        
        public int ExecuteNonQueryCommand(SqlCommand command)
        {
            int result;
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
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
                    legalOwner.DocValue = Convert.ToInt32(reader["LegalDocValue"]);
                    legalOwner.ResponsibleName = Convert.ToString(reader["ResponsibleName"]);
                    legalOwner.RespDocValue = Convert.ToInt32(reader["RespDocValue"]);
                    legalOwner.RespDocType = Convert.ToString(reader["Doctype"]);
                    
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