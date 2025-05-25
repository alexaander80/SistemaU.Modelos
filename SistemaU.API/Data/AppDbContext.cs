using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaU.Modelos;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaU.Modelos.Certificado> Certificados { get; set; } = default!;

public DbSet<SistemaU.Modelos.Evento> Eventos { get; set; } = default!;

public DbSet<SistemaU.Modelos.Inscripcion> Inscripciones { get; set; } = default!;

public DbSet<SistemaU.Modelos.Pago> Pagos { get; set; } = default!;

public DbSet<SistemaU.Modelos.Participante> Participantes { get; set; } = default!;

public DbSet<SistemaU.Modelos.Ponente> Ponentes { get; set; } = default!;

public DbSet<SistemaU.Modelos.Seccion> Secciones { get; set; } = default!;
    }
