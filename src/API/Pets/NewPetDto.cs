using System.ComponentModel.DataAnnotations;

namespace PetsAPI.Pets
{
    public class NewPetDto
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}