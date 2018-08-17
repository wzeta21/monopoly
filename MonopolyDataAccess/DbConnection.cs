using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyDataAccess
{
    public class DbConnection
    {
        private SqlConnection connection;
        public DbConnection()
        {
            this.connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["MiConexion"].ToString()
            );
        }

        public SqlConnection Conexion
        {
            get
            {
                return this.connection;
            }
        }

       

        public DataTable ExcecuteSp(string sp, List<Parameter> lstparam)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd;
            try
            {
                this.connection.Open();
                cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstparam != null)
                {
                    foreach (Parameter par in lstparam)
                    {
                        cmd.Parameters.AddWithValue(par.Name, par.Value);
                    }
                }
                //cmd.ExecuteNonQuery();
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            this.connection.Close();
            return tabla;
        }
    }
}
