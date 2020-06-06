using System.Data;
using System.Data.SqlClient;

namespace University_DB1_FirstProject.Controllers
{
    public class UserController
    {
        private SqlConnection connection;
        
        private SqlCommand InsertUser;
        private SqlCommand DeleteUser;
        private SqlCommand UpdateUser;
        
        private SqlCommand DeleteUserOfProperty;
        private SqlCommand InsertUserOfProperty; //TODO

        
        private SqlCommand GetUsersOfProperty;
        private SqlCommand GetActiveUsers;
        private SqlCommand GetUsersByUsername;


        public UserController(SqlConnection pConnection)
        {
            connection = pConnection;
            
            InsertUser = new SqlCommand("SP_insertUser", connection);
            InsertUser.CommandType = CommandType.StoredProcedure;
            
            DeleteUser = new SqlCommand("SP_deleteUser", connection);
            DeleteUser.CommandType = CommandType.StoredProcedure;
            
            UpdateUser = new SqlCommand("SP_updateUser", connection);
            UpdateUser.CommandType = CommandType.StoredProcedure;
            
            DeleteUserOfProperty = new SqlCommand("SP_deletePropertyUser", connection);
            DeleteUserOfProperty.CommandType = CommandType.StoredProcedure;
            
            InsertUserOfProperty = new SqlCommand("SP_deletePropertyUser", connection);
            InsertUserOfProperty.CommandType = CommandType.StoredProcedure;

            
            GetUsersOfProperty = new SqlCommand("SP_getUserOfProperty", connection);
            GetUsersOfProperty.CommandType = CommandType.StoredProcedure;
            
            GetActiveUsers = new SqlCommand("SP_getActiveUsers", connection);
            GetActiveUsers.CommandType = CommandType.StoredProcedure;
            
            GetUsersByUsername = new SqlCommand("SP_getUserInfoByName", connection);
            GetUsersByUsername.CommandType = CommandType.StoredProcedure;

        }
        

    }
}