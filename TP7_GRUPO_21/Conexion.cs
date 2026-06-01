using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_21
{
    public class Conexion
    {
        private const string cadenaConexion = "Data Source=localhost\\sqlexpress; Initial Catalog=BDSucursales; Integrated Security=True";

        public DataTable ObtenerTabla(string consultaSQL)
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaSQL, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();
            return dataTable;
        }
    }
}