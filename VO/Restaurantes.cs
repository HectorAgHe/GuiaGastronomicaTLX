using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    internal class RestaurantesVO
    {
        public int _restauranteId;
        public string _nombre;
        public string _descripcion;
        public string _tipoComida;
        public string _direccion;
        public string _telefono;
        public string _horario;
        public string _sitioWeb;
        public string _fechaRegistro;

        // Propiedades 

        public int RestauranteId
        {
            get => _restauranteId; 
            private set => _restauranteId = value;
        }
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string Descripcion
        {
            get=> _descripcion;
            set => _descripcion = value;
        }
        public string TipoComida
        {
            get => _direccion;
            set => _direccion = value;
        }
        public string Direccion
        {
            get => _direccion;
            set => _direccion = value;

        }
        public string Telefono
        {
            get => _telefono;
            set => _telefono = value;

        }

        public string Horario
        {
            get => _horario;
            set => _horario = value;

        }
        public string SitioWeb
        {
            get => _sitioWeb;
            set => _sitioWeb = value;
        }
        public string FechaRegistro
        {
            get => _fechaRegistro;
            private set => _fechaRegistro = value;
        }



        // Constructor que inicializa los atributos con valores predeterminados
        public RestaurantesVO()
        {
            _restauranteId = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _tipoComida = string.Empty;
            _direccion = string.Empty;
            _telefono = string.Empty;
            _horario = string.Empty;
            _sitioWeb = string.Empty;
            _fechaRegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


        // Constructor que inicializa los atributos a partir de un DataRow
        public RestaurantesVO(DataRow dr)
        {
            RestauranteId = int.Parse(dr["RestauranteId"].ToString());
            Nombre = dr["Nombre"].ToString();
            Descripcion = dr["Descripcion"].ToString();
            TipoComida = dr["TipoComida"].ToString();
            Direccion = dr["Direccion"].ToString();
            Telefono = dr["Telefono"].ToString();
            Horario = dr["Horario"].ToString();
            SitioWeb = dr["SitioWeb"].ToString();
            FechaRegistro = dr["FechaRegitro"].ToString();
        }
        
    }


}
