using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;


namespace CustomersApp.Models
{
    public class db
    {
        //private static readonly string _conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //private readonly IDbConnection _db;
        //public db()
        //{
        //    _db = new SqlConnection(_conn);
        //}

        //SqlConnection con = new SqlConnection("Data Source=ADMINRG-N8EO0RN\\SQLEXPRESS;Initial Catalog=demo1;Integrated Security=True");
        SqlConnection _db = new SqlConnection("Server=localhost;Database=Demo1;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        public int LoginCheck(Login ad)
        {
            SqlCommand com = new SqlCommand("Sp_Login", (SqlConnection)_db);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", ad.Name);
            com.Parameters.AddWithValue("@Password", ad.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            _db.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            _db.Close();
            return res;
        }

    }
}

