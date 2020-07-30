using Modelo.Infraestructura;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Modelo.Repositorios
{
    public class PruebaDeConexion
    {
        public Boolean Prueba()
        {
            try
            {
                using (var contexto = new LibretaATBiotechEntities())
                {
                    List<Contacto> listaPersonas = contexto.Contactoes.ToList();
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;

                throw;
            }
        }
    }
}