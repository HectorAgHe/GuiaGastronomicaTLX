using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class MetodoDatos
    {

        // Esta clase es para ejecutar procedimientos almacenados y consultas SQL
        // y devolver los resultados a la capa de negocio  --> DataSet (Conjunto de tablas)


        public static DataSet ExcecuteDataset(string sp, params object[] parametros) 
        {
            var ds = new DataSet(); // 
            try
            {
                using (SqlConnection conn = ConexionBD.Instancia.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Indica que es un procedimiento almacenado
                        if(parametros != null && parametros.Length %2 != 0)   // Verifica que los parametros vengan en pares
                        {
                            throw new ArgumentException("Los parametros deben estar en par, clave valor");
                        }

                        //Aqui asiganaremos parametros y llamado al metodo privado que los asigna

                        AsignarParametros(cmd, parametros);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds); 
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw new AccessViolationException("Error al ejecutar el procedimiento almacenado");
            }
            return ds;
        }



        // Método para insertar, actualizar y eliminar
        public static int ExecuteNonQuery(string sp, params object[] parametros)
        {
            int exitoso = 0;
            try
            {
                using (SqlConnection conn = ConexionBD.Instancia.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand(sp, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Validar que los parámetros estén en pares
                        if (parametros != null && parametros.Length % 2 != 0)
                            throw new ArgumentException("Los parámetros deben venir en pares: nombre y valor.");

                        // Asignar parámetros al comando
                        // Aqui llamamos al metodo privado que asigna los parametros
                        AsignarParametros(cmd, parametros);


                        conn.Open();
                        cmd.ExecuteNonQuery();
                        exitoso = 1;

                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error
                throw new ApplicationException("Error al ejecutar el procedimiento almacenado.", ex);
            }
            return exitoso;
        }



        private static void AsignarParametros(SqlCommand cmd, object[] parametros)
        {

            // Asignar parámetros al comando
            for (int i = 0; i < parametros.Length; i += 2)

            {
                string nombre = parametros[i]?.ToString(); // ?
                object valor = parametros[i + 1] ?? DBNull.Value; // Si el valor es null, usar DBNull.Value
                                                                  // los ?? son operadores de coalescencia nula que devuelven el operando
                                                                  // izquierdo si no es null; de lo contrario, devuelve el operando derecho.


                if (string.IsNullOrWhiteSpace(nombre))
                    throw new ArgumentException("El nombre del parametro no puede estar vacio");
                cmd.Parameters.AddWithValue(nombre, valor);
            }
        }


        // Método que ejecuta un escalar y devuelve un entero, un escalar es un valor unico en una consulta
        public static int ExecuteEscalar(string sp, params object[] parametros)
        {
            int id = 0;

            try
            {
                using (SqlConnection conn = ConexionBD.Instancia.ObtenerConexion()) // ← Bloque using para la conexión
                {
                    using (SqlCommand cmd = new SqlCommand(sp, conn)) // ← Bloque using para el comando
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Validar que los parámetros estén en pares
                        if (parametros != null && parametros.Length % 2 != 0)
                            throw new ArgumentException("Los parámetros deben venir en pares: nombre y valor.");

                        // Asignar parámetros al comando
                        // Aqui llamamos al metodo privado que asigna los parametros
                        AsignarParametros(cmd, parametros);


                        //AsignarParametros(cmd, parametros);

                        conn.Open();
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null && int.TryParse(resultado.ToString(), out int valorEscalar))
                            id = valorEscalar;
                    } // Fin del bloque using SqlCommand
                } // Fin del bloque using SqlConnection
            }
            catch (Exception ex)
            {
                // Aquí podrías agregar logging
                throw new ApplicationException("Error al ejecutar el procedimiento almacenado.", ex);
            }

            return id;
        }



    }
}
