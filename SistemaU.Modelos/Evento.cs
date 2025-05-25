using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SistemaU.Modelos
{
    public class Evento
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string lugar { get; set; }
        public string Tipo { get; set; }

        //KF

        //navegacion
        public List<Seccion>? Secciones { get; set; }
        public List<Ponente>? Ponentes { get; set; }
        public List<Inscripcion>? Inscripciones { get; set; }
    }
}
