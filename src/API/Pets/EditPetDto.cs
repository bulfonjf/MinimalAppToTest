using System;
using System.ComponentModel.DataAnnotations;

namespace PetsAPI.Pets
{
    public class EditPetDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
