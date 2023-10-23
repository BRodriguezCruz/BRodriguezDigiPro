using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Text;

namespace PLMVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult GetAllAlumnos()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAllSP();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            return View(alumno);
        }

        /*
        public ActionResult GetMateriasAsignadas(int? idAlumno)
        {

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Materia = new ML.Materia();
            alumnoMateria.Alumno = new ML.Alumno();

            ML.Result result = BL.AlumnoMateria.GetMateriasAsignadas(idAlumno.Value);

            if (result.Correct)
            {
                alumnoMateria.Materia.Materias = result.Objects;

                ML.Result resultAlumno = BL.Alumno.GetById(idAlumno.Value);

                if (resultAlumno.Correct)
                {
                    alumnoMateria.Alumno.IdAlumno = ((ML.Alumno)resultAlumno.Object).IdAlumno;
                    Session["idAlumno"] = alumnoMateria.Alumno.IdAlumno;
                }
            }
            return View(alumnoMateria);
        }
        */

        public ActionResult GetMateriasAsignadas(int? idAlumno)
        {
            Session["idAlumno"] = idAlumno;

            if (idAlumno == null || idAlumno == 0)
             {                                                // pendiente revisar referencia a objeto no establecida al regresar del NO asignadas a  asignadas
                                                              //sin la sesion auxiliar
                 idAlumno = (int)Session["idAlumno"];
                 //idAlumno = (int)Session["idAlumnoAuxiliar"];
             }

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Materia = new ML.Materia();

            ML.Result result = BL.AlumnoMateria.GetMateriasAsignadas(idAlumno.Value);

            if (result.Correct)
            {
                alumnoMateria.Materia.Materias = result.Objects;
            }
            return View(alumnoMateria);
        }



        public ActionResult GetMateriasNoAsignadas(int? idAlumno)
        {
            idAlumno = (int)Session["idAlumno"];
           // Session["idAlumnoAuxiliar"] = idAlumno;

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Materia = new ML.Materia();

            ML.Result result = BL.AlumnoMateria.GetMateriasNoAsignadas(idAlumno.Value);

            if (result.Correct)
            {
                alumnoMateria.Materia.Materias = result.Objects;
            }

            return View(alumnoMateria);
        }

        public ActionResult Delete()
        {
            //terminar codigo, aun no hay vista
            return PartialView();
        }
    }
}