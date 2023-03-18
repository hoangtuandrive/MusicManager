using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicManager.API.DTOs;
using MusicManager.Application.Interfaces.Services;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Controllers
{
    [Route("api/songs")]
    [Produces("application/json")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly IGenreService _genreService;

        public SongController(ISongService songService, IMapper mapper, IAlbumService albumService, IArtistService artistService, IGenreService genreService)
        {
            _songService = songService;
            _mapper = mapper;
            _albumService = albumService;
            _artistService = artistService;
            _genreService = genreService;
        }

        /// <summary>      
        /// Returns a list of songs.
        /// </summary>
        /// <response code="200">Returns a list of songs.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FetchSongListAsync()
        {
            var songList = await _songService.GetSongListAsync();

            return Ok(songList);
        }

        /// <summary>      
        /// Finds an song by id
        /// </summary>
        /// <response code="200">Returns an song by id.</response>
        /// <response code="404">Song not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FetchSongAsync([FromRoute] int id)
        {
            var song = await _songService.GetSongResponseModelByIdAsync(id);

            if (song == null)
                return NotFound();

            return Ok(song);
        }

        /// <summary>      
        /// Creates a new song.
        /// </summary>
        /// <response code="200"> Creates a new song successfully</response>
        /// <response code="400"> Creates a new song failed</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateSongAsync([FromBody] CreateSongDTO createSongDTO)
        {
            Song song = _mapper.Map<Song>(createSongDTO);


            // Add artists to song
            if (createSongDTO.Artists != null)
            {
                List<Artist> artistList = new List<Artist>();
                foreach (ArtistDTO artistDTO in createSongDTO.Artists)
                {
                    artistList.Add(await _artistService.GetArtistByIdAsync(artistDTO.Id));
                }
                song.Artists = artistList;
            }


            // Add albums to song
            if (createSongDTO.Albums != null)
            {
                List<Album> albumList = new List<Album>();
                foreach (AlbumDTO albumDTO in createSongDTO.Albums)
                {
                    albumList.Add(await _albumService.GetAlbumByIdAsync(albumDTO.Id));
                }
                song.Albums = albumList;
            }


            // Add genres to song
            if (createSongDTO.Genres != null)
            {
                List<Genre> genreList = new List<Genre>();
                foreach (GenreDTO genreDTO in createSongDTO.Genres)
                {
                    genreList.Add(await _genreService.GetGenreByNameAsync(genreDTO.Name));
                }
                song.Genres = genreList;
            }


            // Add song
            if (await _songService.CreateSongAsync(song))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Creates many songs.
        /// </summary>
        /// <response code="200"> Creates many songs successfully</response>
        /// <response code="400"> Creates many songs failed</response>
        [HttpPost("add-range")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateManySongsAsync([FromBody] List<CreateSongDTO> createManySongsDTO)
        {
            List<Song> songList = new List<Song>();
            foreach (CreateSongDTO createSongDTO in createManySongsDTO)
            {
                Song song = _mapper.Map<Song>(createSongDTO);


                // Add artists to song
                if (createSongDTO.Artists != null)
                {
                    List<Artist> artistList = new List<Artist>();
                    foreach (ArtistDTO artistDTO in createSongDTO.Artists)
                    {
                        artistList.Add(await _artistService.GetArtistByIdAsync(artistDTO.Id));
                    }
                    song.Artists = artistList;
                }


                // Add albums to song
                if (createSongDTO.Albums != null)
                {
                    List<Album> albumList = new List<Album>();
                    foreach (AlbumDTO albumDTO in createSongDTO.Albums)
                    {
                        albumList.Add(await _albumService.GetAlbumByIdAsync(albumDTO.Id));
                    }
                    song.Albums = albumList;
                }


                // Add genres to song
                if (createSongDTO.Genres != null)
                {
                    List<Genre> genreList = new List<Genre>();
                    foreach (GenreDTO genreDTO in createSongDTO.Genres)
                    {
                        genreList.Add(await _genreService.GetGenreByNameAsync(genreDTO.Name));
                    }
                    song.Genres = genreList;
                }

                // Add song to songList
                songList.Add(song);
            }

            // Add songList
            if (await _songService.CreateManySongsAsync(songList))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Updates an song
        /// </summary>
        /// <response code="200"> Updates an song successfully</response>
        /// <response code="400"> Updates an song failed</response>
        /// <response code="404"> Cannot find the song</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSongAsync([FromRoute] int id, [FromBody] UpdateSongDTO updateSongDTO)
        {
            var songDb = await _songService.GetSongByIdAsync(id);

            if (songDb == null)
                return NotFound();

            if (await _songService.UpdateSongAsync(_mapper.Map(updateSongDTO, songDb)))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Deletes an song
        /// </summary>
        /// <response code="200"> Deletes an song successfully</response>
        /// <response code="400"> Deletes an song failed</response>
        /// <response code="404"> Cannot find the song</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSongAsync([FromRoute] int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song == null)
                return NotFound();

            if (await _songService.DeleteSongAsync(song))
                return Ok();

            return BadRequest();
        }

        /// <summary>      
        /// Find a list of songs with specified name
        /// </summary>
        /// <response code="200"> Returns a list of songs with specfied name.</response>
        [HttpGet("find")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> FindSongByNameAsync([FromQuery] string name)
        {
            var songList = await _songService.FindSongByNameAsync(name);
            return Ok(songList);
        }

        /// <summary>      
        /// Adds artist to song
        /// </summary>
        /// <response code="200"> Add artist to song successfully</response>
        /// <response code="400"> Add artist to song failed</response>
        /// <response code="404"> Cannot find the artist</response>
        [HttpPatch("add-artist")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddArtistToSongAsync([FromQuery] int songId, [FromQuery] int artistId)
        {
            var artist = await _artistService.GetArtistByIdAsync(artistId);

            if (artist == null)
                return NotFound();

            if (await _songService.AddArtistToSongAsync(songId, artist))
                return Ok();
            return BadRequest();
        }


        /// <summary>      
        /// Removes artist from song
        /// </summary>
        /// <response code="200"> Remove artist from song successfully</response>
        /// <response code="400"> Remove artist from song failed</response>
        /// <response code="404"> Cannot find the artist</response>
        [HttpPatch("remove-artist")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveArtistFromSongAsync([FromQuery] int songId, [FromQuery] int artistId)
        {
            var artist = await _artistService.GetArtistByIdAsync(artistId);

            if (artist == null)
                return NotFound();

            if (await _songService.RemoveArtistFromSongAsync(songId, artist))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Adds genre to song
        /// </summary>
        /// <response code="200"> Add genre to song successfully</response>
        /// <response code="400"> Add genre to song failed</response>
        /// <response code="404"> Cannot find the genre</response>
        [HttpPatch("add-genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddGenreToSongAsync([FromQuery] int songId, [FromQuery] int genreId)
        {
            var genre = await _genreService.GetGenreByIdAsync(genreId);

            if (genre == null)
                return NotFound();

            if (await _songService.AddGenreToSongAsync(songId, genre))
                return Ok();
            return BadRequest();
        }

        /// <summary>      
        /// Removes genre from song
        /// </summary>
        /// <response code="200"> Remove genre from song successfully</response>
        /// <response code="400"> Remove genre from song failed</response>
        /// <response code="404"> Cannot find the genre</response>
        [HttpPatch("remove-genre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RemoveGenreFromSongAsync([FromQuery] int songId, [FromQuery] int genreId)
        {
            var genre = await _genreService.GetGenreByIdAsync(genreId);

            if (genre == null)
                return NotFound();

            if (await _songService.RemoveGenreFromSongAsync(songId, genre))
                return Ok();
            return BadRequest();
        }
    }
}
