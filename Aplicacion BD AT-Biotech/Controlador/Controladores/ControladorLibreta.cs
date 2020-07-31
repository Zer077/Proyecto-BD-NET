﻿using Controlador.EntidadesDTO;
using Modelo.Infraestructura;
using System.Collections.Generic;

namespace Controlador.Controladores
{
    public class ControladorLibreta
    {    /// <summary>
         /// Me devuelve la lista de todos los contactos de nuestra libreta
         /// </summary>
         /// <returns></returns>
        public List<ContactoDTO> ObtenerListadoContactos()
        {
            List<Contacto> LibretaDatos = new Modelo.Repositorios.LibretaRepositorio().ObtenerContactos();
            List<ContactoDTO> ListaDevolver = new List<ContactoDTO>();
            foreach (var contacto in LibretaDatos)
            {
                var dto = new ContactoDTO();
                //dto.ID = contacto.ID;
                //dto.Nombre = contacto.Nombre;
                //dto.Apellido = contacto.Apellido;
                //dto.Direccion = contacto.Direccion;
                //dto.Email = contacto.Email;
                //dto.Empresa = contacto.Empresa;
                //dto.Telefono = contacto.Telefono;
                Conversor.Parse(contacto, ref dto);

                ListaDevolver.Add(dto);
            }
            return ListaDevolver;
        }

        /// <summary>
        /// Inserta un contacto a la libreta
        /// </summary>
        /// <param name="contactoDTO"></param>
        public void InsertarContacto(ContactoDTO contactoDTO)
        {
            Contacto contactoBD = new Contacto();
            //contactoBD.Nombre = contactoDTO.Nombre;
            //contactoBD.Apellido = contactoDTO.Apellido;
            //contactoBD.Email = contactoDTO.Email;
            //contactoBD.Empresa = contactoDTO.Empresa;
            //contactoBD.Direccion = contactoDTO.Direccion;
            //contactoBD.Telefono = contactoDTO.Telefono;

            Conversor.Parse(contactoDTO, ref contactoBD);

            new Modelo.Repositorios.LibretaRepositorio().InsertarContacto(contactoBD);
        }

        /// <summary>
        /// Permite modificar el contacto, envia la informacion al modelo tras haber creado el objeto
        /// </summary>
        /// <param name="contactoModificado"></param>
        public void ModificarContacto(ContactoDTO contactoModificado)
        {
            Contacto contactoBD = new Contacto();
            //contactoBD.ID = contactoModificado.ID;
            //contactoBD.Nombre = contactoModificado.Nombre;
            //contactoBD.Apellido = contactoModificado.Apellido;
            //contactoBD.Email = contactoModificado.Email;
            //contactoBD.Empresa = contactoModificado.Empresa;
            //contactoBD.Direccion = contactoModificado.Direccion;
            //contactoBD.Telefono = contactoModificado.Telefono;

            Conversor.Parse(contactoModificado, ref contactoBD);
            new Modelo.Repositorios.LibretaRepositorio().ModificarContacto(contactoBD);
        }

        /// <summary>
        /// Envia al modelo el id para que pueda eliminarlo
        /// </summary>
        /// <param name="id"></param>
        public void EliminarContacto(int id)
        {
            new Modelo.Repositorios.LibretaRepositorio().EliminarContacto(id);
        }
    }
}