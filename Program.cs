using Liga.Models;
internal class Program
{
    private static void Main(string[] args)
    {
        bool continuee = true;
        while (continuee)
        {
            Menu.MenuPrin();
            string? opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    TournamentManagement.TournamentManage();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    continuee = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                    break;
            }
        }
    }
}