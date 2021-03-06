﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class OwnerController
    {
        private SqlConnection connection;
        
        private SqlCommand InsertOwner;
        private SqlCommand DeleteOwner;
        private SqlCommand UpdateOwner;

        private SqlCommand InsertOwnerOfProperty; //TODO
        private SqlCommand DeleteOwnerOfProperty;

        private SqlCommand GetOwnersOfProperty;
        private SqlCommand GetActiveOwners;
        private SqlCommand GetOwnersByName;
        private SqlCommand GetOwnersByDocValue;
        
        public static OwnerController Singleton;

                
        private OwnerController()
        {
            connection = DBConnection.getInstance().Connection;
            
            InsertOwner = new SqlCommand("SP_insertOwner", connection);
            InsertOwner.CommandType = CommandType.StoredProcedure;
            
            DeleteOwner = new SqlCommand("SP_deleteOwner", connection);
            DeleteOwner.CommandType = CommandType.StoredProcedure;
            
            UpdateOwner = new SqlCommand("SP_updateOwner", connection);
            UpdateOwner.CommandType = CommandType.StoredProcedure;
            
            DeleteOwnerOfProperty = new SqlCommand("SP_deletePropertyOwner", connection);
            DeleteOwnerOfProperty.CommandType = CommandType.StoredProcedure;
            
            InsertOwnerOfProperty = new SqlCommand("SP_insertPropertyOwner", connection);
            InsertOwnerOfProperty.CommandType = CommandType.StoredProcedure;
            
            GetOwnersOfProperty = new SqlCommand("SP_getOwnersOfProperty", connection);
            GetOwnersOfProperty.CommandType = CommandType.StoredProcedure;
            
            GetActiveOwners = new SqlCommand("SP_getActiveOwners", connection);
            GetActiveOwners.CommandType = CommandType.StoredProcedure;
            
            GetOwnersByName = new SqlCommand("SP_getOwnerInfoByName", connection);
            GetOwnersByName.CommandType = CommandType.StoredProcedure;
            
            GetOwnersByDocValue = new SqlCommand("SP_getOwnerInfoByDocValue", connection);
            GetOwnersByDocValue.CommandType = CommandType.StoredProcedure;
        }
        
        public static OwnerController getInstance()
        {
            
            return Singleton ??= new OwnerController();

        }

        public int ExecuteInsertOwner(OwnerRegisterModel ownerInstance)
        {
            InsertOwner.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value = ownerInstance.Name;
            InsertOwner.Parameters.Add("@pDocValue", SqlDbType.VarChar, 30).Value = ownerInstance.DocValue;
            InsertOwner.Parameters.Add("@pDocType_Id", SqlDbType.Int).Value = ownerInstance.DocTypeId;

            return ExecuteNonQueryCommand(InsertOwner);
            
        }

        public int ExecuteDeleteOwner(OwnerDisplayModel ownerInstance)
        {
            DeleteOwner.Parameters.Add("@pDocValue", SqlDbType.VarChar, 30).Value = ownerInstance.DocValue;
            DeleteOwner.Parameters.Add("@pDocType", SqlDbType.VarChar, 50).Value = ownerInstance.DocType;

            return ExecuteNonQueryCommand(DeleteOwner);
            
        }

        public int ExecuteUpdateOwner(OwnerDisplayModel originalOwner, OwnerRegisterModel newOwner)
        {
            UpdateOwner.Parameters.Add("@pDocValue", SqlDbType.VarChar, 30).Value = originalOwner.DocValue;
            UpdateOwner.Parameters.Add("@pDocType", SqlDbType.VarChar, 50).Value = originalOwner.DocType;
            
            UpdateOwner.Parameters.Add("@pNewName", SqlDbType.VarChar, 50).Value = newOwner.Name;
            UpdateOwner.Parameters.Add("@pNewDocValue", SqlDbType.VarChar, 30).Value = newOwner.DocValue;
            UpdateOwner.Parameters.Add("@pNewDocType_Id", SqlDbType.VarChar, 50).Value = newOwner.DocTypeId;
            
            return ExecuteNonQueryCommand(UpdateOwner);
            
        }
        
        public int ExecuteDeleteOwnerOfProperty(PropertyDisplayModel property, OwnerDisplayModel owner)
        {
            DeleteOwnerOfProperty.Parameters.Add("@pPropertyPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            DeleteOwnerOfProperty.Parameters.Add("@pOwnerDocValue", SqlDbType.VarChar, 30).Value = owner.DocValue;
            DeleteOwnerOfProperty.Parameters.Add("@pOwnerDocType", SqlDbType.VarChar, 50).Value = owner.DocType;
            return ExecuteNonQueryCommand(DeleteOwnerOfProperty);
        }
        
        public int ExecuteInsertOwnerOfProperty(PropertyDisplayModel property, OwnerDisplayModel owner)
        {
            InsertOwnerOfProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            InsertOwnerOfProperty.Parameters.Add("@pOwnerDocValue", SqlDbType.VarChar, 30).Value = owner.DocValue;
            InsertOwnerOfProperty.Parameters.Add("@pOwnerDocType", SqlDbType.VarChar, 50).Value = owner.DocType;
            
            Console.WriteLine(property.PropertyNumber);
            Console.WriteLine(owner.DocValue);
            Console.WriteLine(owner.DocType);
            
            return ExecuteNonQueryCommand(InsertOwnerOfProperty);
        }

        

        public List<OwnerDisplayModel> ExecuteGetOwnersOfProperty(PropertyDisplayModel property)
        {
            GetOwnersOfProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            
            List<OwnerDisplayModel> result = ExecuteQueryCommand(GetOwnersOfProperty);
            return result;
        }

        public List<OwnerDisplayModel> ExcecuteGetActiveOwners()
        {
            List<OwnerDisplayModel> result = ExecuteQueryCommand(GetActiveOwners);
            return result;        
        }
        
        public List<OwnerDisplayModel> ExcecuteGetOwnersByName(OwnerDisplayModel originalOwner)
        {
            GetOwnersByName.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value = originalOwner.Name;

            List<OwnerDisplayModel> result = ExecuteQueryCommand(GetOwnersByName);
            return result;
        }
        
        
        public List<OwnerDisplayModel> ExcecuteGetOwnersByDocValue(OwnerDisplayModel owner)
        {
            GetOwnersByDocValue.Parameters.Add("@pDocValue",SqlDbType.VarChar, 30).Value = owner.DocValue;
            GetOwnersByDocValue.Parameters.Add("@pDocType", SqlDbType.VarChar, 50).Value = owner.DocType;
            
            List<OwnerDisplayModel> result = ExecuteQueryCommand(GetOwnersByDocValue);
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
                command.Parameters.Clear();

                return result;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }
        
        public List<OwnerDisplayModel> ExecuteQueryCommand(SqlCommand command)
        {

            List<OwnerDisplayModel> result = new List<OwnerDisplayModel>();
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OwnerDisplayModel owner = new OwnerDisplayModel();
                    
                    owner.Name = Convert.ToString(reader["Name"]);
                    owner.DocValue = Convert.ToString(reader["DocValue"]);
                    owner.DocType = Convert.ToString(reader["Doctype"]);
                    
                    result.Add(owner);
                    
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