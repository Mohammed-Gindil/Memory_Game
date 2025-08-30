using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Memory_Game
{
    public class ClassDataAccess
    {

        public static string Connction = "server=.;Database=Memory_GameDB;User Id=sa;Password=sa123456";

        public static DataTable GetAllImageRandom()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(Connction);

            string query = "Select * from Image_Game order by newid();";

            SqlCommand commend = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reder = commend.ExecuteReader();

                if (reder.HasRows)
                {
                    dt.Load(reder);
                }

                reder.Close();
            }
            catch (Exception ex)
            {
                //error
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

    }


}
