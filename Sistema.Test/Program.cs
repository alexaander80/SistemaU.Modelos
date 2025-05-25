using SistemaU.API.Consumer;
using SistemaU.Modelos;

namespace Sistema.Test
{
    internal class Program
    {
        int opcionPrincipal;
        static void Main(string[] args)
        {
            int opcionPrincipal;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Gestionar Eventos");
                Console.WriteLine("2. Gestionar Secciones");
                Console.WriteLine("3. Gestionar Ponentes");
                Console.WriteLine("4. Gestionar Participantes");
                Console.WriteLine("5. Gestionar Inscripciones");
                Console.WriteLine("6. Gestionar Pagos");
                Console.WriteLine("7. Gestionar Certificados");
                Console.WriteLine("8. Generar Informe");
                Console.WriteLine("9. Salir");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcionPrincipal))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcionPrincipal)
                {
                    case 1:
                        GestionarEventos();
                        break;
                    case 2:
                        GestionarSecciones();
                        break;
                    case 3:
                        GestionarPonentes();
                        break;
                    case 4:
                        GestionarParticipantes();
                        break;
                    case 5:
                        GestionarInscripciones();
                        break;
                    case 6:
                        GestionarPagos();
                        break;
                    case 7:
                        GestionarCertificados();
                        break;
                    case 8:
                        Informe();
                        break;
                    case 9:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcionPrincipal != 9);
        }
        public static void CrearEvento()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Eventos");
                Console.WriteLine("1. Agregar Evento");
                Console.WriteLine("2. Eliminar Evento");
                Console.WriteLine("3. Actualizar Evento");
                Console.WriteLine("4. Listar Eventos");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarEventos(); break;
                    case 2: EliminarEvento(); break;
                    case 3: ActualizarEvento(); break;
                    case 4: ListarEventos(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);

        }

       
        public static void GestionarEventos()
        {


                Console.WriteLine("Ingrese el código del evento:");
                int codigo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del evento:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha del evento (yyyy-MM-dd):");
                DateTime fecha = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el lugar del evento:");
                string lugar = Console.ReadLine();
                Console.WriteLine("Ingrese el tipo del evento:");
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

                Console.WriteLine($"Evento creado con éxito: {evento.Codigo}");
            }

            public static void ListarEventos()
            {
                Crud<Evento>.EndPoint = "https://localhost:7019/api/Eventos";
                var eventos = Crud<Evento>.GetAll();
                foreach (var e in eventos)
                {
                    Console.WriteLine($"Código: {e.Codigo}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToShortDateString()}, Lugar: {e.lugar}, Tipo: {e.Tipo}");
                }
            }

            public static void ActualizarEvento()
            {
                Console.WriteLine("Ingrese el código del evento a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Evento>.EndPoint = "https://localhost:7019/api/Eventos";
                var evento = Crud<Evento>.GetById(codigo);
                if (evento == null)
                {
                    Console.WriteLine("Evento no encontrado.");
                    return;
                }

                Console.WriteLine($"Nombre actual: {evento.Nombre}");
                Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                    evento.Nombre = nombre;

                Console.WriteLine($"Fecha actual: {evento.Fecha.ToShortDateString()}");
                Console.Write("Nueva fecha (yyyy-MM-dd, dejar vacío para no cambiar): ");
                string fechaStr = Console.ReadLine();
                if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    evento.Fecha = fecha;

                Console.WriteLine($"Lugar actual: {evento.lugar}");
                Console.Write("Nuevo lugar (dejar vacío para no cambiar): ");
                string lugar = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(lugar))
                    evento.lugar = lugar;

                Console.WriteLine($"Tipo actual: {evento.Tipo}");
                Console.Write("Nuevo tipo (dejar vacío para no cambiar): ");
                string tipo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tipo))
                    evento.Tipo = tipo;

                Crud<Evento>.Update(evento.Codigo, evento);
                Console.WriteLine("Evento actualizado correctamente.");
            }

            public static void EliminarEvento()
            {
                Console.WriteLine("Ingrese el código del evento a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Evento>.EndPoint = "https://localhost:7019/api/Eventos";
                var evento = Crud<Evento>.GetById(codigo);
                if (evento == null)
                {
                    Console.WriteLine("Evento no encontrado.");
                    return;
                }

                Crud<Evento>.Delete(codigo);
                Console.WriteLine("Evento eliminado correctamente.");
            }

        public static void CrearSeccion()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Secciones");
                Console.WriteLine("1. Agregar Sección");
                Console.WriteLine("2. Eliminar Sección");
                Console.WriteLine("3. Actualizar Sección");
                Console.WriteLine("4. Listar Secciones");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarSecciones(); break;
                    case 2: EliminarSeccion(); break;
                    case 3: ActualizarSeccion(); break;
                    case 4: ListarSecciones(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);

        }



            public static void GestionarSecciones()
            {
                Console.WriteLine("Ingrese el nombre de la sección:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha de inicio (yyyy-MM-dd):");
                DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la fecha de fin (yyyy-MM-dd):");
                DateTime fechaFin = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el código del evento:");
                int eventoCodigo = int.Parse(Console.ReadLine());

                Crud<Seccion>.EndPoint = "https://localhost:7019/api/Secciones";
                var seccion = Crud<Seccion>.Create(new Seccion
                {
                    Nombre = nombre,
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    EventoCodigo = eventoCodigo,
                });

                Console.WriteLine($"Sección creada con éxito: {seccion.Codigo}");
            }

            public static void ListarSecciones()
            {
                Crud<Seccion>.EndPoint = "https://localhost:7019/api/Secciones";
                var secciones = Crud<Seccion>.GetAll();
                foreach (var s in secciones)
                {
                    Console.WriteLine($"Código: {s.Codigo}, Nombre: {s.Nombre}, Inicio: {s.FechaInicio.ToShortDateString()}, Fin: {s.FechaFin.ToShortDateString()}, EventoCodigo: {s.EventoCodigo}");
                }
            }

            public static void ActualizarSeccion()
            {
                Console.WriteLine("Ingrese el código de la sección a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Seccion>.EndPoint = "https://localhost:7019/api/Secciones";
                var seccion = Crud<Seccion>.GetById(codigo);
                if (seccion == null)
                {
                    Console.WriteLine("Sección no encontrada.");
                    return;
                }

                Console.WriteLine($"Nombre actual: {seccion.Nombre}");
                Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                    seccion.Nombre = nombre;

                Console.WriteLine($"Fecha inicio actual: {seccion.FechaInicio.ToShortDateString()}");
                Console.Write("Nueva fecha inicio (yyyy-MM-dd, dejar vacío para no cambiar): ");
                string inicioStr = Console.ReadLine();
                if (DateTime.TryParse(inicioStr, out DateTime inicio))
                    seccion.FechaInicio = inicio;

                Console.WriteLine($"Fecha fin actual: {seccion.FechaFin.ToShortDateString()}");
                Console.Write("Nueva fecha fin (yyyy-MM-dd, dejar vacío para no cambiar): ");
                string finStr = Console.ReadLine();
                if (DateTime.TryParse(finStr, out DateTime fin))
                    seccion.FechaFin = fin;

                Console.WriteLine($"EventoCodigo actual: {seccion.EventoCodigo}");
                Console.Write("Nuevo código evento (dejar vacío para no cambiar): ");
                string eventoCodigoStr = Console.ReadLine();
                if (int.TryParse(eventoCodigoStr, out int eventoCodigo))
                    seccion.EventoCodigo = eventoCodigo;

                Crud<Seccion>.Update(seccion.Codigo, seccion);
                Console.WriteLine("Sección actualizada correctamente.");
            }

            public static void EliminarSeccion()
            {
                Console.WriteLine("Ingrese el código de la sección a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Seccion>.EndPoint = "https://localhost:7019/api/Secciones";
                var seccion = Crud<Seccion>.GetById(codigo);
                if (seccion == null)
                {
                    Console.WriteLine("Sección no encontrada.");
                    return;
                }

                Crud<Seccion>.Delete(codigo);
                Console.WriteLine("Sección eliminada correctamente.");
            }

        public static void CrearPonente()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Ponentes");
                Console.WriteLine("1. Agregar Ponente");
                Console.WriteLine("2. Eliminar Ponente");
                Console.WriteLine("3. Actualizar Ponente");
                Console.WriteLine("4. Listar Ponentes");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarPonentes(); break;
                    case 2: EliminarPonente(); break;
                    case 3: ActualizarPonente(); break;
                    case 4: ListarPonentes(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }



            public static void GestionarPonentes()
        {
                Console.WriteLine("Ingrese el nombre del ponente:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del ponente:");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese la biografía del ponente:");
                string biografia = Console.ReadLine();
                Console.WriteLine("Ingrese el código del evento:");
                int eventoCodigo = int.Parse(Console.ReadLine());

                Crud<Ponente>.EndPoint = "https://localhost:7019/api/Ponentes";
                var ponente = Crud<Ponente>.Create(new Ponente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Biografia = biografia,
                    EventoCodigo = eventoCodigo
                });

                Console.WriteLine($"Ponente creado con éxito: {ponente.Codigo}");
            }

            public static void ListarPonentes()
            {
                Crud<Ponente>.EndPoint = "https://localhost:7019/api/Ponentes";
                var ponentes = Crud<Ponente>.GetAll();
                foreach (var p in ponentes)
                {
                    Console.WriteLine($"Código: {p.Codigo}, Nombre: {p.Nombre} {p.Apellido}, Biografía: {p.Biografia}, EventoCodigo: {p.EventoCodigo}");
                }
            }

            public static void ActualizarPonente()
            {
                Console.WriteLine("Ingrese el código del ponente a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Ponente>.EndPoint = "https://localhost:7019/api/Ponentes";
                var ponente = Crud<Ponente>.GetById(codigo);
                if (ponente == null)
                {
                    Console.WriteLine("Ponente no encontrado.");
                    return;
                }

                Console.WriteLine($"Nombre actual: {ponente.Nombre}");
                Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                    ponente.Nombre = nombre;

                Console.WriteLine($"Apellido actual: {ponente.Apellido}");
                Console.Write("Nuevo apellido (dejar vacío para no cambiar): ");
                string apellido = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(apellido))
                    ponente.Apellido = apellido;

                Console.WriteLine($"Biografía actual: {ponente.Biografia}");
                Console.Write("Nueva biografía (dejar vacío para no cambiar): ");
                string biografia = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(biografia))
                    ponente.Biografia = biografia;

                Console.WriteLine($"EventoCodigo actual: {ponente.EventoCodigo}");
                Console.Write("Nuevo código evento (dejar vacío para no cambiar): ");
                string eventoCodigoStr = Console.ReadLine();
                if (int.TryParse(eventoCodigoStr, out int eventoCodigo))
                    ponente.EventoCodigo = eventoCodigo;

                Crud<Ponente>.Update(ponente.Codigo, ponente);
                Console.WriteLine("Ponente actualizado correctamente.");
            }

            public static void EliminarPonente()
            {
                Console.WriteLine("Ingrese el código del ponente a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Ponente>.EndPoint = "https://localhost:7019/api/Ponentes";
                var ponente = Crud<Ponente>.GetById(codigo);
                if (ponente == null)
                {
                    Console.WriteLine("Ponente no encontrado.");
                    return;
                }

                Crud<Ponente>.Delete(codigo);
                Console.WriteLine("Ponente eliminado correctamente.");
            }

        public static void CrearParticipante()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Participantes");
                Console.WriteLine("1. Agregar Participante");
                Console.WriteLine("2. Eliminar Participante");
                Console.WriteLine("3. Actualizar Participante");
                Console.WriteLine("4. Listar Participantes");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarParticipantes(); break;
                    case 2: EliminarParticipante(); break;
                    case 3: ActualizarParticipante(); break;
                    case 4: ListarParticipantes(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }



            public static void GestionarParticipantes()
            {
                Console.WriteLine("Ingrese el nombre del participante:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido del participante:");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el correo del participante:");
                string correo = Console.ReadLine();
                Console.WriteLine("Ingrese el teléfono del participante:");
                string telefono = Console.ReadLine();

                Crud<Participante>.EndPoint = "https://localhost:7019/api/Participantes";
                var participante = Crud<Participante>.Create(new Participante
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Correo = correo,
                    Telefono = telefono
                });

                Console.WriteLine($"Participante creado con éxito: {participante.Codigo}");
            }

            public static void ListarParticipantes()
            {
                Crud<Participante>.EndPoint = "https://localhost:7019/api/Participantes";
                var participantes = Crud<Participante>.GetAll();
                foreach (var p in participantes)
                {
                    Console.WriteLine($"Código: {p.Codigo}, Nombre: {p.Nombre} {p.Apellido}, Correo: {p.Correo}, Teléfono: {p.Telefono}");
                }
            }

            public static void ActualizarParticipante()
            {
                Console.WriteLine("Ingrese el código del participante a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Participante>.EndPoint = "https://localhost:7019/api/Participantes";
                var participante = Crud<Participante>.GetById(codigo);
                if (participante == null)
                {
                    Console.WriteLine("Participante no encontrado.");
                    return;
                }

                Console.WriteLine($"Nombre actual: {participante.Nombre}");
                Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                    participante.Nombre = nombre;

                Console.WriteLine($"Apellido actual: {participante.Apellido}");
                Console.Write("Nuevo apellido (dejar vacío para no cambiar): ");
                string apellido = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(apellido))
                    participante.Apellido = apellido;

                Console.WriteLine($"Correo actual: {participante.Correo}");
                Console.Write("Nuevo correo (dejar vacío para no cambiar): ");
                string correo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(correo))
                    participante.Correo = correo;

                Console.WriteLine($"Teléfono actual: {participante.Telefono}");
                Console.Write("Nuevo teléfono (dejar vacío para no cambiar): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefono))
                    participante.Telefono = telefono;

                Crud<Participante>.Update(participante.Codigo, participante);
                Console.WriteLine("Participante actualizado correctamente.");
            }

            public static void EliminarParticipante()
            {
                Console.WriteLine("Ingrese el código del participante a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Participante>.EndPoint = "https://localhost:7019/api/Participantes";
                var participante = Crud<Participante>.GetById(codigo);
                if (participante == null)
                {
                    Console.WriteLine("Participante no encontrado.");
                    return;
                }

                Crud<Participante>.Delete(codigo);
                Console.WriteLine("Participante eliminado correctamente.");
            }

            public static void CrearInscripcion()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Inscripciones");
                Console.WriteLine("1. Agregar Inscripción");
                Console.WriteLine("2. Eliminar Inscripción");
                Console.WriteLine("3. Actualizar Inscripción");
                Console.WriteLine("4. Listar Inscripciones");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarInscripciones(); break;
                    case 2: EliminarInscripcion(); break;
                    case 3: ActualizarInscripcion(); break;
                    case 4: ListarInscripciones(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }
            public static void GestionarInscripciones()
        {
                Console.WriteLine("Ingrese el código del evento:");
                int eventoCodigo = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la fecha de inscripción (yyyy-MM-dd):");
                DateTime fechaInscripcion = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el estado de inscripción:");
                string estadoInscripcion = Console.ReadLine();
                Console.WriteLine("Ingrese el código del participante:");
                int participanteCodigo = int.Parse(Console.ReadLine());

                Crud<Inscripcion>.EndPoint = "https://localhost:7019/api/Inscripciones";
                var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
                {
                    EventoCodigo = eventoCodigo,
                    FechaInscripcion = fechaInscripcion,
                    EstadoDeInscripcion = estadoInscripcion,
                    ParticipanteCodigo = participanteCodigo,
                });

                Console.WriteLine($"Inscripción creada con éxito: {inscripcion.Codigo}");
            }

            public static void ListarInscripciones()
            {
                Crud<Inscripcion>.EndPoint = "https://localhost:7019/api/Inscripciones";
                var inscripciones = Crud<Inscripcion>.GetAll();
                foreach (var i in inscripciones)
                {
                    Console.WriteLine($"Código: {i.Codigo}, EventoCodigo: {i.EventoCodigo}, ParticipanteCodigo: {i.ParticipanteCodigo}, Fecha: {i.FechaInscripcion.ToShortDateString()}, Estado: {i.EstadoDeInscripcion}");
                }
            }

            public static void ActualizarInscripcion()
            {
                Console.WriteLine("Ingrese el código de la inscripción a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Inscripcion>.EndPoint = "https://localhost:7019/api/Inscripciones";
                var inscripcion = Crud<Inscripcion>.GetById(codigo);
                if (inscripcion == null)
                {
                    Console.WriteLine("Inscripción no encontrada.");
                    return;
                }

                Console.WriteLine($"Estado actual: {inscripcion.EstadoDeInscripcion}");
                Console.Write("Nuevo estado (dejar vacío para no cambiar): ");
                string estado = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(estado))
                    inscripcion.EstadoDeInscripcion = estado;

                Console.WriteLine($"Fecha inscripción actual: {inscripcion.FechaInscripcion.ToShortDateString()}");
                Console.Write("Nueva fecha (yyyy-MM-dd, dejar vacío para no cambiar): ");
                string fechaStr = Console.ReadLine();
                if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    inscripcion.FechaInscripcion = fecha;

                Crud<Inscripcion>.Update(inscripcion.Codigo, inscripcion);
                Console.WriteLine("Inscripción actualizada correctamente.");
            }

            public static void EliminarInscripcion()
            {
                Console.WriteLine("Ingrese el código de la inscripción a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Inscripcion>.EndPoint = "https://localhost:7019/api/Inscripciones";
                var inscripcion = Crud<Inscripcion>.GetById(codigo);
                if (inscripcion == null)
                {
                    Console.WriteLine("Inscripción no encontrada.");
                    return;
                }

                Crud<Inscripcion>.Delete(codigo);
                Console.WriteLine("Inscripción eliminada correctamente.");
            }

            public static void CrearPago()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Pagos");
                Console.WriteLine("1. Agregar Pago");
                Console.WriteLine("2. Eliminar Pago");
                Console.WriteLine("3. Actualizar Pago");
                Console.WriteLine("4. Listar Pagos");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarPagos(); break;
                    case 2: EliminarPago(); break;
                    case 3: ActualizarPago(); break;
                    case 4: ListarPagos(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }
            public static void GestionarPagos()
            {
                Console.WriteLine("Ingrese el monto del pago:");
                double monto = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el método de pago:");
                string metodo = Console.ReadLine();
                Console.WriteLine("Ingrese la fecha del pago (yyyy-MM-dd):");
                DateTime fecha = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el código de la inscripción:");
                int inscripcionCodigo = int.Parse(Console.ReadLine());

                Crud<Pago>.EndPoint = "https://localhost:7019/api/Pagos";
                var pago = Crud<Pago>.Create(new Pago
                {
                    Monto = monto,
                    MetodoDePago = metodo,
                    FechaPago = fecha,
                    InscripcionCodigo = inscripcionCodigo
                });

                Console.WriteLine($"Pago creado con éxito: {pago.Codigo}");
            }

            public static void ListarPagos()
            {
                Crud<Pago>.EndPoint = "https://localhost:7019/api/Pagos";
                var pagos = Crud<Pago>.GetAll();
                foreach (var p in pagos)
                {
                    Console.WriteLine($"Código: {p.Codigo}, Monto: {p.Monto}, Método: {p.MetodoDePago}, Fecha: {p.FechaPago.ToShortDateString()}, Inscripción: {p.InscripcionCodigo}");
                }
            }

            public static void ActualizarPago()
            {
                Console.WriteLine("Ingrese el código del pago a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Pago>.EndPoint = "https://localhost:7019/api/Pagos";
                var pago = Crud<Pago>.GetById(codigo);
                if (pago == null)
                {
                    Console.WriteLine("Pago no encontrado.");
                    return;
                }

                Console.WriteLine($"Monto actual: {pago.Monto}");
                Console.Write("Nuevo monto (dejar vacío para no cambiar): ");
                string montoStr = Console.ReadLine();
                if (double.TryParse(montoStr, out double monto))
                    pago.Monto = monto;

                Console.WriteLine($"Método actual: {pago.MetodoDePago}");
                Console.Write("Nuevo método (dejar vacío para no cambiar): ");
                string metodo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(metodo))
                    pago.MetodoDePago = metodo;

                Console.WriteLine($"Fecha actual: {pago.FechaPago.ToShortDateString()}");
                Console.Write("Nueva fecha (yyyy-MM-dd, dejar vacío para no cambiar): ");
                string fechaStr = Console.ReadLine();
                if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    pago.FechaPago = fecha;

                Crud<Pago>.Update(pago.Codigo, pago);
                Console.WriteLine("Pago actualizado correctamente.");
            }

            public static void EliminarPago()
            {
                Console.WriteLine("Ingrese el código del pago a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Pago>.EndPoint = "https://localhost:7019/api/Pagos";
                var pago = Crud<Pago>.GetById(codigo);
                if (pago == null)
                {
                    Console.WriteLine("Pago no encontrado.");
                    return;
                }

                Crud<Pago>.Delete(codigo);
                Console.WriteLine("Pago eliminado correctamente.");
            }

           public static void CrearCertificado()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Gestión de Certificados");
                Console.WriteLine("1. Agregar Certificado");
                Console.WriteLine("2. Eliminar Certificado");
                Console.WriteLine("3. Actualizar Certificado");
                Console.WriteLine("4. Listar Certificados");
                Console.WriteLine("5. Volver");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida. Presiona una tecla para continuar.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: GestionarCertificados(); break;
                    case 2: EliminarCertificado(); break;
                    case 3: ActualizarCertificado(); break;
                    case 4: ListarCertificados(); break;
                    case 5: break;
                    default:
                        Console.WriteLine("Opción no válida. Presiona una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }
            public static void GestionarCertificados()
        {
                Console.WriteLine("Ingrese la fecha de emisión (yyyy-MM-dd):");
                DateTime fechaEmision = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el código de la inscripción:");
                int inscripcionCodigo = int.Parse(Console.ReadLine());

                Crud<Certificado>.EndPoint = "https://localhost:7019/api/Certificados";
                var certificado = Crud<Certificado>.Create(new Certificado
                {
                    FechaEmision = fechaEmision,
                    InscripcionCodigo = inscripcionCodigo
                });

                Console.WriteLine("Certificado creado con éxito.");
            }

            public static void ListarCertificados()
            {
                Crud<Certificado>.EndPoint = "https://localhost:7019/api/Certificados";
                var certificados = Crud<Certificado>.GetAll();
                foreach (var c in certificados)
                {
                    Console.WriteLine($"Código: {c.Codigo}, Fecha Emisión: {c.FechaEmision.ToShortDateString()}, Inscripción: {c.InscripcionCodigo}");
                }
            }

            public static void ActualizarCertificado()
            {
                Console.WriteLine("Ingrese el código del certificado a actualizar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Certificado>.EndPoint = "https://localhost:7019/api/Certificados";
                var certificado = Crud<Certificado>.GetById(codigo);
                if (certificado == null)
                {
                    Console.WriteLine("Certificado no encontrado.");
                    return;
                }

                Console.WriteLine($"Fecha emisión actual: {certificado.FechaEmision.ToShortDateString()}");
                Console.Write("Nueva fecha emisión (yyyy-MM-dd, dejar vacío para no cambiar): ");
                string fechaStr = Console.ReadLine();
                if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    certificado.FechaEmision = fecha;

                Crud<Certificado>.Update(certificado.Codigo, certificado);
                Console.WriteLine("Certificado actualizado correctamente.");
            }

            public static void EliminarCertificado()
            {
                Console.WriteLine("Ingrese el código del certificado a eliminar:");
                int codigo = int.Parse(Console.ReadLine());

                Crud<Certificado>.EndPoint = "https://localhost:7019/api/Certificados";
                var certificado = Crud<Certificado>.GetById(codigo);
                if (certificado == null)
                {
                    Console.WriteLine("Certificado no encontrado.");
                    return;
                }

                Crud<Certificado>.Delete(codigo);
                Console.WriteLine("Certificado eliminado correctamente.");
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
