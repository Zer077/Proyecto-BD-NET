using Modelo.Infraestructura;
using Modelo.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace web.Controllers
{
    public class LibretaController : ApiController
    {
        private Contacto contexto = new Contacto();

        /// <summary>
        /// Metodo que extrae todos los contactos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Contacto> Get()
        {
            return new LibretaRepositorio().ObtenerContactos();
        }

        /// <summary>
        /// Metodo que devuelve un contacto por id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Contacto Get(int id)
        {
            using (var contexto = new LibretaATBiotechEntities())
            {
                return contexto.Contactoes.FirstOrDefault(c => c.ID == id);
            }
        }

        /// <summary>
        /// Metodo que inserta contactos
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult InsertarContacto([FromBody] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                new LibretaRepositorio().InsertarContacto(contacto);

                return Ok(contacto);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Método que modifica contactos
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult ModificarContacto(int id, [FromBody] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                if (new LibretaATBiotechEntities().Contactoes.Count(c => c.ID == id) > 0)
                {
                    new LibretaRepositorio().ModificarContacto(contacto);

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Metodo que elimina contactos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult EliminarContacto(int id)
        {
            var contacto = new LibretaATBiotechEntities().Contactoes.Find(id);
            if (contacto != null)
            {
                new LibretaRepositorio().EliminarContacto(id);

                return Ok(contacto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}