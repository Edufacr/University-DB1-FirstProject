namespace University_DB1_FirstProject.Interfaces
{
    public interface IConnectionStrings
    {
        public static readonly string JORGECONNECTIONSTR = @"Data Source = LAPTOP-5URQT67L\SQLEXPRESS;Initial Catalog=DB1-FirstProject;Integrated Security=True";
        public static readonly string EDUARDOCONNECTIONSTR = "Data Source=DESKTOP-FM67O2I;Initial Catalog=DB1-FirstProject;Integrated Security=True";
        
                                                //Connection string to use
        public static readonly string CONNECTIONSTRING = EDUARDOCONNECTIONSTR;
    }

}