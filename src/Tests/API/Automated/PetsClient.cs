using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomatedAPITests
{
    public class PetsClient
    {
        private readonly HttpClient httpClient;

        public PetsClient()
        {
            var uriBuilder = new UriBuilder("localhost");
            uriBuilder.Scheme = "https";
            uriBuilder.Port = 44323;

            this.httpClient = new HttpClient()
            {
                BaseAddress = uriBuilder.Uri
            };
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