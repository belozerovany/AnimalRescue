﻿using AnimalRescue.BusinessLogic.Extensions;
using AnimalRescue.Contracts.BusinessLogic.Interfaces;
using AnimalRescue.Contracts.BusinessLogic.Models;
using AnimalRescue.Contracts.Common.Query;
using AnimalRescue.DataAccess.Mongodb.Interfaces.Repositories;
using AnimalRescue.DataAccess.Mongodb.Models;
using AnimalRescue.Infrastructure.Validation;

using AutoMapper;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalRescue.BusinessLogic.Services
{
    internal class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository animalRepository;
        private readonly IMapper mapper;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            Require.Objects.NotNull(animalRepository, nameof(animalRepository));
            Require.Objects.NotNull(mapper, nameof(mapper));

            this.animalRepository = animalRepository;
            this.mapper = mapper;
        }

        public async Task<AnimalDto> CreateAsync(AnimalDto animalDto)
        {
            animalDto.Id = string.Empty;

            var animal = mapper.Map<AnimalDto, Animal>(animalDto);
            animal = await animalRepository.CreateAsync(animal);
            animalDto = mapper.Map<Animal, AnimalDto>(animal);

            return animalDto;
        }

        public async Task<BlCollectonResponse<AnimalDto>> GetAsync(ApiQueryRequest queryRequest)
        {
            var dbQuery = queryRequest.ToDbQuery();
            var animals = await animalRepository.GetAsync(dbQuery);
            var animalDtos = mapper.Map<List<Animal>, List<AnimalDto>>(animals);
            var count = await animalRepository.GetCountAsync(dbQuery);

            return new BlCollectonResponse<AnimalDto>
            {
                Collection = animalDtos,
                TotalCount = count
            };
        }

        public async Task<AnimalDto> GetAsync(string id)
        {
            var animal = await animalRepository.GetAsync(id);
            var animalDto = mapper.Map<Animal, AnimalDto>(animal);

            return animalDto;
        }

        public async Task UpdateAsync(AnimalDto animalDto)
        {
            var animal = mapper.Map<AnimalDto, Animal>(animalDto);

            await animalRepository.UpdateAsync(animal);
        }

        public async Task DeleteAsync(string id)
        {
            await animalRepository.DeleteAsync(id);
        }
    }
}
