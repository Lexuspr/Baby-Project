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

        public List<Persona> GetAllPersonas()
        {
            connection();
            List<Persona> PerList = new List<Persona>();
            SqlCommand com = new SqlCommand("GetPersonas", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            // Llenado de tabla a continuacion

            return PerList;
        }

        public bool AddPersona(Persona obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@P_Nombre", obj.Persona_Nombre);
            com.Parameters.AddWithValue("@P_Apellido", obj.Persona_Apellido);
            com.Parameters.AddWithValue("@P_Email", obj.Persona_Email);
            com.Parameters.AddWithValue("@P_FecNac", obj.Persona_FecNac);
            com.Parameters.AddWithValue("@P_Sexo", obj.Persona_Sexo);
            com.Parameters.AddWithValue("@P_Celular", obj.Persona_Celular);
            com.Parameters.AddWithValue("@P_Username", obj.Persona_Username);
            com.Parameters.AddWithValue("@P_Password", obj.Persona_Password);
            com.Parameters.AddWithValue("@P_Tipo_ID", obj.Persona_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

        public bool UpdatePersona(Persona obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdatePersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@P_ID", obj.Persona_Id);
            com.Parameters.AddWithValue("@P_Nombre", obj.Persona_Nombre);
            com.Parameters.AddWithValue("@P_Apellido", obj.Persona_Apellido);
            com.Parameters.AddWithValue("@P_Email", obj.Persona_Email);
            com.Parameters.AddWithValue("@P_FecNac", obj.Persona_FecNac);
            com.Parameters.AddWithValue("@P_Sexo", obj.Persona_Sexo);
            com.Parameters.AddWithValue("@P_Celular", obj.Persona_Celular);
            com.Parameters.AddWithValue("@P_Username", obj.Persona_Username);
            com.Parameters.AddWithValue("@P_Password", obj.Persona_Password);
            com.Parameters.AddWithValue("@P_Tipo_ID", obj.Persona_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        public bool DeletePersona(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeletePersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@P_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

    }
}