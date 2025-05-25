using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaU.Modelos
{
    public class Certificado
    {
        [Key] public int Codigo { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool esValido { get; set; }

        //KF
        public int InscripcionCodigo { get; set; }
        //navegacion
        public Inscripcion? Inscripciones { get; set; }
    }
}
