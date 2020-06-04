using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using University_DB1_FirstProject.Interfaces;
using University_DB1_FirstProject.Models;


namespace University_DB1_FirstProject.Controllers
{
    public class OwnerController
    {
        public string connectionString;
        private SqlConnection connection;
        private SqlCommand InsertOwner;
         
        public OwnerController()
        {
            connectionString = IConnectionStrings.CONNECTIONSTRING;
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            InsertOwner = new SqlCommand("SP_insertOwner", connection);
            InsertOwner.CommandType = CommandType.StoredProcedure;
        }

        public void executeInsertOwner(OwnerModel ownerInstance)
        {
            InsertOwner.Parameters.Add("@pName", SqlDbType.VarChar, 50).Value = ownerInstance.Name;
            InsertOwner.Parameters.Add("@pDocValue", SqlDbType.Int).Value = ownerInstance.DocValue;
            InsertOwner.Parameters.Add("@pDocType_Id", SqlDbType.Int).Value = ownerInstance.DocTypeId;

            try
            {
                connection.Open();
                InsertOwner.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
             
             
        }
         
         
    }
}