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
    public string? Country {get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Type { get; set; }

    public Tournament(int id, string? name, DateOnly startd, DateOnly endd, string? country, string? type)
    {
        Id = id;
        Name = name;
        Country = country;
        StartDate = startd;
        EndDate = endd;
        Type = type;
    }
    public Tournament() { }
    public override string ToString()
    {
        return $"ID: {Id}, Torneo: {Name}, Pais: {Country}, Fecha de Inicio {StartDate.ToShortDateString()}, Fecha de Finalización: {EndDate.ToShortDateString()}";
    }
    public static void AddTournament(Tournament tournament)
    {
        tournaments.Add(tournament);
    }
}
