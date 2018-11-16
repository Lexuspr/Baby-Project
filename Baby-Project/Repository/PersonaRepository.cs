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
    public class PersonaRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<Persona> ListarPersonas()
        {
            connection();
            List<Persona> PerList = new List<Persona>();
            SqlCommand com = new SqlCommand("ListarPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            // Llenado de tabla a continuacion
            foreach (DataRow dr in dt.Rows)
            {
                PerList.Add(
                    new Persona
                    {
                        Persona_Id = Convert.ToInt32(dr["persona_ID"]),
                        Persona_Nombre = Convert.ToString(dr["persona_Nom"]),
                        Persona_Apellido = Convert.ToString(dr["persona_Ape"]),
                        Persona_Email = Convert.ToString(dr["persona_Email"]),
                        Persona_FecNac = Convert.ToString(dr["persona_FecNac"]),
                        Persona_Sexo = Convert.ToString(dr["persona_Sex"]),
                        Persona_Celular = Convert.ToString(dr["persona_Cel"]),
                        Persona_Username = Convert.ToString(dr["persona_Usr"]),
                        Persona_Password = Convert.ToString(dr["persona_Pwd"]),
                        Persona_Tipo_ID = Convert.ToInt32(dr["persona_TipoPersona_ID"])
                    }
                );
            }
            return PerList;
        }

        public bool AddPersona(Persona obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@per_nom", obj.Persona_Nombre);
            com.Parameters.AddWithValue("@per_ape", obj.Persona_Apellido);
            com.Parameters.AddWithValue("@per_email", obj.Persona_Email);
            com.Parameters.AddWithValue("@per_fecnac", obj.Persona_FecNac);
            com.Parameters.AddWithValue("@per_sex", obj.Persona_Sexo);
            com.Parameters.AddWithValue("@per_cel", obj.Persona_Celular);
            com.Parameters.AddWithValue("@per_usr", obj.Persona_Username);
            com.Parameters.AddWithValue("@per_pwd", obj.Persona_Password);
            com.Parameters.AddWithValue("@per_tipoPer_ID", obj.Persona_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

        public bool UpdatePersona(Persona obj)
        {
            connection();
            SqlCommand com = new SqlCommand("ModificarPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@per_ID", obj.Persona_Id);
            com.Parameters.AddWithValue("@per_nom", obj.Persona_Nombre);
            com.Parameters.AddWithValue("@per_ape", obj.Persona_Apellido);
            com.Parameters.AddWithValue("@per_email", obj.Persona_Email);
            com.Parameters.AddWithValue("@per_fecnac", obj.Persona_FecNac);
            com.Parameters.AddWithValue("@per_sex", obj.Persona_Sexo);
            com.Parameters.AddWithValue("@per_celular", obj.Persona_Celular);
            com.Parameters.AddWithValue("@per_usr", obj.Persona_Username);
            com.Parameters.AddWithValue("@per_pwd", obj.Persona_Password);
            com.Parameters.AddWithValue("@per_tipoPer_ID", obj.Persona_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        public bool DeletePersona(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@per_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

    }
}