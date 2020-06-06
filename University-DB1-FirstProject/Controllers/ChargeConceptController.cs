using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class ChargeConceptController
    {
        private SqlConnection connection;

        private SqlCommand InsertCCProperty;
        private SqlCommand DeleteCCProperty;
        private SqlCommand UpdateCCProperty;

        private SqlCommand GetCCsOnProperty;
        private SqlCommand GetCcChildValue;
        
        public ChargeConceptController()
        {
            
            InsertCCProperty = new SqlCommand("SP_insertCC_onPropety", connection);
            InsertCCProperty.CommandType = CommandType.StoredProcedure;
            
            DeleteCCProperty = new SqlCommand("SP_deleteCC_onProperty", connection);
            DeleteCCProperty.CommandType = CommandType.StoredProcedure;
            
            UpdateCCProperty = new SqlCommand("sp_updateCC_onProperty", connection);
            UpdateCCProperty.CommandType = CommandType.StoredProcedure;
            
            GetCCsOnProperty = new SqlCommand("SP_getActiveCCs_ofProperty", connection);
            GetCCsOnProperty.CommandType = CommandType.StoredProcedure;
            
            GetCcChildValue = new SqlCommand("SP_getChildValue", connection);
            GetCcChildValue.CommandType = CommandType.StoredProcedure;
            
        }


        public int ExecuteInsertCCProperty(CC_onPropertyRegisterModel chargeConcept, PropertyDisplayModel property)
        {

            InsertCCProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            InsertCCProperty.Parameters.Add("@pChargeConceptName", SqlDbType.VarChar, 50).Value = chargeConcept.ChargeConceptName;
            InsertCCProperty.Parameters.Add("@pBeginDate", SqlDbType.Date).Value = chargeConcept.BeginDate;
            
            return ExecuteNonQueryCommand(InsertCCProperty);
            
        }
        
        public int ExecuteDeleteCCProperty(CCPropertyDisplayModel chargeConcept, PropertyDisplayModel property)
        {
            
            DeleteCCProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            DeleteCCProperty.Parameters.Add("@pCCName", SqlDbType.VarChar, 50).Value = chargeConcept.ChargeConceptName;
            
            return ExecuteNonQueryCommand(DeleteCCProperty);
            
        }
        
        public int ExecuteUpdateCCProperty(CCPropertyDisplayModel originalChargeConcept, PropertyDisplayModel property,
            CCPropertyDisplayModel changedChargeConcept)
        
        {
            
            UpdateCCProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            UpdateCCProperty.Parameters.Add("@pCCName", SqlDbType.VarChar, 50).Value = originalChargeConcept.ChargeConceptName;
            
            UpdateCCProperty.Parameters.Add("@pNewBeginDate", SqlDbType.Date).Value = changedChargeConcept.BeginDate;
            UpdateCCProperty.Parameters.Add("@pNewEndDate", SqlDbType.Date).Value = changedChargeConcept.EndDate;
            
            return ExecuteNonQueryCommand(UpdateCCProperty);
            
        }
        
        public List<CCPropertyDisplayModel> ExecuteGetCCsOnProperty(PropertyDisplayModel property)
        {
            List<CCPropertyDisplayModel> result = new List<CCPropertyDisplayModel>();
            
            try
            {
                connection.Open();
                SqlDataReader reader = GetCCsOnProperty.ExecuteReader();

                while (reader.Read())
                {
                    CCPropertyDisplayModel ccOnProperty = new CCPropertyDisplayModel();
                    
                    ccOnProperty.ChargeConceptName = Convert.ToString(reader["CCName"]);

                    ccOnProperty.ExpirationDays = Convert.ToInt32(reader["ExpirationDays"]);
                    
                    ccOnProperty.MoratoryInterestRate = Convert.ToSingle(reader["MoratoryInterestRate"]);

                    ccOnProperty.ReciptEmisionDay = Convert.ToInt32(reader["ReciptEmisionDay"]);
                    
                    ccOnProperty.BeginDate = Convert.ToString(reader["BeginDate"]);

                    ccOnProperty.EndDate = Convert.ToString(reader["EndDate"]);
                    
                    result.Add(ccOnProperty);
                    
                }
                
                connection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }

            return result;
            
        }
        
        public string ExecuteGetCcChildValue(CCPropertyDisplayModel chargeConcept)
        {
            GetCcChildValue.Parameters.Add("@pName", SqlDbType.VarChar, 50);

            //int CcType = ExecuteNonQueryCommand(GetCcChildValue);
            string result;
            try
            {
                connection.Open();
                SqlDataReader reader = GetCCsOnProperty.ExecuteReader();
                result = Convert.ToString(reader["Amount"]);
                connection.Close();
                return result;
            }
            catch (Exception e)
            {
                throw (e);
            }

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



    }
}