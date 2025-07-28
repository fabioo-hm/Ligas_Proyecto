using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.Models
{
    public class TournamentManagement
    {
        public static void TournamentManage()
        {
            Menu.MenuToneo();
            string? torneoOpcion = Console.ReadLine();
            switch (torneoOpcion)
            {
                case "1":
                    Console.WriteLine("\n----- Añadir Torneo -----");
                    Console.Write("Ingrese el ID del Torneo: ");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        if (t.Id == id)
                        {
                            Console.WriteLine("El ID ingresado ya está registrado. Intente con otro ID.");
                            Console.ReadKey();
                            return;
                        }
                    }
                    Console.Write("Ingrese el Nombre del Torneo: ");
                    string? name = Console.ReadLine();
                    Tournament newTournament = new Tournament(id, name);
                    Tournament.AddTournament(newTournament);
                    Console.WriteLine($"\nTorneo creado: {newTournament.Name} con ID {newTournament.Id}");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("----- Lista de Torneos -----");
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        Console.WriteLine(t.ToString());
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("\n----- Buscar Torneo -----");
                    Console.Write("Ingrese el ID del Torneo a buscar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idBuscado))
                    {
                        Console.WriteLine("ID inválido. Debe ser un número entero.");
                        Console.ReadKey();
                        return;
                    }
                    Tournament? torneo = Tournament.tournaments.FirstOrDefault(t => t.Id == idBuscado);
                    if (torneo is null)
                    {
                        Console.WriteLine("No se encontró ningún torneo con ese ID.");
                    }
                    else
                    {
                        Console.WriteLine("Torneo encontrado:");
                        Console.WriteLine(torneo.ToString());
                    }
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("\n----- Eliminar Torneo -----");
                    Console.Write("Ingrese el Id del torneo que desea eliminar: ");
                    int eliminarId = Convert.ToInt32(Console.ReadLine());
                    Tournament? idEncontrado = Tournament.tournaments.Find(t => t.Id == eliminarId);
                    if (idEncontrado != null)
                    {
                        while (true)
                        {
                            Console.Write("¿Está seguro de eliminarlo? (si/no): ");
                            string? eliminar = Console.ReadLine();
                            if (eliminar?.ToLower() != "si")
                            {
                                break;
                            }
                            else
                            {
                                Tournament.tournaments.Remove(idEncontrado);
                                Console.WriteLine("Torneo eliminado exitosamente.");
                                break;

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un torneo con ese ID.");
                    }
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("\n----- Actualizar Torneo -----");
                    Console.Write("Ingrese el Id del torneo que desea Actualizar: ");
                    int idActualizar = Convert.ToInt32(Console.ReadLine());
                    Tournament? Encontrado = Tournament.tournaments.Find(t => t.Id == idActualizar);
                    if (Encontrado != null)
                    {
                        Console.WriteLine($"Torneo: {Encontrado.Name}");
                        Console.Write("Ingrese el nuevo nombre del torneo: ");
                        string? newNombre = Console.ReadLine();
                        if (Tournament.tournaments.Any(t => t.Name == newNombre))
                        {
                            Console.WriteLine("Ese nombre ya está en uso.");
                        }
                        else
                        {
                            Encontrado.Name = newNombre;
                            Console.WriteLine("Nombre actualizado con éxito.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Id no encontrado");
                    }
                    Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine("Regresando al menú principal...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                    break;
            }
        }
    }
}