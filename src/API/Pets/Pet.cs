using System;

namespace PetsAPI.Pets
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}