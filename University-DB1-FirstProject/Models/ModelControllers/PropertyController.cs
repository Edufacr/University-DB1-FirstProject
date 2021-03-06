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
        
        private SqlCommand GetPropertiesOfOwner;
        private SqlCommand GetPropertiesOfUser;
        private SqlCommand GetPropertyInfoByName;
        private SqlCommand GetPropertyInfoByPropertyNumber;
        
        public static PropertyController Singleton;


        private PropertyController()
        {

            connection = DBConnection.getInstance().Connection;
            
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
            
            GetPropertyInfoByName = new SqlCommand("SP_getPropertyInfoByName", connection);
            GetPropertyInfoByName.CommandType = CommandType.StoredProcedure;
            
            GetPropertyInfoByPropertyNumber = new SqlCommand("SP_getPropertyInfoByPropertyNumber", connection);
            GetPropertyInfoByPropertyNumber.CommandType = CommandType.StoredProcedure;
            
            GetActiveProperties = new SqlCommand("SP_getActiveProperties", connection);
            GetActiveProperties.CommandType = CommandType.StoredProcedure;
        }
        
        public static PropertyController getInstance()
        {
            return Singleton ??= new PropertyController();
        }


        public int ExecuteInsertProperty(PropertyRegisterModel property)
        {
            InsertProperty.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value =  "Unnamed";
            InsertProperty.Parameters.Add("@pValue", SqlDbType.Money).Value = property.Value;
            InsertProperty.Parameters.Add("@pAddress", SqlDbType.VarChar, 100).Value = property.Address;
            InsertProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;

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
            GetPropertiesOfOwner.Parameters.Add("@pDocValue", SqlDbType.Int).Value = owner.DocValue;
            GetPropertiesOfOwner.Parameters.Add("@pDocType", SqlDbType.Int).Value = owner.DocType;

            return ExecuteQueryCommand(GetPropertiesOfOwner);
        }
        
        public List<PropertyDisplayModel> ExecuteGetPropertiesOfUser(UserDisplayModel user)
        {
            GetPropertiesOfUser.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = user.Name;

            return ExecuteQueryCommand(GetPropertiesOfUser);
            
        }
        
        public List<PropertyDisplayModel> ExecuteGetPropertyInfoByName(PropertyDisplayModel property)
        {
            GetPropertyInfoByName.Parameters.Add("@pName", SqlDbType.VarChar).Value = property.Name;

            return ExecuteQueryCommand(GetPropertyInfoByName);

        }
        
        public List<PropertyDisplayModel> ExecuteGetPropertyInfoByPropertyNumber(PropertyDisplayModel property)
        {
            GetPropertyInfoByPropertyNumber.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value 
                = property.PropertyNumber;

            return ExecuteQueryCommand(GetPropertyInfoByPropertyNumber);
        }
        
        public List<PropertyDisplayModel> ExecuteGetActiveProperties()
        {
            return ExecuteQueryCommand(GetActiveProperties);
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
                command.Parameters.Clear();

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
                    
                    property.Address = Convert.ToString(reader["Address"]);
                    property.Value = Convert.ToSingle(reader["Value"]);
                    property.PropertyNumber = Convert.ToInt32(reader["PropertyNumber"]);
                    
                    result.Add(property);
                    
                }               
                command.Parameters.Clear();
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