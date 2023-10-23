using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia


        /*
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllEF();
            ML.Materia materia = new ML.Materia();  

            if(result.Correct)
            {
                materia.Materias = result.Objects;
            }
            return View(materia);
        }
        */

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();

            //LLAMADO AL SERVICIO
            ML.Result result = new ML.Result();

            using (var cliente = new HttpClient()) //variable que puede acceder a los servicios 
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]); //hacer el llamado a el APP SETTING 
                var respondeTask = cliente.GetAsync("materia");
                respondeTask.Wait(); //espera por respuesta

                var resultServicio = respondeTask.Result;   //igualamos el resultado de la respuesta a una variable 

                if (resultServicio.IsSuccessStatusCode) // si el resultado del servicio es exitoso 
                {
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultMateria in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultMateria.ToString());
                        materia.Materias.Add(resultItemList);
                    }
                }

            }

            return View(materia);
        }

        /*
        public ActionResult Delete(int idMateria)
        {
            ML.Result result = BL.Materia.DeleteEF(idMateria);

            if(result.Correct)
            {
                ViewBag.Message = "REGISTRO ELIMINADO EXITOSAMENTE";
            }
            else
            {
                ViewBag.Message = "ERROR, REGISTRO NO ELIMINADO";
            }

            return PartialView("Modal");
        }
        */

        public ActionResult Delete(int idRecuperado) //El nombre del id debe ser igual al declaado en la vista 
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                var deleteTask = cliente.DeleteAsync("materia/" + idRecuperado);
                deleteTask.Wait();

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se elimino correctamente la materia";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error, no se elimino la materia"
;
                }

            }

            return PartialView("Modal"); // SE REGRESA UNA PARTIALVIEW y no una VIEW
        }

        /*
        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (idMateria != null) //vista llena con materia
            {
                ML.Result result = BL.Materia.GetById(idMateria.Value);
               
                if(result.Correct)
                {
                    materia = (ML.Materia)result.Object;
                }
            } //si no, vista vacia
            return View(materia);
        }

        */
        [HttpGet] //FORM PARA WEB API 
        public ActionResult Form(int? idMateria) //el nombre del ID debe ser el mismo escrito en el href de mi vista getAll
                                                     // Un ? significa que puede estar lleno o no ese campo
        {
            ML.Materia materia = new ML.Materia();

            if (idMateria != null)
            {
                using (var cliente = new HttpClient()) //variable para accder a los servicios HTTP 
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);
                    var responseTask = cliente.GetAsync("materia/" + idMateria);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Materia resultItemsList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());

                        materia = resultItemsList;

                    }
                }
               
            }
            /*mostrar vista vacia
            else /
            {
                return View();
            }
            */
            return View(materia);
        }

        /*
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            if (ModelState.IsValid)
            {
                if (materia.IdMateria != 0)
                {
                    result = BL.Materia.UpdateEF(materia);

                    if (result.Correct)
                    {
                        ViewBag.Message = "REGISTRO ACTUALIZADO CORRECTAMENTE";
                    }
                    else
                    {
                        ViewBag.Message = "ERROR, REGISTRO NO ACTUALIZADO";
                    }
                }
                else
                {
                    result = BL.Materia.AddEF(materia);

                    if (result.Correct)
                    {
                        ViewBag.Message = "REGISTRO INGRESA CORRECTAMENTE";
                    }
                    else
                    {
                        ViewBag.Message = "ERROR, REGISTRO NO AGREAGADO";
                    }
                }

                return PartialView("Modal");
            }
            else
            {
                return View(materia); //regresa la vista llena con los datos cargados anteriormente
            }
            
        }
        */

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == 0)
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                    //HTTP POST
                    var postTask = cliente.PostAsJsonAsync("materia", materia );
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se Agrego correctamente la materia";
                    }
                    else
                    {
                        ViewBag.Message = "No se pudo agregar la materia";
                    }
                }
            }
            else
            {
                using (var cliente = new HttpClient())
                {
                    int idMateria = materia.IdMateria;

                    cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["RutaWebApi"]);

                    var putTask = cliente.PutAsJsonAsync("materia/" + idMateria, materia);
                    putTask.Wait();

                    var result = putTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "SE ACTUALIZO CORRECTAMENTE LA MATERIA";
                    }
                    else
                    {
                        ViewBag.Message = "NO SE LOGRO ACTUALIZAR LA MATERIA";
                    }
                }
            }

            return PartialView("Modal");
        }
    }
}