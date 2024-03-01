using Microsoft.Data.SqlClient;
using System.Data.Common;


namespace Productos.DataAccess
{
    public class DataAccess
    {
    //Server=localhost\\SQLEXPRESS; DataBase=Store; User=TestUser;
        string cadenaConexion= "Server=SAELTHAS-DESK\\SQLEXPRESS;Database=Store;User=TestUser;Pwd=TestUser";
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "localhost",
            InitialCatalog = "Store",
            ApplicationName = "ApplicationName",
            UserID = "TestUser",
            Password = "TestUser",
            ConnectTimeout = 60,
            TrustServerCertificate=true
            
        };
        public DataAccess()
        {
                
        }
        // SELECT [id],[Code],[Name],[Description],[Stock],[Price],[CreatedDate],[UpdateDate]FROM [Store].[dbo].[Products]
        public string ejecutarConsulta(string querySQL)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(builder.ConnectionString);

                SqlCommand cmd = new SqlCommand(querySQL, conexion);
                if(conexion.State!= System.Data.ConnectionState.Open)
                    conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " - " + reader[2]);
                }
                reader.Close();
                conexion.Close();

                return "";
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
