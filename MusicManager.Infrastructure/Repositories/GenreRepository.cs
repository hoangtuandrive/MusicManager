﻿using MusicManager.API.Data;
using MusicManager.API.Interfaces.Repositories;
using MusicManager.Domain.Entities;

namespace MusicManager.API.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
