﻿using AnimalRescue.API.Core.Responses;
using AnimalRescue.Contracts.BusinessLogic.Interfaces;
using AnimalRescue.Contracts.BusinessLogic.Models;
using AnimalRescue.Contracts.Common.Query;
using AnimalRescue.Infrastructure.Validation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AnimalRescue.API.Models.Tags;

namespace AnimalRescue.API.Controllers
{
    public class TagsController : ApiControllerBase
    {
        private readonly ITagService _tagService;

        private readonly ILogger<TagsController> _logger;

        private readonly IMapper _mapper;

        public TagsController(
            ITagService tagService,
            ILogger<TagsController> logger,
            IMapper mapper)
        {
            Require.Objects.NotNull(tagService, nameof(tagService));
            Require.Objects.NotNull(logger, nameof(logger));
            Require.Objects.NotNull(mapper, nameof(mapper));

            _tagService = tagService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TagModel>> GetItemByIdAsync([FromRoute] string id)
        {
            return await GetItemAsync<TagDto, TagModel>(_tagService, id, _mapper);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CollectionSegmentApiResponse<TagModel>>> GetAsync([FromQuery]ApiQueryRequest queryRequest)
        {
            return await GetCollectionAsync<TagDto, TagModel>(_tagService, queryRequest, _mapper);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TagModel>> CreateItemAsync([FromForm] TagCreateModel tagCreateModel)
        {
            var tagModel = _mapper.Map<TagCreateModel, TagModel>(tagCreateModel);
            return await CreatedItemAsync(_tagService, tagModel, _mapper);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task UpdateAsync([FromForm] TagUpdateModel tagUpdateModel)
        {
            var tagModel = _mapper.Map<TagUpdateModel, TagModel>(tagUpdateModel);
            await UpdateDataAsync(_tagService, tagModel, _mapper);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task DeleteAsync([FromRoute] string id)
        {
            await _tagService.DeleteAsync(id);
        }
    }
}