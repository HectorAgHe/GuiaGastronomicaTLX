using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VO;

namespace CapaDatos
{
    public class DalRestaurantes
    {
        // Aquí van los métodos específicos para la entidad Restaurantes
        // Ejemplo: ListarRestaurantes
        public static List<RestaurantesVO> GetRestaurantes()
        {
            try
            {
                DataSet dsRestaurantes = MetodoDatos.ExcecuteDataset("sp_ListarRestaurantes");
                List<RestaurantesVO> listaRestaurantes = new List<RestaurantesVO>();
                if (dsRestaurantes != null && dsRestaurantes.Tables.Count > 0)
                {
                    // Recorre cada fila del dsProductos e inserta cada una en la lista productos
                    foreach (DataRow dr in dsRestaurantes.Tables[0].Rows)
                    {
                        listaRestaurantes.Add(new RestaurantesVO(dr));
                    }
                }
                return listaRestaurantes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al obtener los productos" + e.Message);
                throw;
            }
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
            MetodoDatos.ExecuteNonQuery("sp_InsertarRestaurante",
                
                    "@nombre", nombre,
                    "@descripcion", descripcion,
                    "@tipoComida", tipoComida,
                    "@direccion", direccion,
                    "@telefono", telefono,
                    "@horario", horario,
                    "@sitioWeb", sitioWeb
            );
        }

        public static RestaurantesVO GetRestaurantesByID(int restauranteId)
        {
            try
            {
                DataSet ds = MetodoDatos.ExcecuteDataset("sp_ObtenerRestaurantePorId", "@restauranteId", restauranteId);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    return new RestaurantesVO(row); // Constructor desde DataRow
                }

                // Conservé el comportamiento original: devolver VO vacío si no se encuentra
                return new RestaurantesVO();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetByID (ID: {restauranteId}): {ex.Message}");
                throw;
            }
        }






        public static void UpdRestaurante(
            int restauranteId,
            string nombre,
            string descripcion,
            string tipoComida,
            string direccion,
            string telefono,
            string horario,
            string sitioWeb
                 
        )
        {
            try
            {
                // Ejecuta el stored procedure; devolvemos filas afectadas desde MetodoDatos si es necesario
                MetodoDatos.ExecuteNonQuery(
                    "sp_ActualizarRestaurante",
                    // Usar el mismo nombre de parámetro que se usa en los otros métodos (consistencia)
                    "@restauranteId", restauranteId,
                    "@nombre", nombre,
                    "@descripcion", descripcion,
                    "@tipoComida", tipoComida,
                    "@direccion", direccion,
                    "@telefono", telefono,
                    "@horario", horario,
                    "@sitioWeb", sitioWeb
                //,"@urlFoto", urlFoto
                );
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Si en el futuro agregas log o limpieza, va aquí
            }
        } // del Update






        public static int Delete(int restauranteId)
        {
            try
            {
                return MetodoDatos.ExecuteNonQuery("sp_EliminarRestaurante", "@restauranteId", restauranteId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Delete (ID: {restauranteId}): {ex.Message}");
                throw;
            }
        }



    }
}
