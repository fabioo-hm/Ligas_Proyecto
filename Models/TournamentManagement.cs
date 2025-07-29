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
                    Tournament newTournament = new Tournament();
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
                    Console.Write("""
                        ------ Tipo de torneo ------
                        | 1. Torneo local          |
                        | 2. Torneo internacional  |
                        ============================
                        Seleccione el tipo de torneo (1 ó 2): 
                        """);
                        string? optionType = Console.ReadLine();
                        if (string.IsNullOrEmpty(optionType))
                            {
                                Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                Console.ReadKey();
                                return;
                            }
                        else
                            {
                                if (optionType == "1")
                                    {
                                        newTournament.Type = "Local";
                                        Console.Clear();
                                    }
                                else if (optionType == "2")
                                    {
                                        newTournament.Type = "Internacional";
                                        Console.Clear();
                                    }
                                else
                                    {
                                        Console.Write("❌ Opción inválida. Digite una opción entre \"1\" y \"2\".");
                                        Console.ReadKey();
                                        return;
                                    }
                            }
                    Console.Write("Ingrese el País del Torneo: ");
                    string? country = Console.ReadLine();
                     if (string.IsNullOrEmpty(country))
                            {
                                Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                Console.ReadKey();
                                return;
                            }
                    Console.Write("Ingrese la Fecha de Inicio (DD/MM/YYYY): ");
                    string? startDateInput = Console.ReadLine();
                    if (!DateOnly.TryParse(startDateInput, out DateOnly startDate))
                    {
                        Console.WriteLine("Fecha de inicio inválida. Debe estar en formato DD-MM-YYYY.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ingrese la Fecha de Finalización (DD/MM/YYYY): ");
                    string? endDateInput = Console.ReadLine();
                    if (!DateOnly.TryParse(endDateInput, out DateOnly endDate))
                    {
                        Console.WriteLine("Fecha de finalización inválida. Debe estar en formato DD-MM-YYYY.");
                        Console.ReadKey();
                        return;
                    }
                    if (endDate < startDate)
                    {
                        Console.WriteLine("La fecha de finalización no puede ser anterior a la fecha de inicio.");
                        Console.ReadKey();
                        return;
                    }

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
                    Console.Clear();
                    Console.WriteLine("------ Editar Torneo ------");

                    Console.WriteLine("Estos son los torneos existentes para editar: ");
                    if (Tournament.tournaments.Count == 0)
                    {
                        Console.WriteLine("⚠ No hay torneos disponibles para editar ⚠.");
                        Console.ReadKey();
                        return;
                    }
                    foreach (Tournament t in Tournament.tournaments)
                    {
                        Console.WriteLine($"{t.ToString()}\n");
                    }
                    Console.ReadKey();
                    Console.Clear();

                    while (true)
                        {
                            Console.Clear();
                            Console.Write("""
                            =========== Opciones de Edición ===============
                            | 1. Editar nombre del torneo                 |
                            | 2. Editar país del torneo                   |
                            | 3. Editar tipo de torneo                    |
                            | 4. Editar fecha de inicio del torneo        |
                            | 5. Editar fecha de finalización del torneo  |
                            | 6. Regresar al menú de torneos              |
                            ===============================================

                            Seleccione la opción que desea editar: 
                            """);
                            string? selectedOption = Console.ReadLine();
                            
                            switch (selectedOption)
                            {
                                case "1":
                                    Console.Clear();
                                    foreach (Tournament t in Tournament.tournaments)
                                    {
                                        Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: \"{t.Name}\".");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int actualizar = int.Parse(Console.ReadLine() ?? "0");

                                    Tournament? foundedTournamentName = Tournament.tournaments.Find(t => t.Id == actualizar);
                                    if (foundedTournamentName != null)
                                        {
                                            Console.WriteLine($"Torneo: {foundedTournamentName.Name}");
                                            Console.Write("Ingrese el nuevo nombre del torneo: ");
                                            string? newName = Console.ReadLine();
                                            if (Tournament.tournaments.Any(t => t.Name == newName))
                                                {
                                                    Console.WriteLine($"⚠ Ese nombre ya está en uso ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else if (string.IsNullOrEmpty(newName))
                                                {
                                                    Console.WriteLine("⚠ El campo no puede estar vacío ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }    
                                            else
                                                {
                                                    foundedTournamentName.Name = newName;
                                                    Console.WriteLine("Nombre actualizado con éxito.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                        }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;

                                case "2":
                                    Console.Clear();
                                    foreach (Tournament t in Tournament.tournaments)
                                {
                                    Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: {t.Name}\nPaís: \"{t.Country}\".");
                                }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdC = int.Parse(Console.ReadLine() ?? "0");

                                    Tournament? foundTournamentCountry = Tournament.tournaments.Find(t => t.Id == buscarIdC);
                                    if (foundTournamentCountry != null)
                                        {
                                            Console.WriteLine($"Torneo: {foundTournamentCountry.Country}");
                                            Console.Write("Ingrese el nuevo país del torneo: ");
                                            string? newCountry = Console.ReadLine();
                                            if (string.IsNullOrEmpty(newCountry))
                                                {
                                                    Console.WriteLine("⚠ El campo no puede estar vacío ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else if (newCountry.Length < 3)
                                                {
                                                    Console.WriteLine("⚠ El país debe contener al menos 3 caracteres ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }    
                                            else
                                                {
                                                    foundTournamentCountry.Country = newCountry;
                                                    Console.WriteLine("País actualizado con éxito.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                        }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;
                                    
                                case "3":
                                    foreach (Tournament t in Tournament.tournaments)
                                        {
                                            Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: {t.Name}\nTipo de torneo: \"{t.Type}\".");
                                        }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdT = int.Parse(Console.ReadLine() ?? "0");

                                    Tournament? foundedTournamentType = Tournament.tournaments.Find(t => t.Id == buscarIdT);
                                    if (foundedTournamentType != null)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Tipo de torneo actual: {foundedTournamentType.Type}");
                                            Console.Write("""
                                            ======= Tipo de torneo =======
                                            | 1. Torneo local            |     
                                            | 2. Torneo internacional    |
                                            ==============================

                                            Seleccione el tipo de torneo (1 ó 2): 
                                            """);
                                            string? newType = Console.ReadLine();
                                            if (string.IsNullOrEmpty(newType))
                                                {
                                                    Console.Write("⚠ No se puede dejar el campo vacío ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else
                                                {
                                                    if (newType == "1")
                                                        {
                                                            foundedTournamentType.Type = "Local";
                                                            Console.Clear();
                                                        }
                                                    else if (newType == "2")
                                                        {
                                                            foundedTournamentType.Type = "Internacional";
                                                            Console.Clear();
                                                        }
                                                    else
                                                        {
                                                            Console.Write("❌ Opción inválida. Digite una opción entre \"1\" y \"2\".");
                                                            Console.ReadKey();
                                                            return;
                                                        }
                                                }
                                            }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;

                                case "4":
                                    foreach (Tournament t in Tournament.tournaments)
                                        {
                                            Console.WriteLine($"Torneos disponibles:\nId: {t.Id}\nNombre: {t.Name}\nFecha de inicio: \"{t.StartDate}\".");
                                        }
                                    Console.ReadKey();
                                    Console.Clear();
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdF = int.Parse(Console.ReadLine() ?? "0");
                                    Tournament? foundedTournamentStartD = Tournament.tournaments.Find(t => t.Id == buscarIdF);
                                    if (foundedTournamentStartD != null)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Torneo: {foundedTournamentStartD.Type}");
                                            string? newStartD = Console.ReadLine();
                                            if (DateOnly.TryParse(newStartD, out DateOnly startdate))
                                                {
                                                    foundedTournamentStartD.StartDate = startdate;
                                                    Console.Clear();
                                                }
                                            else if (string.IsNullOrEmpty(newStartD))
                                                {
                                                    Console.Write("⚠ La fecha no puede estar vacía ⚠.");
                                                    Console.ReadKey();
                                                    return;
                                                }
                                            else
                                                {
                                                    Console.Write("❌ Formato de fecha inválido. Por favor, use el formato DD/MM/YYYY.");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    return;
                                                }
                                        }
                                    else
                                        {
                                            Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;
                                        }
                                    break;

                                case "5":
                                    foreach (Tournament t in Tournament.tournaments)
                                        {
                                            Console.WriteLine($"Torneos disponibles:\nId {t.Id}\nNombre: {t.Name}\nFecha de finalización: \"{t.EndDate}\".");
                                        }
                                    Console.Write("Ingrese el Id del torneo que desea editar: ");
                                    int buscarIdFn = int.Parse(Console.ReadLine() ?? "0");
                                    Tournament? foundedTournamentFn = Tournament.tournaments.Find(t => t.Id == buscarIdFn);
                                    if (foundedTournamentFn != null)
                                    {
                                        string? newEndD = Console.ReadLine();
                                        if (DateOnly.TryParse(newEndD, out DateOnly newEndDate))
                                            {
                                                if (newEndDate <= foundedTournamentFn.StartDate)
                                                    {
                                                        Console.Write("❌ La fecha de finalización no puede ser antes de la fecha de inicio.");
                                                        Console.ReadKey();
                                                        return;
                                                    }
                                                else
                                                    {
                                                        foundedTournamentFn.EndDate = newEndDate;
                                                        Console.Clear();
                                                    }
                                            }
                                        else if (string.IsNullOrEmpty(newEndD))
                                            {
                                                Console.Write("⚠ La fecha no puede estar vacía ⚠.");
                                                Console.ReadKey();
                                                return;
                                            }    
                                        else
                                            {
                                                Console.Write("❌ Formato de fecha inválido. Por favor, use el formato DD/MM/YYYY.");
                                                Console.ReadKey();
                                                Console.Clear();
                                                return;
                                            }
                                    }
                                    else
                                    {
                                        Console.WriteLine("❌ El torneo con ese ID no se ha encontrado.");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case "6":
                                    Console.Clear();
                                    Console.WriteLine("Saliendo al menú principal... ");
                                    Console.ReadKey();
                                    return;
                                default:
                                    Console.WriteLine("❌ Opción inválida. Por favor, elija una opción válida.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        } 
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