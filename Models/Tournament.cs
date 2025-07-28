using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.Models;

public class Tournament
{
    public static List<Tournament> tournaments = new List<Tournament>();

    public int Id { get; set; }
    public string? Name { get; set; }

    public Tournament(int id, string? name)
    {
        Id = id;
        Name = name;
    }
    public Tournament() { }
    public override string ToString()
    {
        return $"ID: {Id}, Torneo: {Name}";
    }
    public static void AddTournament(Tournament tournament)
    {
        tournaments.Add(tournament);
    }
}
