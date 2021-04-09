using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Album> AlbumRepos { get; }
        IRepository<Artist> ArtistRepos { get; }
        IRepository<Playlist> PlaylistRepos { get; }
        IRepository<Track> TrackRepos { get; }
        IRepository<User> UserRepos { get; }
        IRepository<Сategory> СategoryRepos { get; }
        void Save();
    }
}
