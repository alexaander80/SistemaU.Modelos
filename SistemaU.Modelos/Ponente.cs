using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaU.Modelos
{
    public class Ponente
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Biografia { get; set; }
        //kf
        public int EventoCodigo { get; set; }

        //navegacion
        public Evento? Eventos { get; set; }
    }
}
