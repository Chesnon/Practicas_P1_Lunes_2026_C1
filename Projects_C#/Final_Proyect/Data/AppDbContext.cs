using Final_Proyect.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Proyect.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=ALEX\\SQLEXPRESS;Database=EquipsDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
