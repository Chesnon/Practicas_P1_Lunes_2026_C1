using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Proyect.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Jugador> Jugadores { get; set; } = new();
    }
}
