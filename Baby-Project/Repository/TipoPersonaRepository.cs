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
    public class TipoPersonaRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<TipoPersona> ListarTipoPersonas()
        {
            connection();
            List<TipoPersona> TipoPerList = new List<TipoPersona>();
            SqlCommand com = new SqlCommand("ListarTipoPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                TipoPerList.Add(
                    new TipoPersona
                    {
                        TipoPersona_Id = Convert.ToInt32(dr["tipoPersona_ID"]),
                        TipoPersona_Desc = Convert.ToString(dr["tipoPersona_desc"])
                    }
                );
            }
            return TipoPerList;
        }

        public bool AddTipoPersona(TipoPersona obj)
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarTipoPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TP_Desc", obj.TipoPersona_Desc);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

        public bool UpdateTipoPersona(TipoPersona obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateTipoPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TP_ID", obj.TipoPersona_Id);
            com.Parameters.AddWithValue("@TP_Desc", obj.TipoPersona_Desc);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }

        public bool DeleteTipoPersona(int? id)
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarTipoPersona", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TP_ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
    }
}