using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.Models;
    public class TeamManagement
    {
        public static void TeamManage()
        {
            Menu.MenuTeam();
            string? equipoOpcion = Console.ReadLine();
            switch (equipoOpcion)
            {
                case "1":
                    Team newTeam = new Team();
                    Console.WriteLine("\n----- Añadir Equipo -----");
                    Console.Write("Ingrese el ID del Equipo: ");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    foreach (Team t in Team.teams)
                    {
                        if (t.Id == id)
                        {
                            Console.WriteLine("El ID ingresado ya está registrado. Intente con otro ID.");
                            Console.ReadKey();
                            return;
                        }
                    }
                    Console.Write("Ingrese el Nombre del Equipo: ");
                    string? name = Console.ReadLine();
                    Console.Write("Ingrese el País del Equipo: ");
                    string? country = Console.ReadLine();
                    Console.Write("""
                        ------ Tipo de equipo ------
                        | 1. Local                 |
                        | 2. Internacional         |
                        ============================
                        Seleccione el tipo de equipo (1 ó 2): 
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
                            newTeam.Type = "Local";
                            Console.Clear();
                        }
                        else if (optionType == "2")
                        {
                            newTeam.Type = "Internacional";
                            Console.Clear();
                        }
                        else
                        {
                            Console.Write("❌ Opción inválida. Digite una opción entre \"1\" y \"2\".");
                            Console.ReadKey();
                            return;
                        }
                    }
                    
                    Team.AddTeam(newTeam);
                    Console.WriteLine($"\nEquipo creado: {newTeam.Name} con ID {newTeam.Id}");
                    Console.ReadKey();
                    break;

                case "2":
                    break;
                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                default:
                    Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                    break;
    }
        }
    }