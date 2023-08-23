namespace StudentsRecordManagementSystem.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=DESKTOP-46NDRT1\\SQLEXPRESS02;Initial Catalog=StudentManagement;Integrated Security=True";
        public static string CName
        {
           get => cName;
        }
        
    }
}
