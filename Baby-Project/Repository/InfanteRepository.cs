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
    public class InfanteRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<Infante> ListarInfantes()
        {
            connection();
            List<Infante> InfantList = new List<Infante>();
            SqlCommand com = new SqlCommand("ListarInfante", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                InfantList.Add(
                    new Infante
                    {
                        Infante_Historial = Convert.ToString(dr["infante_NHC"]),
                        Infante_Nombre = Convert.ToString(dr["infante_Nom"]),
                        Infante_Apellido = Convert.ToString(dr["infante_Ape"]),
                        Infante_FecNac = Convert.ToDateTime(dr["infante_FecNac"]),
                        Infante_Sexo = Convert.ToString(dr["infante_Sexo"]),
                        Infante_Lugar = Convert.ToString(dr["infante_Lugar"]),
                        Infante_Exa_Gen = Convert.ToInt32(dr["infante_ExamenGen_ID"]),
                        Infante_Exa_Fis = Convert.ToInt32(dr["infante_ExamenFis_ID"])
                    }
                );
            }
            return InfantList;
        }

        public bool AddInfante(Infante obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarInfante", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@inf_nhc", obj.Infante_Historial);
            com.Parameters.AddWithValue("@inf_nom", obj.Infante_Nombre);
            com.Parameters.AddWithValue("@inf_ape", obj.Infante_Apellido);
            com.Parameters.AddWithValue("@inf_fecnac", obj.Infante_FecNac);
            com.Parameters.AddWithValue("@inf_sex", obj.Infante_Sexo);
            com.Parameters.AddWithValue("@inf_lugar", obj.Infante_Lugar);
            com.Parameters.AddWithValue("@inf_exgen_id", obj.Infante_Exa_Gen);
            com.Parameters.AddWithValue("@inf_exfis_id", obj.Infante_Exa_Fis);
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
            com.Parameters.AddWithValue("@inf_id", obj.Infante_ID);
            com.Parameters.AddWithValue("@inf_nhc", obj.Infante_Historial);
            com.Parameters.AddWithValue("@inf_nom", obj.Infante_Nombre);
            com.Parameters.AddWithValue("@inf_ape", obj.Infante_Apellido);
            com.Parameters.AddWithValue("@inf_fecnac", obj.Infante_FecNac);
            com.Parameters.AddWithValue("@inf_sex", obj.Infante_Sexo);
            com.Parameters.AddWithValue("@inf_lugar", obj.Infante_Lugar);
            com.Parameters.AddWithValue("@inf_exgen_id", obj.Infante_Exa_Gen);
            com.Parameters.AddWithValue("@inf_exfis_id", obj.Infante_Exa_Fis);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        public bool DeleteInfante(int? id)
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarInfante", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@inf_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
    }
}