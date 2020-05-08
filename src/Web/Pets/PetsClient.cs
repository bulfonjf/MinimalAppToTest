using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetsWeb.Pets
{
    public class PetsClient
    {
        private readonly HttpClient httpClient;

        public PetsClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PetDto>> GetPets()
        {
            try
            {
                var pets = new List<PetDto>();
                HttpResponseMessage result = await httpClient.GetAsync("pets");
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    var deserializeOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    pets = JsonSerializer.Deserialize<List<PetDto>>(response, deserializeOptions);
                }
                return pets;
            }
            catch(Exception ex)
            {
                throw new Exception($"Get Pets fail. Error: {ex.Message}.");
            }
        }
    }
}