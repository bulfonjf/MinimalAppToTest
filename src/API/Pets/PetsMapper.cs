using AutoMapper;

namespace PetsAPI.Pets
{
    public class PetsMapper : Profile
    {
        public PetsMapper()
        {
            CreateMap<NewPetDto, Pet>();
            CreateMap<Pet, NewPetDto>();
        }
    }
}