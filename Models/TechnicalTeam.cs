using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.Models
{
    public class TechnicalTeam : Person 
    {
        public string? Role { get; set; }
        public int ExperienceYears { get; set; }
        public TechnicalTeam(int id, string? fullName, string? email, string? phoneNumber, string? origin, int age, string? role, int experienceYears)
            : base(id, fullName, email, phoneNumber, origin, age)
        {
            Role = role;
            ExperienceYears = experienceYears;
        }

        public TechnicalTeam() { }

        public override string ToString()
        {
            return $"{base.ToString()}, Rol: {Role}, Años de Experiencia: {ExperienceYears}";
        }
    }
}