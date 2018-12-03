using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration; //Importar esto
using Baby_Project.Models; // Importar esto tambien
using System.Data; // SIp
using System.Security.Cryptography;

namespace Baby_Project.Repository
{
    public class PersonaRepository // OK. El segundo paso es crear el repositorio por cada tabla o modelo. Aqui van los metodos para listar/get, crear, actualizar y eliminar
    {
        private SqlConnection con; // Inicializando la variable de conexion

        private void connection() //Este metodo va en todos los repositorios sin cambios ;)
        {
            string constr = ConfigurationManager
                        .ConnectionStrings["getconn"]
                        .ToString();
            con = new SqlConnection(constr);
        }

        public List<Persona> ListarPersonas() //Metodo para Listar personas. 1er Metodo a crear
        {
            connection(); //Aqui llamamos al método de arriba connection() para que preprare nuestra conexion a la bd
            List<Persona> PerList = new List<Persona>(); // Creamos una lista del tipo de modelo en el que estamos. En este caso Persona. Esta lista almacena varios objetos de tipo Persona
            SqlCommand com = new SqlCommand("ListarPersona", con); // Aqui creamos una variable para poder acceder al procedimiento almacenado respectivo. En este caso ListarPersona. El nombre tiene que ser identico al que esta en la bd
            //Desde aca es un ctrl c y ctrl v ...
            com.CommandType = CommandType.StoredProcedure; // Esto es para indicar que la variable de arriba es de tipo procedimiento almacenado :v
            SqlDataAdapter da = new SqlDataAdapter(com); // Con esto preparamos un contenedor para recibir la data del procedimiento almacenado.
            DataTable dt = new DataTable(); // Esto crea una tabla imaginaria simplemente para facilitarnos recoger la data del procedimiento
            con.Open(); // Abrimos el canal de conexion
            da.Fill(dt); // LLenamos el contenedor con la data
            con.Close(); // Cerramos el canal de conexion
            // ... hasta acá si te diste cuenta

            // Lo que sigue debajo es para llenar la lista que creamos al principio
            foreach (DataRow dr in dt.Rows)
            {
                PerList.Add( //P.D. Date cuenta que el nombre de la lista tiene que guardar algo de relacion con el modelo que estas trabajando. PerList de Persona. TipoPerList de TipoPersona y asi >:V
                    new Persona  // Aqui el nombre del modelo respectivo
                    {
                        //Ahora se viene lo shido xD.
                        //modelo_atributo = Convert.To[Tipo de variable. Espero que te des cuenta cuales son para int o string >:V. Si es Date hay que buscar e internet xD] 
                        Persona_Id = Convert.ToInt32(dr["persona_ID"]),  // Dentro de cada dr (dr[ Aqui va el nombre del campo respectivo de la tabla tal como esta en la base de datos]),
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
            return PerList; //Devolvemos la lista llena
        }

        public bool AddPersona(Persona obj) // Metodo para añadir registro que recibe un objeto del modelo respectivo
        {
            connection();
            SqlCommand com = new SqlCommand("InsertarPersona", con); //nombre del proc almacenado de la tabla respectiva
            com.CommandType = CommandType.StoredProcedure; // Hasta aqui ya deberias saber como viste arriba.
            //Aqui tienes que tener a la mano el procedimiento almacenado de insertar en la bd
            com.Parameters.AddWithValue("@per_nom", obj.Persona_Nombre);  // Primero va el campo tal como esta en el proc. almacenado. Luego su valor que seria el atributo del modelo respectivo.
            com.Parameters.AddWithValue("@per_ape", obj.Persona_Apellido);
            com.Parameters.AddWithValue("@per_email", obj.Persona_Email);
            com.Parameters.AddWithValue("@per_fecnac", obj.Persona_FecNac);
            com.Parameters.AddWithValue("@per_sex", obj.Persona_Sexo);
            com.Parameters.AddWithValue("@per_cel", obj.Persona_Celular);
            com.Parameters.AddWithValue("@per_usr", obj.Persona_Username);
            com.Parameters.AddWithValue("@per_pwd", obj.Persona_Password);
            com.Parameters.AddWithValue("@per_tipoPer_ID", obj.Persona_Tipo_ID);
            con.Open();
            int i = com.ExecuteNonQuery(); // con esto ejecuta el procedimiento almacenado y guardamos el resultado
            con.Close();
            bool result = i >= 1 ? true : false; // si el resultado es mayor a 1 quiere decir que se inserto un registro por lo tanto true. Sino ps false.
            return result; //Hasta aqui es ctrl c y ctrl v. 
        }

        public bool UpdatePersona(Persona obj) //Modelo para actualizar. Identico al anterior
        {
            connection();
            SqlCommand com = new SqlCommand("ModificarPersona", con); //cuidado con los nombres >:V. Tiene que ser identico al nombre del proc. almacenado de la bd
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
        public bool DeletePersona(int? id) //metodo para eliminar recibiendo el id del registro
        {
            connection();
            SqlCommand com = new SqlCommand("EliminarPersona", con); // nombres!!! >:V
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@per_ID", id); // aqui solo va el id del registro para el proc. almacenado. 
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            bool result = i >= 1 ? true : false;
            return result;
        }
        // Esto es para el login

        public bool Login(string usr, string pwd)
        {
            bool result = false;
            connection();
            SqlCommand com = new SqlCommand("GetHashedPwd", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Per_usr", usr);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                string savedSaltStr = dt.Rows[0][0].ToString();
                byte[] usr_hash = Convert.FromBase64String(savedSaltStr);
                byte[] salt = new byte[16];
                Array.Copy(usr_hash, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(pwd, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                result = compareHash(hash, usr_hash);
            }

            return result;
        }

        private bool compareHash(byte[] test_hash, byte[] usr_hash)
        {
            bool res = true;
            for (int i=0; i<20; i++)
            {
                if (usr_hash[i+16] != test_hash[i])
                {
                    res = false;
                }
            }
            return res;
        }

        //Terminaste? .... Repite con los demas
    }
}