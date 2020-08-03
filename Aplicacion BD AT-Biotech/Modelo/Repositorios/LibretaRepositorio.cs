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
        /// Obtiene todos los contactos
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
            try
            {
                using (var contexto = new LibretaATBiotechEntities())
                {
                    contexto.Contactoes.Add(contacto);
                    contexto.SaveChanges();
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Modifica el contacto que le pasas con los datos introducidos
        /// </summary>
        /// <param name="nuevoContacto"></param>
        public void ModificarContacto(Contacto nuevoContacto)
        {
            try
            {
                using (var contexto = new LibretaATBiotechEntities())
                {

                    //Busca el contacto con la misma id en la libreta 
                    Contacto contactoOriginal = contexto.Contactoes.Where(contacto => contacto.ID == nuevoContacto.ID).First();

                    //Modifica sus valores
                    contactoOriginal.Nombre = nuevoContacto.Nombre;
                    contactoOriginal.Apellido = nuevoContacto.Apellido;
                    contactoOriginal.Direccion = nuevoContacto.Direccion;
                    contactoOriginal.Email = nuevoContacto.Email;
                    contactoOriginal.Empresa = nuevoContacto.Empresa;
                    contactoOriginal.Telefono = nuevoContacto.Telefono;





                    //Lo modifica en la BD
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
            try
            {
                using (var contexto = new LibretaATBiotechEntities())
                {
                    //Busca el contacto a eliminar
                    Contacto contactoEliminar = contexto.Contactoes.Where(contacto => contacto.ID == id).First();

                    //Lo elimina en la BD
                    contexto.Entry(contactoEliminar).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();
                }
            }
            catch (Exception) { }
        }
    }
}