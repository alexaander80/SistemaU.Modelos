using SistemaU.API.Consumer;
using SistemaU.Modelos;

namespace SistemaU.Test
{
    public class Class1
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestion de Sistema");
                Console.WriteLine("1. Gestionar Evento");
                Console.WriteLine("2. Gestionar Sala");
                Console.WriteLine("3. Gestionar Seccion");
                Console.WriteLine("4. Gestionar Ponente");
                Console.WriteLine("5. Gestionar Participante");
                Console.WriteLine("6. Gestionar Inscripcion");
                Console.WriteLine("7. Gestionar Pago");
                Console.WriteLine("8. Gestionar Certificado");
                Console.WriteLine("9. Informacion");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearEvento();
                        break;
                    case 2:

                    case 3:
                        CrearSeccion();
                        break;
                    case 4:
                        CrearPonente();
                        break;
                    case 5:
                        CrearParticipante();
                        break;
                    case 6:
                        CrearInscripcion();
                        break;
                    case 7:
                        CrearPago();
                        break;
                    case 8:
                        CrearCertificado();
                        break;
                    case 9:
                        Informe();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 10);
        }



        public static void CrearEvento()
        {
            Console.WriteLine("Ingrese el codigo del evento");
            int codigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre del evento");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha del evento");
            DateTime fecha = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el lugar del evento");
            string lugar = Console.ReadLine();
            Console.WriteLine("Ingrese el tipo del evento");
            string tipo = Console.ReadLine();
            Crud<Evento>.EndPoint = "https://localhost:7019/api/Eventos";

            var evento = Crud<Evento>.Create(new Evento
            {
                Codigo = codigo,
                Nombre = nombre,
                Fecha = fecha,
                lugar = lugar,
                Tipo = tipo
            });
            Console.WriteLine($"Evento creado con exito: {evento.Codigo}");


        }

        public static void CrearSeccion()
        {
            Console.WriteLine("Ingrese el nombre de la seccion");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de inicio de la seccion");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de fin de la seccion");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el codigo del evento");
            int eventoCodigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el codigo de la sala");
            int salaCodigo = int.Parse(Console.ReadLine());

            Crud<Seccion>.EndPoint = "https://localhost:7019/api/Secciones";

            var seccion = Crud<Seccion>.Create(new Seccion
            {
                Nombre = nombre,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                EventoCodigo = eventoCodigo,

            });
            Console.WriteLine($"Seccion creada con exito: {seccion.Codigo}");
        }

        public static void CrearPonente()
        {
            Console.WriteLine("Ingrese el nombre del ponente");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del ponente");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese la biografia del ponente");
            string biografia = Console.ReadLine();
            Console.WriteLine("Ingrese el codigo del evento");
            int eventoCodigo = int.Parse(Console.ReadLine());

            Crud<Ponente>.EndPoint = "https://localhost:7019/api/Ponentes";

            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Nombre = nombre,
                Apellido = apellido,
                Biografia = biografia,
                EventoCodigo = eventoCodigo
            });
            Console.WriteLine($"Ponente creado con exito: {ponente.Codigo}");
        }

        public static void CrearParticipante()
        {
            Console.WriteLine("Ingrese el nombre del participante");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del participante");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el correo del participante");
            string correo = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del participante");
            string telefono = Console.ReadLine();

            Crud<Participante>.EndPoint = "https://localhost:7019/api/Participantes";

            var participante = Crud<Participante>.Create(new Participante
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono = telefono
            });
            Console.WriteLine($"Participante creado con exito: {participante.Codigo}");
        }

        public static void CrearInscripcion()
        {
            Console.WriteLine("Ingrese el codigo del evento");
            int eventoCodigo = int.Parse(Console.ReadLine());
            Console.WriteLine("Fecha Inscripcion");
            DateTime fechaInscripcion = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Estado Inscripcion");
            string estadoInscripcion = Console.ReadLine();
            Console.WriteLine("Ingrese el codigo del participante");
            int participanteCodigo = int.Parse(Console.ReadLine());


            Crud<Inscripcion>.EndPoint = "https://localhost:7019/api/Inscripciones";

            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                EventoCodigo = eventoCodigo,
                FechaInscripcion = fechaInscripcion,
                EstadoDeInscripcion = estadoInscripcion,
                ParticipanteCodigo = participanteCodigo,


            });
            Console.WriteLine($"Inscripcion creada con exito: {inscripcion.Codigo}, Nombre: {inscripcion.Participantes.Nombre}");
        }

        public static void CrearPago()
        {
            Console.WriteLine("Ingrese el monto del pago");
            double monto = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el metodo del pago");
            string metodo = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha del pago");
            DateTime fecha = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el codigo de la inscripcion");
            int inscripcionCodigo = int.Parse(Console.ReadLine());

            Crud<Pago>.EndPoint = "https://localhost:7019/api/Pagos";

            var pago = Crud<Pago>.Create(new Pago
            {
                Monto = monto,
                MetodoDePago = metodo,
                FechaPago = fecha,
                InscripcionCodigo = inscripcionCodigo
            });
            Console.WriteLine($"Pago creado con exito: {pago.Codigo}");
        }


        public static void CrearCertificado()
        {
            Console.WriteLine("Fecha Emision");
            DateTime fechaEmision = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Estado Certificado");
            string estadoCertificado = Console.ReadLine();
            Console.WriteLine("Ingrese el codigo de la inscripcion");
            int inscripcionCodigo = int.Parse(Console.ReadLine());

            Crud<Certificado>.EndPoint = "https://localhost:7019/api/Certificados";
            var certificado = Crud<Certificado>.Create(new Certificado
            {
                FechaEmision = fechaEmision,
                InscripcionCodigo = inscripcionCodigo
            });

        }

        private static void Informe()
        {

            Crud<Evento>.EndPoint = "https://localhost:7019/api/Eventos";
            var evento = Crud<Evento>.GetAll();

            foreach (var e in evento)
            {
                Console.WriteLine($"Código: {e.Codigo}, EventoNombre: {e.Nombre}, Fecha: {e.Fecha}, Lugar: {e.lugar},Tipo: {e.Tipo}");
            }

            Console.WriteLine("\nParticipantes:");
            Crud<Participante>.EndPoint = "https://localhost:7019/api/Participantes";
            var participantes = Crud<Participante>.GetAll();

            foreach (var participante in participantes)
            {
                Console.WriteLine($"Participante: {participante.Nombre} {participante.Apellido}, Correo: {participante.Correo}, Teléfono: {participante.Telefono}");
            }


            Console.WriteLine("\nPagos:");
            Crud<Pago>.EndPoint = "https://localhost:7019/api/Pagos";
            var pagos = Crud<Pago>.GetAll();
            foreach (var pago in pagos)
            {
                Console.WriteLine($"Pago: Monto: {pago.Monto}, Método de pago: {pago.MetodoDePago}, Fecha: {pago.FechaPago}");
            }


            Console.WriteLine("\nCertificados Emitidos:");
            Crud<Certificado>.EndPoint = "https://localhost:7019/api/Certificados";
            var certificados = Crud<Certificado>.GetAll();
            foreach (var certificado in certificados)
            {
                Console.WriteLine($"Certificado: Fecha de emisión: {certificado.FechaEmision}, Estado: {certificado.esValido}");
            }


            Console.WriteLine("\nEstadísticas:");
            int totalEventos = evento.Count();
            int totalParticipantes = participantes.Count();
            int totalPagos = pagos.Count();
            int totalCertificados = certificados.Count();

            Console.WriteLine($"Total de Eventos: {totalEventos}");
            Console.WriteLine($"Total de Participantes: {totalParticipantes}");
            Console.WriteLine($"Total de Pagos: {totalPagos}");
            Console.WriteLine($"Total de Certificados Emitidos: {totalCertificados}");

            Console.WriteLine("\nInforme generado con éxito.");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}

