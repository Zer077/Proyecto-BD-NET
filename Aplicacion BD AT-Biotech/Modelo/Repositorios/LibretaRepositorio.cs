using Modelo.Infraestructura;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Modelo.Repositorios
{
    public class LibretaRepositorio
    {
        /// <summary>
        /// Obtiene La libreta
        /// </summary>
        /// <returns></returns>
        public List<Contacto> ObtenerContactos()
        {
            List<Contacto> listaContactos = new List<Contacto>();
            try
            {
                using (var contexto = new LibretaATBiotechEntities())
                {
                    listaContactos = contexto.Contactoes.ToList();
                }
                return listaContactos;
            }
            catch
            {
                return listaContactos;
            }
        }

        /// <summary>
        /// Inserta un contacto a la base de datos
        /// </summary>
        /// <param name="contacto"></param>
        public void InsertarContacto(Contacto contacto)
        {
            using (var contexto = new LibretaATBiotechEntities())
            {
                contexto.Contactoes.Add(contacto);
                contexto.SaveChanges();
            }
        }


        /// <summary>
        /// Modifica el contacto al pasarle un objeto
        /// </summary>
        /// <param name="nuevoContacto"></param>
        public void ModificarContacto(Contacto nuevoContacto)
        {
            try
            {
                using (var contexto = new LibretaATBiotechEntities())
                {
                    Contacto contactoOriginal = contexto.Contactoes.Where(contacto => contacto.ID == nuevoContacto.ID).First();
                    contactoOriginal.Nombre = nuevoContacto.Nombre;
                    contactoOriginal.Apellido = nuevoContacto.Apellido;
                    contactoOriginal.Direccion = nuevoContacto.Direccion;
                    contactoOriginal.Email = nuevoContacto.Email;
                    contactoOriginal.Empresa = nuevoContacto.Empresa;
                    contactoOriginal.Telefono = nuevoContacto.Telefono;
                    contexto.Entry(contactoOriginal).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Elimina el contacto con el ID
        /// </summary>
        /// <param name="id"></param>
        public void EliminarContacto(int id)
        {
            using (var contexto = new LibretaATBiotechEntities())
            {
                Contacto libroEliminar = contexto.Contactoes.Where(contacto => contacto.ID == id).First();

                contexto.Entry(libroEliminar).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}