
using System;
using System.Data.SqlClient;
using System.Configuration;

public sealed class ConexionBD
{
    private static readonly Lazy<ConexionBD> _instancia = new Lazy<ConexionBD>(() => new ConexionBD());

    private readonly string _cadenaConexion;

    public static ConexionBD Instancia => _instancia.Value;

    private ConexionBD()
    {
        _cadenaConexion = ConfigurationManager.ConnectionStrings["GuiaGastronomicaTLX"].ConnectionString;
    }

    public SqlConnection ObtenerConexion()
    {
        return new SqlConnection(_cadenaConexion);
    }



}


class Programa
{
    static void Main()
    {
        SqlConnection conexion = ConexionBD.Instancia.ObtenerConexion();
        Console.WriteLine("Cadena de conexión obtenida: " + conexion.ConnectionString);

    }
}
