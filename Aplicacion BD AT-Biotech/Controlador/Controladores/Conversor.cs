using System;
using System.Reflection;

namespace Controlador.Controladores
{
    public class Conversor
    {
        /// <summary>
        /// Si los dos objetos que se pasan tienen las mismas propiedades con el mismo nombre, esta clase
        /// pasará los datos del uno al otro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceObject"></param>
        /// <param name="destObject"></param>
        public static void Parse<T>(object sourceObject, ref T destObject)
        {
            if (sourceObject == null || destObject == null)
            {
                return;
            }
            else
            {
                Type sourceType = sourceObject.GetType();
                Type targerType = destObject.GetType();
                foreach (PropertyInfo p in sourceType.GetProperties())
                {
                    PropertyInfo targetObj = targerType.GetProperty(p.Name);
                    if (targetObj == null)
                    {
                        continue;
                    }

                    targetObj.SetValue(destObject, p.GetValue(sourceObject, null), null);
                }
            }
        }
    }
}