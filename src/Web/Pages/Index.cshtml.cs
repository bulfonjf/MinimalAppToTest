using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PetsWeb.Pets;

namespace PetsWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PetsClient petsClient;

        public List<PetDto> Pets {get; set;}

        public IndexModel(ILogger<IndexModel> logger, PetsWeb.Pets.PetsClient petsClient)
        {
            _logger = logger;
            this.petsClient = petsClient;
        }

        public void OnGet()
        {
            Pets = petsClient.GetPets().Result.ToList();
        }
        
        public void AddPet()
        {

        }
    }
}
