﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicManager.API.DTOs;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Controllers
{
    /// <summary>
    /// Controller class for managing Artists.
    /// </summary>
    [Route("api/artists")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        /// <summary>      
        /// Returns a list of artists.
        /// </summary>
        /// <response code="200">Returns a list of artists.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FetchArtistListAsync()
        {
            var artistList = await _artistService.GetArtistListAsync();
            return Ok(artistList);
        }

        /// <summary>      
        /// Finds an artist by id
        /// </summary>
        /// <response code="200">Returns an artist by id.</response>
        /// <response code="404">Artist not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FetchArtistAsync([FromRoute] int id)
        {
            var artist = await _artistService.GetArtistResponseModelByIdAsync(id);

            if (artist == null)
                return NotFound();

            return Ok(artist);
        }

        /// <summary>      
        /// Creates a new artist.
        /// </summary>
        /// <response code="200"> Creates a new artist successfully</response>
        /// <response code="400"> Creates a new artist failed</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateArtistAsync([FromBody] CreateArtistDTO createArtistDTO)
        {
            Artist artist = _mapper.Map<Artist>(createArtistDTO);

            if (await _artistService.CreateArtistAsync(_mapper.Map<Artist>(createArtistDTO)))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Creates many artists.
        /// </summary>
        /// <response code="200"> Creates many artists successfully</response>
        /// <response code="400"> Creates many artists failed</response>
        [HttpPost("add-range")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateManyArtistsAsync([FromBody] List<CreateArtistDTO> createManyArtistsDTO)
        {
            if (await _artistService.CreateManyArtistsAsync(_mapper.Map<List<Artist>>(createManyArtistsDTO)))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Updates an artist
        /// </summary>
        /// <response code="200"> Updates an artist successfully</response>
        /// <response code="400"> Updates an artist failed</response>
        /// <response code="404"> Cannot find the artist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateArtistAsync([FromRoute] int id, [FromBody] UpdateArtistDTO updateArtistDTO)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);

            if (artist == null)
                return NotFound();

            if (await _artistService.UpdateArtistAsync(_mapper.Map(updateArtistDTO, artist)))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Deletes an artist
        /// </summary>
        /// <response code="200"> Deletes an artist successfully</response>
        /// <response code="400"> Deletes an artist failed</response>
        /// <response code="404"> Cannot find the artist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteArtistAsync([FromRoute] int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);

            if (artist == null)
                return NotFound();

            if (await _artistService.DeleteArtistAsync(artist))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Find a list of artists with specified name
        /// </summary>
        /// <response code="200"> Returns a list of artists with specfied name.</response>
        [HttpGet("find")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindArtistByNameAsync([FromQuery] string name)
        {
            var artistList = await _artistService.FindArtistByNameAsync(name);
            return Ok(artistList);
        }
    }
}

