using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class PropertyController
    {
        private SqlConnection connection;

        private SqlCommand InsertProperty;
        private SqlCommand DeleteProperty;
        private SqlCommand UpdateProperty;

        private SqlCommand GetActiveProperties;
        private SqlCommand GetPropertiesOfOwner;
        private SqlCommand GetPropertiesOfUser;
        private SqlCommand GetPropertyInfoByPropertyNumber;

        public PropertyController(SqlConnection pConnection)
        {

            connection = pConnection;
            
            InsertProperty = new SqlCommand("SP_insertProperty", connection);
            InsertProperty.CommandType = CommandType.StoredProcedure;
            
            DeleteProperty = new SqlCommand("SP_deleteProperty", connection);
            DeleteProperty.CommandType = CommandType.StoredProcedure;
            
            UpdateProperty = new SqlCommand("SP_updateProperty", connection);
            UpdateProperty.CommandType = CommandType.StoredProcedure;
            
            GetPropertiesOfOwner = new SqlCommand("SP_getPropertiesOfOwner", connection);
            GetPropertiesOfOwner.CommandType = CommandType.StoredProcedure;
            
            GetPropertiesOfUser = new SqlCommand("SP_getUsersProperties", connection);
            GetPropertiesOfUser.CommandType = CommandType.StoredProcedure;

            GetPropertyInfoByPropertyNumber = new SqlCommand("SP_getPropertyInfoByPropertyNumber", connection);
            GetPropertyInfoByPropertyNumber.CommandType = CommandType.StoredProcedure;
        }


        public int ExecuteInsertProperty(PropertyRegisterModel property)
        {
            InsertProperty.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value =  "Unnamed";
            InsertProperty.Parameters.Add("@pValue", SqlDbType.Money).Value = property.Value;
            InsertProperty.Parameters.Add("@pAddress", SqlDbType.VarChar, 100).Value = property.Address;
            InsertProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.Value;

            return ExecuteNonQueryCommand(InsertProperty);

        }
        
        public int ExecuteDeleteProperty(PropertyDisplayModel property)
        {
            DeleteProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;

            return ExecuteNonQueryCommand(DeleteProperty);
        }
        
        public int ExecuteUpdateProperty(PropertyDisplayModel originalProperty, PropertyRegisterModel propertyChanges)
        {
            UpdateProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = originalProperty.PropertyNumber;
            UpdateProperty.Parameters.Add("@pNewName", SqlDbType.VarChar, 50).Value = "Unnamed";
            UpdateProperty.Parameters.Add("@pNewValue", SqlDbType.Money).Value = propertyChanges.Value;
            UpdateProperty.Parameters.Add("@pNewAddress", SqlDbType.VarChar, 100).Value = propertyChanges.Address;
            UpdateProperty.Parameters.Add("@pNewPropertyNumber", SqlDbType.Int).Value = propertyChanges.PropertyNumber;

            return ExecuteNonQueryCommand(UpdateProperty);

        }
        
        public List<PropertyDisplayModel> ExecuteGetPropertiesOfOwner(OwnerDisplayModel owner)
        {
            GetPropertiesOfOwner.Parameters.Add("@pDocValue", SqlDbType.VarChar, 30).Value = owner.DocValue;
            GetPropertiesOfOwner.Parameters.Add("@pDocType", SqlDbType.VarChar, 50).Value = owner.DocType;

            return ExecuteQueryCommand(GetPropertiesOfOwner);
        }
        
        public List<PropertyDisplayModel> ExecuteGetPropertiesOfUser(UserDisplayModel user)
        {
            GetPropertiesOfUser.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = user.Name;

            return ExecuteQueryCommand(GetPropertiesOfUser);
            
        }

        public List<PropertyDisplayModel> ExecuteGetPropertyInfoByPropertyNumber(PropertyDisplayModel property)
        {
            GetPropertyInfoByPropertyNumber.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value 
                = property.PropertyNumber;

            return ExecuteQueryCommand(GetPropertyInfoByPropertyNumber);
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
        
        public List<PropertyDisplayModel> ExecuteQueryCommand(SqlCommand command)
        {

            List<PropertyDisplayModel> result = new List<PropertyDisplayModel>();
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PropertyDisplayModel property = new PropertyDisplayModel();
                    
                    property.Address = Convert.ToString(reader["PropertyAddress"]);
                    property.Value = Convert.ToSingle(reader["PropertyValue"]);
                    property.PropertyNumber = Convert.ToInt32(reader["PropertyNumber"]);
                    
                    result.Add(property);
                    
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