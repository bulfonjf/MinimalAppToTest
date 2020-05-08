using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetsAPI.Pets;
using System;
using System.Collections.Generic;

namespace PetsAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ILogger<PetsController> _logger;
        private readonly PetsContext petsContext;
        private readonly IMapper mapper;

        public PetsController(ILogger<PetsController> logger, PetsContext petsContext, IMapper mapper)
        {
            _logger = logger;
            this.petsContext = petsContext;
            this.mapper = mapper;
        }

        ///<summary>
        /// Retrieves all the pets
        ///</summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pet>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return petsContext.Pets;
        }

        /// <summary>
        /// Retrieves a pets by its Id
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pet> GetById(Guid id)
        {
            return petsContext.Pets.Find(id);
        }

        ///<summary>
        /// Creates a pet
        ///</summary>
        /// <response code="201">Success</response>
        /// <response code="400">Bad Request, you are doing something wrong</response>
        [HttpPost]
        [ProducesResponseType(typeof(Pet), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pet> Post(NewPetDto petDto)
        {
            var pet = mapper.Map<Pet>(petDto);
            petsContext.Pets.Add(pet);
            petsContext.SaveChanges();
            return Created($"/pets/{pet.Id}", pet);
        }

        ///<summary>
        /// Updates a pet
        ///</summary>
        /// <response code="204">Success</response>
        /// <response code="400">Bad Request, you are doing something wrong</response>
        [HttpPut]
        [ProducesResponseType(typeof(Pet), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pet> Put(EditPetDto petDto)
        {
            var pet = petsContext.Pets.Find(petDto.Id);

            pet.Name = petDto.Name;
            pet.Age = petDto.Age;

            petsContext.Pets.Update(pet);
            petsContext.SaveChanges();

            return NoContent();
        }
    }
}
