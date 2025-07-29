using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Origin { get; set; }

        public Person(int id, string? fullName, string? email, string? phoneNumber, string? origin, int age)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Origin = origin;
            Age = age;
        }
        public Person() { }
    }
}