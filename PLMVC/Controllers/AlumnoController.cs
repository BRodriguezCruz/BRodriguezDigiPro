using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno

        /*
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAllSP();

            if (result.Correct)
            {              
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                return View();
            }         
        }
        */
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            ServiceReferenceAlumno.AlumnoServiceClient serviceWCF = new ServiceReferenceAlumno.AlumnoServiceClient();

            var result = serviceWCF.GetAll();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList(); //con "TO LIST" parseamos a lista de objectos
                return View(alumno);
            }
            else
            {
                return View();
            }
        }

        /* 
            public ActionResult Delete(int idAlumno)
         {
             ML.Alumno alumno = new ML.Alumno();
             ML.Result result = BL.Alumno.DeleteSP(idAlumno);

             if (result.Correct)
             {
                 ViewBag.Message = "REGISTRO ELIMINADO CON EXITO";
             }
             else
             {
                 ViewBag.Message = "ERROr, REGISTRO NO ELIMINADO";
             }
             return PartialView("Modal");
         }
        */
        public ActionResult Delete(int idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            ServiceReferenceAlumno.AlumnoServiceClient serviceWCF = new ServiceReferenceAlumno.AlumnoServiceClient();
            var result = serviceWCF.Delete(idAlumno);

            if (result.Correct)
            {
                ViewBag.Message = "REGISTRO ELIMINADO CON EXITO";
            }
            else
            {
                ViewBag.Message = "ERROr, REGISTRO NO ELIMINADO";
            }
            return PartialView("Modal");
        }


        /*
        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = new ML.Result();

            if (idAlumno != null)
            {
                result = BL.Alumno.GetById(idAlumno.Value);

                if(result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                }
            }
            return View(alumno);
        }
        */

        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if (idAlumno != null)
            {
                ServiceReferenceAlumno.AlumnoServiceClient serviceWCF = new ServiceReferenceAlumno.AlumnoServiceClient();
                var result = serviceWCF.GetById(idAlumno.Value);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                }
            }
            return View(alumno);
        }

        /*
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (alumno.IdAlumno == 0)
            {
                result = BL.Alumno.AddSP(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO INSERTADO CON EXITO";
                }
                else
                {
                    ViewBag.Message = "ERROS, REGISTRO NO INSERTADO";
                }
            }
            else
            {
                result = BL.Alumno.UpdateSP(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO ACTUALIZADO CON EXITO";
                }
                else
                {
                    ViewBag.Message = "ERROR, REGISTRO NO ACTUALIZADO";
                }
            }
            return PartialView("Modal");
        }
        */

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ServiceReferenceAlumno.AlumnoServiceClient serviceWCF = new ServiceReferenceAlumno.AlumnoServiceClient();

            if (alumno.IdAlumno == 0)
            {
                var result = serviceWCF.Add(alumno);

                if(result.Correct)
                {
                    ViewBag.Message = "REGISTRO INSERTADO CON EXITO";
                }
                else
                {
                    ViewBag.Message = "ERROS, REGISTRO NO INSERTADO";
                }
            }
            else
            {
                var result = serviceWCF.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO ACTUALIZADO CON EXITO";
                }
                else
                {
                    ViewBag.Message = "ERROR, REGISTRO NO ACTUALIZADO";
                }
            }
            return PartialView("Modal");
        }
    }
}