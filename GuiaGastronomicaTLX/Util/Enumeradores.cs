using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace GuiaGastronomicaTLX.Util
{
    public class Enumeradores
    {
        public enum Tipo
        {
            Trailer,

            Torton,

            [Description("Doble Remolque")]
            Doble_Remolque,

            Volteo,

            [Description("Semi Remolque")]
            Semi_Remolque
        }

        public enum Marca
        {
            Volvo,

            Alliance,

            Ford,

            [Description("Mercedes Benz")]
            Mercedes,

            Dina
        }
    }
}