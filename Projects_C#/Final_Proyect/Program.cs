using Final_Proyect.Data;
using Final_Proyect.Models;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("\n=== CONTROL DE EQUIPOS ===");
    Console.WriteLine("1. Crear equipo");
    Console.WriteLine("2. Agregar jugador");
    Console.WriteLine("3. Mostrar equipos");
    Console.WriteLine("4. Buscar equipo");
    Console.WriteLine("5. Eliminar equipo");
    Console.WriteLine("6. Eliminar jugador");
    Console.WriteLine("7. Salir");
    Console.WriteLine("==========================");

    int choosenOption = 0;

    try
    {
        Console.Write("Seleccione una opción: ");
        choosenOption = Convert.ToInt32(Console.ReadLine());

        switch (choosenOption)
        {
            case 1:
                {
                    Console.Write("Nombre del equipo: ");
                    var nombreEquipo = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nombreEquipo))
                    {
                        Console.WriteLine("Nombre inválido.");
                        break;
                    }

                    bool existe = context.Equipos.Any(e => e.Nombre == nombreEquipo);
                    if (existe)
                    {
                        Console.WriteLine("El equipo ya existe.");
                        break;
                    }

                    var equipo = new Equipo { Nombre = nombreEquipo };
                    context.Equipos.Add(equipo);
                    context.SaveChanges();

                    Console.WriteLine("Equipo creado correctamente.");
                }
                break;

            case 2:
                {
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

                    if (!int.TryParse(Console.ReadLine(), out equipoId))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    var equipoSeleccionado = context.Equipos.FirstOrDefault(e => e.Id == equipoId);
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

                    var jugador = new Jugador { Nombre = nombreJugador, EquipoId = equipoSeleccionado.Id };
                    context.Jugadores.Add(jugador);
                    context.SaveChanges();

                    Console.WriteLine("Jugador agregado correctamente.");
                }
                break;

            case 3:
                {
                    var listaEquipos = context.Equipos.Include(e => e.Jugadores).ToList();
                    if (listaEquipos.Count == 0)
                    {
                        Console.WriteLine("No hay equipos.");
                        break;
                    }

                    foreach (var eq in listaEquipos)
                    {
                        Console.WriteLine($"\nEquipo: {eq.Nombre}  -  ID: {eq.Id}");
                        Console.WriteLine($"Cantidad de jugadores: {eq.Jugadores.Count}");

                        foreach (var j in eq.Jugadores)
                        {
                            Console.WriteLine($" - {j.Nombre}");
                        }
                    }
                }
                break;

            case 4:
                {
                    Console.Write("Nombre del equipo: ");
                    var buscar = Console.ReadLine();

                    var equipoBuscado = context.Equipos.Include(e => e.Jugadores).FirstOrDefault(e => e.Nombre.Contains(buscar));
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
                }
                break;

            case 5:
                {
                    Console.Write("Escribe el ID del equipo a eliminar: ");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());

                    var equipoEliminar = context.Equipos.FirstOrDefault(e => e.Id == idEliminar);
                    if (equipoEliminar != null)
                    {
                        context.Equipos.Remove(equipoEliminar);
                        context.SaveChanges();
                        Console.WriteLine("Equipo eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un equipo con ese ID.");
                    }
                }
                break;

            case 6:
                {
                    Console.Write("Escribe el ID del jugador a eliminar: ");
                    int idJugadorEliminar = Convert.ToInt32(Console.ReadLine());

                    var jugadorEliminar = context.Jugadores.FirstOrDefault(j => j.Id == idJugadorEliminar);
                    if (jugadorEliminar != null)
                    {
                        context.Jugadores.Remove(jugadorEliminar);
                        context.SaveChanges();
                        Console.WriteLine("Jugador eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un jugador con ese ID.");
                    }
                }
                break;

            case 7:
                running = false;
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocurrió un error: {ex.Message}");
    }

    Console.WriteLine("\nPresione una tecla para continuar...");
    Console.ReadKey();
}

Console.WriteLine("Cerrando el programa...");
