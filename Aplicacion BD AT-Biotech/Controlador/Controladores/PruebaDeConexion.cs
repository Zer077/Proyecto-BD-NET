using System;

namespace Controlador.Controladores
{
    public class PruebaDeConexion
    {
        public Boolean PruebaConexion()
        {
            return new Modelo.Repositorios.PruebaDeConexion().Prueba();
        }
    }
}