using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {

        public static ML.Result GetMateriasAsignadas(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {
                    var query = context.GetMateriasAsignadas(idAlumno).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Materia = new ML.Materia();

                            alumnoMateria.Alumno.IdAlumno = registro.IdAlumno;
                            alumnoMateria.Alumno.Nombre = registro.Nombre;

                            alumnoMateria.Materia.IdMateria = registro.IdMateria;
                            alumnoMateria.Materia.Nombre = registro.Nombre; 

                            result.Objects.Add( alumnoMateria );
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


        public static ML.Result GetMateriasNoAsignadas(int idAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {
                    var query = context.GetMateriasNoAsignadas(idAlumno).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria(); 
                            alumnoMateria.Materia = new ML.Materia();

                            alumnoMateria.Materia.IdMateria = registro.IdMateria;
                            alumnoMateria.Materia.Nombre = registro.Nombre;
                            alumnoMateria.Materia.Costo = registro.Costo;

                            result.Objects.Add(alumnoMateria);
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
    }
}
