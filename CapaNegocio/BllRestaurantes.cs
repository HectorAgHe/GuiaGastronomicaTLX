using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using CapaDatos;

namespace CapaNegocio
{
    public class BllRestaurantes
    {

        public static List<RestaurantesVO> GetRestaurantes()
        {
            return DalRestaurantes.GetRestaurantes();
        }
        

        public static void Insert(
            string nombre,
            string descripcion,
            string tipoComida,
            string direccion,
            string telefono,
            string horario,
            string sitioWeb           
            )
        {
            DalRestaurantes.Insert(nombre, descripcion, tipoComida, direccion, telefono, horario, sitioWeb);
        }

        public static void UpdRestaurante(
             int restauranteId,
             string nombre,
            string descripcion,
            string tipoComida,
            string direccion,
            string telefono,
            string horario,
            string sitioWeb)
        {
            DalRestaurantes.UpdRestaurante(restauranteId, nombre, descripcion, tipoComida, direccion, telefono, horario, sitioWeb);
        }




        public static RestaurantesVO GetRestaurantesByID(int idChofer)
        {
            return DalRestaurantes.GetRestaurantesByID(idChofer);
        }




        public static bool Delete(int restauranteId)
        {
            RestaurantesVO restaurante = GetRestaurantesByID(restauranteId);

            if (restaurante == null)
            {
                return false; // No se puede eliminar si el restaurante no existe
            }

            int filasAfectadas = DalRestaurantes.Delete(restauranteId);
            return filasAfectadas > 0; // Si se eliminaron filas, retorna true
        }



        //public static bool TieneRutasAsignadas(int idChofer)
        //{
        //    return DalChoferes.ContarRutasPorChofer(idChofer) > 0;
        //}




    }
}
