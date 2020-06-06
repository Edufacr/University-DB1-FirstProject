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
        private SqlCommand GetFixedCCAmount;
        private SqlCommand GetConsumptionCC;
        private SqlCommand GetPercentageCC;
        
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
            
            GetFixedCCAmount = new SqlCommand("SP_getFixedCCAmount", connection);
            GetFixedCCAmount.CommandType = CommandType.StoredProcedure;
            
            GetConsumptionCC = new SqlCommand("SP_getConsumptionM3", connection);
            GetConsumptionCC.CommandType = CommandType.StoredProcedure;
            
            GetPercentageCC = new SqlCommand("SP_getPercentageCCPercent", connection);
            GetPercentageCC.CommandType = CommandType.StoredProcedure;
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
        
        public List<FixedCCDisplayModel> ExecuteGetFixedCCAmount(CCPropertyDisplayModel chargeConcept)
        {
            List<FixedCCDisplayModel> result = new List<FixedCCDisplayModel>();
            
            try
            {
                connection.Open();
                SqlDataReader reader = GetCCsOnProperty.ExecuteReader();

                while (reader.Read())
                {
                    FixedCCDisplayModel ccOnProperty = new FixedCCDisplayModel();
                    
                    
                    
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
        
        public List<CCPropertyDisplayModel> ExecuteGetConsumptionCC(CCPropertyDisplayModel chargeConcept)
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
        
        public List<CCPropertyDisplayModel> ExecuteGetPercentageCC(CCPropertyDisplayModel chargeConcept)
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