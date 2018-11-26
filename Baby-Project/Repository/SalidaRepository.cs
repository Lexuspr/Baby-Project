using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Baby_Project.Models;
using System.Data;

namespace Baby_Project.Repository
{
    public class SalidaRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<Salida> ListarSalidas()
        {
            connection();
            List<Salida> ExitList = new List<Salida>();
            SqlCommand com = new SqlCommand("ListarSalida", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ExitList.Add(
                    new Salida
                    {
                        Salida_ID = Convert.ToInt32(dr["salida_ID"]),
                        Salida_Obs = Convert.ToString(dr["salida_Obs"]),
                        Salida_Destino = Convert.ToString(dr["salida_Destino"]),
                        Salida_NumCnv = Convert.ToString(dr["salida_NumCnv"]),
                        Salida_Fec = Convert.ToDateTime(dr["salida_Fec"]),
                        Asistente_ID = Convert.ToInt32(dr["Asistente_ID"]),
                    }
                );
            }
            return ExitList;
        }

        public bool AddSalida(Salida obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarSalida", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@sld_obs", obj.Salida_Obs);
            com.Parameters.AddWithValue("@sld_dest", obj.Salida_Destino);
            com.Parameters.AddWithValue("@sld_numcnv", obj.Salida_NumCnv);
            com.Parameters.AddWithValue("@sld_fec", obj.Salida_Fec);
            com.Parameters.AddWithValue("@sld_asis_id", obj.Asistente_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

        public bool UpdateInfante(Infante obj)
        {
            connection();
            SqlCommand com = new SqlCommand("ModificarInfante", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sld_id", obj.Salida_ID);
            com.Parameters.AddWithValue("@sld_obs", obj.Salida_Obs);
            com.Parameters.AddWithValue("@sld_dest", obj.Salida_Destino);
            com.Parameters.AddWithValue("@sld_numcnv", obj.Salida_NumCnv);
            com.Parameters.AddWithValue("@sld_fec", obj.Salida_Fec);
            com.Parameters.AddWithValue("@sld_asis_id", obj.Asistente_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        public bool DeleteSalida(int? id)
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarSalida", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sal_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
    }
}