using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicManager.API.DTOs;
using MusicManager.API.Interfaces.Services;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Controllers
{


    /// <summary>
    /// Controller class for managing Genres.
    /// </summary>
    [Route("api/genres")]
    [Produces("application/json")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        /// <summary>      
        /// Returns a list of genres.
        /// </summary>
        /// <response code="200">Returns a list of genres.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FetchGenreListAsync()
        {
            var genreList = await _genreService.GetGenreListAsync();
            return Ok(genreList);
        }

        /// <summary>      
        /// Finds an genre by id
        /// </summary>
        /// <response code="200">Returns an genre by id.</response>
        /// <response code="404">Genre not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FetchGenreAsync([FromRoute] int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre == null)
                return NotFound();

            return Ok(genre);
        }

        /// <summary>      
        /// Creates a new genre.
        /// </summary>
        /// <response code="200"> Creates a new genre successfully</response>
        /// <response code="400"> Creates a new genre failed</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateGenreAsync([FromBody] GenreDTO genreDTO)
        {
            if (await _genreService.CreateGenreAsync(_mapper.Map<Genre>(genreDTO)))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Creates many genres.
        /// </summary>
        /// <response code="200"> Creates many genres successfully</response>
        /// <response code="400"> Creates many genres failed</response>
        [HttpPost("add-range")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateManyGenresAsync([FromBody] List<GenreDTO> genreDTOs)
        {
            if (await _genreService.CreateManyGenresAsync(_mapper.Map<List<Genre>>(genreDTOs)))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Updates an genre
        /// </summary>
        /// <response code="200"> Updates an genre successfully</response>
        /// <response code="400"> Updates an genre failed</response>
        /// <response code="404"> Cannot find the genre</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateGenreAsync([FromRoute] int id, GenreDTO genreDTO)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre == null)
                return NotFound();

            if (await _genreService.UpdateGenreAsync(_mapper.Map(genreDTO, genre)))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Deletes an genre
        /// </summary>
        /// <response code="200"> Deletes an genre successfully</response>
        /// <response code="400"> Deletes an genre failed</response>
        /// <response code="404"> Cannot find the genre</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteGenreAsync([FromRoute] int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            if (genre == null)
                return NotFound();

            if (await _genreService.DeleteGenreAsync(genre))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Find a list of genres with specified name
        /// </summary>
        /// <response code="200"> Returns a list of genres with specfied name.</response>
        [HttpGet("find")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindGenreByNameAsync([FromQuery] string name)
        {
            var genres = await _genreService.FindGenreByNameAsync(name);
            return Ok(genres);
        }
    }
}
