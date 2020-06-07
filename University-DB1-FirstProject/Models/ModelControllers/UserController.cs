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


        public static UserController Singleton;


        private UserController()
        {
            connection = DBConnection.getInstance().Connection;
            
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

        public static UserController getInstance()
        {
            return Singleton ??= new UserController();
        }
            


        public int ExecuteInsertUser(UserRegisterModel user)
        {

            InsertUser.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = user.Name;
            InsertUser.Parameters.Add("@pPassword", SqlDbType.VarChar, 50).Value = user.Password;
            InsertUser.Parameters.Add("@pAdminType", SqlDbType.Bit).Value = user.UserType;
            
            return ExecuteNonQueryCommand(InsertUser);
            
        }
        

            return ExecuteNonQueryCommand(DeleteUser);
            
        }
        
        public int ExecuteUpdateUser(UserDisplayModel originalUser, UserRegisterModel newUser)
        {

            UpdateUser.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = originalUser.Name;
            UpdateUser.Parameters.Add("@pNewUserName", SqlDbType.VarChar, 50).Value = newUser.Name;
            UpdateUser.Parameters.Add("@pNewPassword", SqlDbType.VarChar, 50).Value = newUser.Password;
            UpdateUser.Parameters.Add("@pNewUserType", SqlDbType.Bit).Value = newUser.UserType;
            
            return ExecuteNonQueryCommand(UpdateUser);
            
        }
        
        public int ExecuteDeleteUserOfProperty(UserDisplayModel user, PropertyDisplayModel property)
        {
            
            DeleteUserOfProperty.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = user.Name;
            DeleteUserOfProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            
            return ExecuteNonQueryCommand(DeleteUserOfProperty);
            
        }
        
        public int ExecuteInsertUserOfProperty(UserDisplayModel user, PropertyDisplayModel property)
        {
            
            InsertUserOfProperty.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = user.Name;
            InsertUserOfProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            
            return ExecuteNonQueryCommand(InsertUserOfProperty);
            
        }
        
        public List<UserDisplayModel> ExecuteGetUsersOfProperty(PropertyDisplayModel property)
        {
            
            GetUsersOfProperty.Parameters.Add("@pPropertyNumber", SqlDbType.Int).Value = property.PropertyNumber;
            
            return ExecuteQueryCommand(GetUsersOfProperty);
            
        }
        
        public List<UserDisplayModel> ExecuteGetActiveUsers()
        {
            return ExecuteQueryCommand(GetActiveUsers);
        }
        
        public bool ExecuteValidatePassword(string username, string passwordEntry)
        {
            
            Console.WriteLine(username);
            Console.WriteLine(passwordEntry);
            
            ValidatePassword.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username;
            ValidatePassword.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = passwordEntry;

            int result = ExecuteNonQueryCommand(ValidatePassword);
            if (result == -5000)
            {
                return false; //incorrect password
            }

            return true; //correct password 

        }

        public string ExecuteGetPassword(UserDisplayModel user)
        {
            
            string password;
            
            GetPassword.Parameters.Add("@pUsername", SqlDbType.VarChar, 50).Value = user.Name;
            
            try
            {
                
                connection.Open();
                SqlDataReader reader = GetPassword.ExecuteReader();
                reader.Read();
                password = Convert.ToString(reader["Password"]);   
                connection.Close();
                
            }
            catch (Exception e)
            {
                throw (e);
            }
            
            return password;

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
        
        public List<UserDisplayModel> ExecuteQueryCommand(SqlCommand command)
        {

            List<UserDisplayModel> result = new List<UserDisplayModel>();
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserDisplayModel user = new UserDisplayModel();
                    
                    user.Name = Convert.ToString(reader["Username"]);

                    user.isAdmin = Convert.ToBoolean(reader["UserType"]);
                    
                    result.Add(user);
                    
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