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
    public class AsistenteRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<Asistente> ListarAsistentes()
        {
            connection();
            List<Asistente> AsisList = new List<Asistente>(); 
            SqlCommand com = new SqlCommand("ListarAsistente", con); 
            
            com.CommandType = CommandType.StoredProcedure; 
            SqlDataAdapter da = new SqlDataAdapter(com); 
            DataTable dt = new DataTable(); 
            con.Open(); 
            da.Fill(dt); 
            con.Close(); 
            
            foreach (DataRow dr in dt.Rows)
            {
                AsisList.Add( 
                    new Asistente
                    {
                        Asistente_ID = Convert.ToInt32(dr["asistente_ID"]),
                        Asistente_Nombre = Convert.ToString(dr["asistente_Nombre"])
                    }
                );
            }
            return AsisList;
        }

        public bool AddAsistente(Asistente obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarAsistente", con); 
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@asis_nom", obj.Asistente_Nombre); 
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false; 
            return result; 
        }

        public bool UpdateAsistente(Asistente obj) 
        {
            connection();
            SqlCommand com = new SqlCommand("ModificarAsistente", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@asis_id", obj.Asistente_ID);
            com.Parameters.AddWithValue("@asis_nom", obj.Asistente_Nombre);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        public bool DeleteAsistente(int? id)
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarAsistente", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@asis_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
    }
}