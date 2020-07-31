using ConsumeWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConsumeWeb.Controllers
{
    public class ContactoController : Controller
    {
        private string url = "https://localhost:44398";

        public async Task<ActionResult> Index()
        {
            List<Contacto> listaContactos = new List<Contacto>();

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //consigue todos los contactos con el Httpclient
                HttpResponseMessage respuesta = await cliente.GetAsync("/api/libreta/");
                if (respuesta.IsSuccessStatusCode)
                {
                    //asigna los datos deserializando el api para almacenarlos
                    var respuestaAux = respuesta.Content.ReadAsStringAsync().Result;
                    listaContactos = JsonConvert.DeserializeObject<List<Contacto>>(respuestaAux);
                }
                //Muestra la lista de todos los usuarios
                return View(listaContactos);
            }
        }

        /// <summary>
        /// Get del edit
        /// </summary>
        /// <returns></returns>
        public ActionResult create()
        {
            return View();
        }

        /// <summary>
        /// Put del edit
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Contacto contacto)
        {
            HttpResponseMessage respuesta;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44398/api/libreta");
                var postTask = cliente.PostAsJsonAsync<Contacto>("libreta", contacto);
                postTask.Wait();
                respuesta = postTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "ERROR " + respuesta.ReasonPhrase + " " + respuesta.Content);
            return View(contacto);
        }

        /// <summary>
        /// Put del edit
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Contacto contacto)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                var putTask = cliente.PutAsJsonAsync($"/api/libreta/{contacto.ID}", contacto);
                putTask.Wait();
                HttpResponseMessage respuesta = putTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "ERROR");
            return View(contacto);
        }

        /// <summary>
        /// Get del edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Contacto contacto = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                var responseTask = cliente.GetAsync("/api/libreta/" + id.ToString());
                responseTask.Wait();
                var respuesta = responseTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Contacto>();
                    readTask.Wait();
                    contacto = readTask.Result;
                }
            }
            return View(contacto);
        }

        /// <summary>
        /// Get de delete borra al usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Contacto contacto = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                var responseTask = cliente.GetAsync("/api/libreta/" + id.ToString());
                responseTask.Wait();
                var respuesta = responseTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<Contacto>();
                    readTask.Wait();
                    contacto = readTask.Result;
                }
            }
            ModelState.AddModelError(string.Empty, "ERROR");
            return View(contacto);
        }

        [HttpPost]
        public ActionResult Delete(Contacto contacto, int id)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(url);
                var deleteTask = cliente.DeleteAsync($"api/libreta/" + id.ToString());
                deleteTask.Wait();
                var respuesta = deleteTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "ERROR");
            return View(contacto);
        }
    }
}