using MusicPlayer.DAL.EF;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private /*static*/ MusicPlayerDbContext context = new MusicPlayerDbContext();
        private GenericRepository<Album> albumRepository;
        private GenericRepository<Artist> artistRepository;
        private GenericRepository<Playlist> playlistRepository;
        private GenericRepository<Track> trackRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Сategory> categoryRepository;

        public IRepository<Album> AlbumRepos
        {
            get
            {
                // repository lazy loading
                if (this.albumRepository == null)
                {
                    this.albumRepository = new GenericRepository<Album>(context);
                }
                return albumRepository;
            }
        }

        public IRepository<Artist> ArtistRepos
        {
            get
            {
                // repository lazy loading
                if (this.artistRepository == null)
                {
                    this.artistRepository = new GenericRepository<Artist>(context);
                }
                return artistRepository;
            }
        }

        public IRepository<Playlist> PlaylistRepos
        {
            get
            {
                // repository lazy loading
                if (this.playlistRepository == null)
                {
                    this.playlistRepository = new GenericRepository<Playlist>(context);
                }
                return playlistRepository;
            }
        }

        public IRepository<Track> TrackRepos
        {
            get
            {
                // repository lazy loading
                if (this.trackRepository == null)
                {
                    this.trackRepository = new GenericRepository<Track>(context);
                }
                return trackRepository;
            }
        }

        public IRepository<User> UserRepos
        {
            get
            {
                // repository lazy loading
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public IRepository<Сategory> СategoryRepos
        {
            get
            {
                // repository lazy loading
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Сategory>(context);
                }
                return categoryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
