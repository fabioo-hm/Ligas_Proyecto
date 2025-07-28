using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.Models
{
    public class Menu
    {

        public static void MenuPrin()
        {
            Console.Clear();
            const string mainMenu = """
            +==================================+
            |       ⚽ Menú Principal ⚽       | 
            +==================================+
            | 1. Administración Torneos        |
            | 2. Registrar Equipo(s)           |
            | 3. Registrar Jugador(es)         |
            | 4. Transferencias                |
            | 5. Estadísticas                  |
            | 6. Salir del Programa            |
            +==================================+
            Seleccione una opción: 
            """;
            Console.Write(mainMenu);

        }
        public static void MenuToneo()
        {
            Console.Clear();
            const string torneoMenu = """
            +===========================================+
            | 🏆 Administrador de Torneos de Fútbol 🏆  |
            +========================================== +
            | 1. Crear Torneo                           |
            | 2. Buscar Torneo                          |
            | 3. Eliminar Torneo                        |
            | 4. Actualizar Torneo                      |
            | 5. Regresar al Menú Principal             |
            +===========================================+
            Seleccione una opción: 
            """;
            Console.Write(torneoMenu);
        }
        
         public static void MenuTeam()
        {
            Console.Clear();
            const string teamsMenu = """
            +=====================================+
            |   👥 Administrador de Equipos  👥   |
            +=====================================+
            | 1. Registrar equipo                 |
            | 2. Registrar Cuerpo Técnico         |
            | 3. Registrar Cuerpo Médico          |
            | 4. Inscripción a Torneo             |
            | 5. Notificación de Transferencia    |
            | 6. Salir de Torneo                  |    
            | 7. Regresar al Menú Principal       |    
            +=====================================+
            Seleccione una opción: 
            """;
            Console.Write(teamsMenu);
        }

        public static void MenuPlayer()
        {
            Console.Clear();
            const string playersMenu = """
            +=====================================+
            | 🏃  Administrador de Jugadores  🏃  |
            +=====================================+
            | 1. Registrar Jugador                |
            | 2. Buscar Jugador                   |
            | 3. Editar Jugador                   |
            | 4. Eliminar Jugador                 |
            | 5. Regresar al Menú Principal       |
            +=====================================+
            Seleccione una opción: 
            """;
            Console.Write (playersMenu);
        }

        public static void MenuTransfer()
        {
            Console.Clear();
            const string transferMenu = """
            +=================================================+
            | 💰 Menú de Transferencias (Compra/Préstamo) 💰  |
            +=================================================+
            | 1. Comprar Jugador                              |
            | 2. Prestar Jugador                              |
            | 3. Regresar al Menú Principal                   |
            +=================================================+
            Seleccione una opción:          
            """;
            Console.Write(transferMenu);
        }

        public static void MenuStats()
        {
            Console.Clear();
            const string statsMenu = """
            +=================================================+
            |        📊    Menú de Estadísticas    📊         |
            +=================================================+
            | 1. Jugadores con más asistencias del torneo     |
            | 2. Equipos con más goles en contra del torneo   |
            | 3. Jugadores más caros por equipo               |
            | 4. Jugadores menores al promedio de edad        |
            | 5. Regresar al Menú Principal                   |
            +=================================================+
            Seleccione una opción:          
            """;
            Console.Write(statsMenu);
        }
    }
}