//Descripción: Sistema sencillo para registrar equipos, jugadores y cantidad de integrantes. Permite mostrar y buscar por nombre.
using Microsoft.EntityFrameworkCore;
using Final_Proyect.Models;
using Final_Proyect.Data;

var context = new AppDbContext();
bool salir = false;

while (!salir)
{
    Console.Clear();

    Console.WriteLine("=== CONTROL DE EQUIPOS ===");
    Console.WriteLine("1. Crear equipo");
    Console.WriteLine("2. Agregar jugador");
    Console.WriteLine("3. Mostrar equipos");
    Console.WriteLine("4. Buscar equipo");
    Console.WriteLine("5. Eliminar equipo");
    Console.WriteLine("6. Eliminar jugador");
    Console.WriteLine("7. Salir");
    Console.WriteLine("==========================");
    Console.Write("Seleccione una opción: ");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // Crear equipo
            Console.Write("Nombre del equipo: ");
            var nombreEquipo = Console.ReadLine();

            // Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(nombreEquipo))
            {
                Console.WriteLine("Nombre inválido.");
                break;
            }

            // Verificar si ya existe
            bool existe = context.Equipos.Any(e => e.Nombre == nombreEquipo);

            if (existe)
            {
                Console.WriteLine("El equipo ya existe.");
                break;
            }

            // Crear objeto equipo
            var equipo = new Equipo
            {
                Nombre = nombreEquipo
            };

            // Guardar en la base de datos
            context.Equipos.Add(equipo);
            context.SaveChanges();

            Console.WriteLine("Equipo creado correctamente.");
            break;

        case "2":
            // Agregar jugador

            // Mostrar equipos disponibles
            var equipos = context.Equipos.ToList();

            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos creados.");
                break;
            }

            Console.WriteLine("Equipos disponibles:");

            foreach (var eq in equipos)
            {
                Console.WriteLine($"ID: {eq.Id} - Nombre: {eq.Nombre}");
            }

            Console.Write("Seleccione el ID del equipo: ");
            int equipoId;

            // Validar que sea número
            if (!int.TryParse(Console.ReadLine(), out equipoId))
            {
                Console.WriteLine("ID inválido.");
                break;
            }

            // Buscar el equipo por ID
            var equipoSeleccionado = context.Equipos
                .FirstOrDefault(e => e.Id == equipoId);

            if (equipoSeleccionado == null)
            {
                Console.WriteLine("Equipo no encontrado.");
                break;
            }

            Console.Write("Nombre del jugador: ");
            var nombreJugador = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombreJugador))
            {
                Console.WriteLine("Nombre inválido.");
                break;
            }

            // Crear jugador
            var jugador = new Jugador
            {
                Nombre = nombreJugador,
                EquipoId = equipoSeleccionado.Id
            };

            // Guardar en BD
            context.Jugadores.Add(jugador);
            context.SaveChanges();

            Console.WriteLine("Jugador agregado correctamente.");
            break;

        case "3":
            // Mostrar equipos con jugadores

            var listaEquipos = context.Equipos
                .Include(e => e.Jugadores)
                .ToList();

            if (listaEquipos.Count == 0)
            {
                Console.WriteLine("No hay equipos.");
                break;
            }

            foreach (var eq in listaEquipos)
            {
                Console.WriteLine($"\nEquipo: {eq.Nombre}");
                Console.WriteLine($"Cantidad de jugadores: {eq.Jugadores.Count}");

                foreach (var j in eq.Jugadores)
                {
                    Console.WriteLine($" - {j.Nombre}");
                }
            }

            break;

        case "4":
            // Buscar equipo

            Console.Write("Nombre del equipo: ");
            var buscar = Console.ReadLine();

            var equipoBuscado = context.Equipos
                .Include(e => e.Jugadores)
                .FirstOrDefault(e => e.Nombre.Contains(buscar));

            if (equipoBuscado == null)
            {
                Console.WriteLine("Equipo no encontrado.");
                break;
            }

            Console.WriteLine($"Equipo: {equipoBuscado.Nombre}");
            Console.WriteLine("Jugadores:");

            foreach (var j in equipoBuscado.Jugadores)
            {
                Console.WriteLine($" - {j.Nombre}");
            }

            break;

        case "5":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
}