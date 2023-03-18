using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicManager.API.DTOs;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Controllers
{
    /// <summary>
    /// Controller class for managing Albums.
    /// </summary>
    [Route("api/albums")]
    [Produces("application/json")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;

        public AlbumController(IAlbumService albumService, IMapper mapper, ISongService songService, IArtistService artistService, IGenreService genreService)
        {
            _albumService = albumService;
            _mapper = mapper;
            _songService = songService;
            _artistService = artistService;
            _genreService = genreService;
        }

        /// <summary>      
        /// Returns a list of albums.
        /// </summary>
        /// <response code="200">Returns a list of albums.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FetchAlbumListAsync()
        {
            var albumList = await _albumService.GetAlbumListAsync();
            return Ok(albumList);
        }

        /// <summary>      
        /// Finds an album by id
        /// </summary>
        /// <response code="200">Returns an album by id.</response>
        /// <response code="404">Album not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FetchAlbumAsync([FromRoute] int id)
        {
            var album = await _albumService.GetAlbumResponseModelByIdAsync(id);

            if (album == null)
                return NotFound();

            return Ok(album);
        }

        /// <summary>      
        /// Creates a new album.
        /// </summary>
        /// <response code="200"> Creates a new album successfully</response>
        /// <response code="400"> Creates a new album failed</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAlbumAsync([FromBody] CreateAlbumDTO createAlbumDTO)
        {
            Album album = _mapper.Map<Album>(createAlbumDTO);

            // Add artists to album
            if (createAlbumDTO.Artists != null)
            {
                List<Artist> artistList = new List<Artist>();
                foreach (ArtistDTO artistDTO in createAlbumDTO.Artists)
                {
                    artistList.Add(await _artistService.GetArtistByIdAsync(artistDTO.Id));
                }
                album.Artists = artistList;
            }

            // Add genres to album
            if (createAlbumDTO.Genres != null)
            {
                List<Genre> genreList = new List<Genre>();
                foreach (GenreDTO genreDTO in createAlbumDTO.Genres)
                {
                    genreList.Add(await _genreService.GetGenreByNameAsync(genreDTO.Name));
                }
                album.Genres = genreList;
            }

            if (await _albumService.CreateAlbumAsync(album))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Creates many albums.
        /// </summary>
        /// <response code="200"> Creates many albums successfully</response>
        /// <response code="400"> Creates many albums failed</response>
        [HttpPost("add-range")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateManyAlbumsAsync([FromBody] List<CreateAlbumDTO> createManyAlbumsDTO)
        {
            if (await _albumService.CreateManyAlbumsAsync(_mapper.Map<List<Album>>(createManyAlbumsDTO)))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Updates an album
        /// </summary>
        /// <response code="200"> Updates an album successfully</response>
        /// <response code="400"> Updates an album failed</response>
        /// <response code="404"> Cannot find the album</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateAlbumAsync([FromRoute] int id, [FromBody] UpdateAlbumDTO updateAlbumDTO)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);

            if (album == null)
                return NotFound();

            if (await _albumService.UpdateAlbumAsync(_mapper.Map(updateAlbumDTO, album)))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Deletes an album
        /// </summary>
        /// <response code="200"> Deletes an album successfully</response>
        /// <response code="400"> Deletes an album failed</response>
        /// <response code="404"> Cannot find the album</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAlbumAsync([FromRoute] int id)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);

            if (album == null)
                return NotFound();

            if (await _albumService.DeleteAlbumAsync(album))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Find a list of albums with specified name
        /// </summary>
        /// <response code="200"> Returns a list of albums with specfied name.</response>
        [HttpGet("find")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindAlbumByNameAsync([FromQuery] string name)
        {
            var albumList = await _albumService.FindAlbumByNameAsync(name);
            return Ok(albumList);
        }

        /// <summary>      
        /// Adds song to album
        /// </summary>
        /// <response code="200"> Add song to album successfully</response>
        /// <response code="400"> Add song to album failed</response>
        /// <response code="404"> Cannot find the song</response>
        [HttpPatch("add-song")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddSongToAlbumAsync([FromQuery] int albumId, [FromQuery] int songId)
        {
            var song = await _songService.GetSongByIdAsync(songId);

            if (song == null)
                return NotFound();

            if (await _albumService.AddSongToAlbumAsync(albumId, song))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Removes song from album
        /// </summary>
        /// <response code="200"> Remove song from album successfully</response>
        /// <response code="400"> Remove song from album failed</response>
        /// <response code="404"> Cannot find the song</response>
        [HttpPatch("remove-song")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveSongFromAlbumAsync([FromQuery] int albumId, [FromQuery] int songId)
        {
            var song = await _songService.GetSongByIdAsync(songId);

            if (song == null)
                return NotFound();

            if (await _albumService.RemoveSongFromAlbumAsync(albumId, song))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Adds artist to album
        /// </summary>
        /// <response code="200"> Add artist to album successfully</response>
        /// <response code="400"> Add artist to album failed</response>
        /// <response code="404"> Cannot find the artist</response>
        [HttpPatch("add-artist")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddArtistToAlbumAsync([FromQuery] int albumId, [FromQuery] int artistId)
        {
            var artist = await _artistService.GetArtistByIdAsync(artistId);

            if (artist == null)
                return NotFound();

            if (await _albumService.AddArtistToAlbumAsync(albumId, artist))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Removes artist from album
        /// </summary>
        /// <response code="200"> Remove artist from album successfully</response>
        /// <response code="400"> Remove artist from album failed</response>
        /// <response code="404"> Cannot find the artist</response>
        [HttpPatch("remove-artist")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveArtistFromAlbumAsync([FromQuery] int albumId, [FromQuery] int artistId)
        {
            var artist = await _artistService.GetArtistByIdAsync(artistId);

            if (artist == null)
                return NotFound();

            if (await _albumService.RemoveArtistFromAlbumAsync(albumId, artist))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Adds genre to album
        /// </summary>
        /// <response code="200"> Add genre to album successfully</response>
        /// <response code="400"> Add genre to album failed</response>
        /// <response code="404"> Cannot find the genre</response>
        [HttpPatch("add-genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddGenreToAlbumAsync([FromQuery] int albumId, [FromQuery] int genreId)
        {
            var genre = await _genreService.GetGenreByIdAsync(genreId);

            if (genre == null)
                return NotFound();

            if (await _albumService.AddGenreToAlbumAsync(albumId, genre))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Removes genre from album
        /// </summary>
        /// <response code="200"> Remove genre from album successfully</response>
        /// <response code="400"> Remove genre from album failed</response>
        /// <response code="404"> Cannot find the genre</response>
        [HttpPatch("remove-genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveGenreFromAlbumAsync([FromQuery] int albumId, [FromQuery] int genreId)
        {
            var genre = await _genreService.GetGenreByIdAsync(genreId);

            if (genre == null)
                return NotFound();

            if (await _albumService.RemoveGenreFromAlbumAsync(albumId, genre))
                return Ok();
            return BadRequest();
        }
    }
}
