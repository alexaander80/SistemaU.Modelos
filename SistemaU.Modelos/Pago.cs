using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaU.Modelos
{
    public class Pago
    {
        [Key] public int Codigo { get; set; }
        public double Monto { get; set; }
        public string MetodoDePago { get; set; }
        public DateTime FechaPago { get; set; }

        //KF
        public int InscripcionCodigo { get; set; }

        //navegacion
        public Inscripcion? Inscripciones { get; set; }
    }
}
