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
    public class MadreRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<Madre> ListarMadres()
        {
            connection();
            List<Madre> MadList = new List<Madre>();
            SqlCommand com = new SqlCommand("ListarMadre", con);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                MadList.Add(
                    new Madre
                    {
                        Madre_Id = Convert.ToInt32(dr["madre_ID"]),
                        Madre_Nombre = Convert.ToString(dr["madre_Nom"]),
                        Madre_Apellido = Convert.ToString(dr["madre_Ape"]),
                        Madre_FecNac = Convert.ToDateTime(dr["madre_FecNac"]),
                        Madre_Sangre = Convert.ToString(dr["madre_Sangre"]),
                        Madre_Factor = Convert.ToString(dr["madre_Factor"]),
                        Madre_Enfermedad = Convert.ToString(dr["madre_Enf"]),
                        Madre_Tipo_ID = Convert.ToInt32(dr["madre_Examen_ID"])
                    }
                );
            }
            return MadList;
        }

        public bool AddMadre(Madre obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarMadre", con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@mad_nom", obj.Madre_Nombre);
            com.Parameters.AddWithValue("@mad_ape", obj.Madre_Apellido);
            com.Parameters.AddWithValue("@mad_fecnac", obj.Madre_FecNac);
            com.Parameters.AddWithValue("@mad_sangre", obj.Madre_Sangre);
            com.Parameters.AddWithValue("@mad_factor", obj.Madre_Factor);
            com.Parameters.AddWithValue("@mad_enf", obj.Madre_Enfermedad);
            com.Parameters.AddWithValue("@mad_examen_id", obj.Madre_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

        public bool UpdateMadre(Madre obj)
        {
            connection();
            SqlCommand com = new SqlCommand("ModificarMadre", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mad_id", obj.Madre_Id);
            com.Parameters.AddWithValue("@mad_nom", obj.Madre_Nombre);
            com.Parameters.AddWithValue("@mad_ape", obj.Madre_Apellido);
            com.Parameters.AddWithValue("@mad_fecnac", obj.Madre_FecNac);
            com.Parameters.AddWithValue("@mad_sangre", obj.Madre_Sangre);
            com.Parameters.AddWithValue("@mad_factor", obj.Madre_Factor);
            com.Parameters.AddWithValue("@mad_enf", obj.Madre_Enfermedad);
            com.Parameters.AddWithValue("@mad_examen_id", obj.Madre_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        public bool DeleteMadre(int? id)
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarMadre", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@mad_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
    }
}