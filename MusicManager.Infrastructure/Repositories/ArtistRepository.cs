﻿using MusicManager.Application.Interfaces.Repositories;
using MusicManager.Domain.Entities;
using MusicManager.Infrastructure.Context;

namespace MusicManager.Infrastructure.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
