using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    internal class Reseñas
    {
        public int _reseñaId;
        public int _usuarioId;
        public int _calificacion;
        public string _comentario;
        public DateTime _fecha;
        public int _restauranteId;
        // Propiedades 
        public int ReseñaId
        {
            get => _reseñaId;
            private set => _reseñaId = value;
        }
       
        public int UsuarioId
        {
            get=> _usuarioId;
            set => _usuarioId = value;
        }
       
        public int Calificacion
        {
            get => _calificacion;
            set => _calificacion = value;
        }

        public string Comentario
        {
            get => _comentario;
            set => _comentario = value;
        }
        public DateTime Fecha
        {
            get => _fecha;
            set => _fecha = value;
        }
        public int RestauranteId
        {
            get => _restauranteId;
            set => _restauranteId = value;
        }
        
    }
}
