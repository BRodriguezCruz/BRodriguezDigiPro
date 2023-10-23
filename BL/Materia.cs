using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
       public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {
                    var query = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    { 
                        foreach (var registro in query)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = registro.IdMateria;
                            materia.Nombre = registro.Nombre;
                            materia.Costo = registro.Costo;

                            result.Objects.Add(materia);
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

        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {
                    var query = context.MateriaGetById(idMateria).SingleOrDefault();    

                    if (query != null) 
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo;

                        result.Object = materia;

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

        public static ML.Result DeleteEF (int idMateria)
        {
            ML.Result result = new ML.Result ();

            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {

                    var query = context.MateriaDelete(idMateria);

                    if(query > 0)
                    {
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

        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo);

                    if(query > 0)
                    {
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

        public static ML.Result UpdateEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BRodriguezControlEscolarEntities context = new DL.BRodriguezControlEscolarEntities())
                {
                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    if (query > 0)
                    {
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
