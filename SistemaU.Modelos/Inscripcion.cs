using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaU.Modelos
{
    public class Inscripcion
    {
        [Key] public int Codigo { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string EstadoDeInscripcion { get; set; }

        //KF
        public int EventoCodigo { get; set; }
        public int ParticipanteCodigo { get; set; }
        //navegacion

        public Evento? Eventos { get; set; }
        public Certificado? Certificados { get; set; }
        public Participante? Participantes { get; set; }
        public List<Pago>? Pagos { get; set; }
    }
}
