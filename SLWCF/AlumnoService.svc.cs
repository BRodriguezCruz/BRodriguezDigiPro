using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlumnoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlumnoService.svc or AlumnoService.svc.cs at the Solution Explorer and start debugging.
    public class AlumnoService : IAlumnoService
    {
        public SLWCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.AddSP(alumno);//INSTANCIAMOS PARA ACCEDER A LAS PROP
                                                       //igualamos para ejecutar metodo y regrese un result ya sea exitoso, o no, con objetos o no, etc .. 

            return new SLWCF.Result  //parseamos las propiedades ML.result a SLWCF.Result con las mismas prop pero con la capacidad de SERIALIZAR O DESERIALIZAR
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
        public SLWCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.UpdateSP(alumno);//INSTANCIAMOS PARA ACCEDER A LAS PROP
                                                          //igualamos para ejecutar metodo y regrese un result ya sea exitoso, o no, con objetos o no, etc .. 

            return new SLWCF.Result  //parseamos las propiedades ML.result a SLWCF.Result con las mismas prop pero con la capacidad de SERIALIZAR O DESERIALIZAR
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result Delete(int idAlumno)
        {
            ML.Result result = BL.Alumno.DeleteSP(idAlumno);

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAllSP();

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetById(int idAlumno)
        {
            ML.Result result = BL.Alumno.GetById(idAlumno);

            return new SLWCF.Result
            {
                ErrorMessage = result.ErrorMessage,
                Correct = result.Correct,
                Object = result.Object,
                Objects = result.Objects,
                Ex = result.Ex
            };
        }
    }
}
