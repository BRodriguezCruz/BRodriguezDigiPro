using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetAll"; //nombre del SP

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure; //indicamos que sera un comando de tipo SP si no, no funcionara

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); //adapter lee y extrae inf (en este caso de cmd que tiene elel query del SP)
                    DataTable tablaAlumnos = new DataTable(); // creamos/inicializamnos tabla 
                    adapter.Fill(tablaAlumnos); //con la informacion leida y extraida llenamos la tabla

                    if(tablaAlumnos.Rows.Count > 0) //si una fila de la tabla es mayor a 0 significa que trae datos y hay que igualarlos a la prop de ML
                    {
                        result.Objects = new List<object>(); //iniclizamos lista de objetos en result para guardar

                        foreach (DataRow registro in tablaAlumnos.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(registro[0].ToString());
                            alumno.Nombre = registro[1].ToString();
                            alumno.ApellidoPaterno = registro[2].ToString();
                            alumno.ApellidoMaterno = registro[3].ToString();

                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int idAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "AlumnoGetById";

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    collection[0].Value = idAlumno;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); //leer y extraer datos 
                    DataTable tablaAlumnos = new DataTable(); //crear tabla
                    adapter.Fill(tablaAlumnos); //Accedo al metodo llenar atraves del objeto adapter y lleno la tabla con lo leido por DataAdapter

                    if(tablaAlumnos.Rows.Count > 0)
                    {
                        DataRow row = tablaAlumnos.Rows[0];
                        ML.Alumno alumno = new ML.Alumno();

                        alumno.IdAlumno = int.Parse(row[0].ToString());
                        alumno.Nombre = row[1].ToString();
                        alumno.ApellidoPaterno = row[2].ToString(); 
                        alumno.ApellidoMaterno = row[3].ToString();

                        result.Object = alumno;

                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex) 
            { 
                result.ErrorMessage=ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

                return result;
        }

        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoAdd"; //nombre del SP

                    SqlCommand cmd = new SqlCommand(query, context); //command necesita la conexion y el query a realizar
                    cmd.CommandType = CommandType.StoredProcedure; //indicamos que es un comando de tipo SP

                    SqlParameter[] collection = new SqlParameter[3]; //indicamos que es una coleccion de 3 datos

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery(); // igualamos el resultado de la ejecucion a una variable INT para validar con ella

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex) 
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false; 
                result.Ex = ex;
            }
            return result;  
        }

        public static ML.Result UpdateSP (ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string query = "AlumnoUpdate"; //nombre SP

                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure; //indicamos que es comando de tipo SP

                    SqlParameter[] collection = new SqlParameter[4];

                    collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    collection[0].Value = alumno.IdAlumno;

                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = alumno.Nombre;

                    collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoPaterno;

                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = alumno.ApellidoMaterno;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();   

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result DeleteSP (int idAlumno) 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoDelete";

                    SqlCommand cmd  = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure; //tipo SP el comando

                    SqlParameter[] collection = new SqlParameter[1];

                    collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    collection[0].Value = idAlumno;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    
                    if (rowsAffected > 0) 
                    { 
                        result.Correct = true;
                    }
                    else 
                    { 
                        result.Correct= false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;                    
                result.Ex = ex;
            }
            return result;
        }
    }
}
