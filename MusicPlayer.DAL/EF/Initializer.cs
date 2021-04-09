using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.EF
{
    internal class Initializer : CreateDatabaseIfNotExists<MusicPlayerDbContext>
    {
        protected override void Seed(MusicPlayerDbContext ctx)
        {
            base.Seed(ctx);

            var category = new Сategory() { Name = "No category" };
            ctx.Сategories.Add(category);
            ctx.SaveChanges();

            var artist = new Artist() { Name = "No artist" };
            ctx.Artists.Add(artist);
            ctx.SaveChanges();

            var album = new Album() { Name = "No album" };
            ctx.Albums.Add(album);
            ctx.SaveChanges();

            //User user = ctx.Users.Add(new User() { Id = 1, Name = "usasder", Password = "!Q2w3csdcdase4r5t", Email = "usasder@gmail.com", WayToSongs = @"C:\Users" });
            //ctx.SaveChanges();

            //Сategory сategory1 = ctx.Сategories.Add(new Сategory() { Id = 1, Name = "Hip-hop" });
            //Сategory сategory2 = ctx.Сategories.Add(new Сategory() { Id = 2, Name = "Reggae" });
            //Сategory сategory3 = ctx.Сategories.Add(new Сategory() { Id = 3, Name = "Pop" });
            //Сategory сategory4 = ctx.Сategories.Add(new Сategory() { Id = 4, Name = "Rock" });
            //Сategory сategory5 = ctx.Сategories.Add(new Сategory() { Id = 5, Name = "Electronic" });
            //ctx.SaveChanges();

            //Artist artist1 = ctx.Artists.Add(new Artist() { Id = 1, Name = "Benji", Suname = "Andreassen", Country = "United Kingdom" });
            //Artist artist2 = ctx.Artists.Add(new Artist() { Id = 2, Name = "Jo - anne", Suname = "Brumbie", Country = "Ukraine" });
            //Artist artist3 = ctx.Artists.Add(new Artist() { Id = 3, Name = "Vladamir", Suname = "Fawltey", Country = "Brazil" });
            //Artist artist4 = ctx.Artists.Add(new Artist() { Id = 4, Name = "Nedi", Suname = "Carnall", Country = "Tanzania" });
            //Artist artist5 = ctx.Artists.Add(new Artist() { Id = 5, Name = "Thedric", Suname = "Childes", Country = "Russia" });
            //Artist artist6 = ctx.Artists.Add(new Artist() { Id = 6, Name = "Mirabelle", Suname = "Mowsdale", Country = "Central African Republic" });
            //Artist artist7 = ctx.Artists.Add(new Artist() { Id = 7, Name = "Claude", Suname = "De Benedetti", Country = "Sweden" });
            //Artist artist8 = ctx.Artists.Add(new Artist() { Id = 8, Name = "Krispin", Suname = "Proswell", Country = "Indonesia" });
            //Artist artist9 = ctx.Artists.Add(new Artist() { Id = 9, Name = "Tarra", Suname = "Roxbee", Country = "Brazil" });
            //Artist artist10 = ctx.Artists.Add(new Artist() { Id = 10, Name = " Raychel", Suname = "Antonoyev", Country = "China" });
            //ctx.SaveChanges();

            //Album album1 = ctx.Albums.Add(new Album() { Id = 1, Name = "Stim", ArtistId = artist1.Id });
            //Album album2 = ctx.Albums.Add(new Album() { Id = 2, Name = "Pannier", ArtistId = artist2.Id });
            //Album album3 = ctx.Albums.Add(new Album() { Id = 3, Name = "Hatity", ArtistId = artist3.Id });
            //Album album4 = ctx.Albums.Add(new Album() { Id = 4, Name = "Zathin", ArtistId = artist4.Id });
            //Album album5 = ctx.Albums.Add(new Album() { Id = 5, Name = "Andalax", ArtistId = artist5.Id });
            //Album album6 = ctx.Albums.Add(new Album() { Id = 6, Name = "Sonair", ArtistId = artist6.Id });
            //Album album7 = ctx.Albums.Add(new Album() { Id = 7, Name = "Ronstring", ArtistId = artist7.Id });
            //Album album8 = ctx.Albums.Add(new Album() { Id = 8, Name = "Zontrax", ArtistId = artist8.Id });
            //Album album9 = ctx.Albums.Add(new Album() { Id = 9, Name = "Flowdesk", ArtistId = artist9.Id });
            //Album album10 = ctx.Albums.Add(new Album() { Id = 10, Name = "Bamity", ArtistId = artist10.Id });
            //ctx.SaveChanges();

            //Track track1 = ctx.Tracks.Add(new Track() { Id = 1, Name = "Nienow", Duration = "2:41", NumberOfAuditions = 652, AlbumId = album1.Id, ArtistId = artist1.Id, CategoryId = сategory1.Id });
            //Track track2 = ctx.Tracks.Add(new Track() { Id = 2, Name = "Alphazap", Duration = "2:43", NumberOfAuditions = 630, AlbumId = album2.Id, ArtistId = artist2.Id, CategoryId = сategory2.Id });
            //Track track3 = ctx.Tracks.Add(new Track() { Id = 3, Name = "Treeflex", Duration = "3:59", NumberOfAuditions = 910, AlbumId = album3.Id, ArtistId = artist3.Id, CategoryId = сategory3.Id });
            //Track track4 = ctx.Tracks.Add(new Track() { Id = 4, Name = "Namfix", Duration = "3:27", NumberOfAuditions = 578, AlbumId = album4.Id, ArtistId = artist4.Id, CategoryId = сategory4.Id });
            //Track track5 = ctx.Tracks.Add(new Track() { Id = 5, Name = "Holdlamis", Duration = "3:53", NumberOfAuditions = 616, AlbumId = album5.Id, ArtistId = artist5.Id, CategoryId = сategory5.Id });
            //Track track6 = ctx.Tracks.Add(new Track() { Id = 6, Name = "Gembucket", Duration = "2:11", NumberOfAuditions = 510, AlbumId = album6.Id, ArtistId = artist6.Id, CategoryId = сategory1.Id });
            //Track track7 = ctx.Tracks.Add(new Track() { Id = 7, Name = "Fintone", Duration = "3:23", NumberOfAuditions = 511, AlbumId = album7.Id, ArtistId = artist7.Id, CategoryId = сategory2.Id });
            //Track track8 = ctx.Tracks.Add(new Track() { Id = 8, Name = "Transcof", Duration = "3:14", NumberOfAuditions = 599, AlbumId = album8.Id, ArtistId = artist8.Id, CategoryId = сategory3.Id });
            //Track track9 = ctx.Tracks.Add(new Track() { Id = 9, Name = "Ronstring", Duration = "3:04", NumberOfAuditions = 534, AlbumId = album9.Id, ArtistId = artist9.Id, CategoryId = сategory4.Id });
            //Track track10 = ctx.Tracks.Add(new Track() { Id = 10, Name = "Duobam", Duration = "2:52", NumberOfAuditions = 756, AlbumId = album10.Id, ArtistId = artist10.Id, CategoryId = сategory5.Id });
            //Track track11 = ctx.Tracks.Add(new Track() { Id = 11, Name = "Mat Lam Tam", Duration = "2:54", NumberOfAuditions = 674, AlbumId = album1.Id, ArtistId = artist1.Id, CategoryId = сategory1.Id });
            //Track track12 = ctx.Tracks.Add(new Track() { Id = 12, Name = "Temp", Duration = "2:05", NumberOfAuditions = 907, AlbumId = album2.Id, ArtistId = artist2.Id, CategoryId = сategory2.Id });
            //Track track13 = ctx.Tracks.Add(new Track() { Id = 13, Name = "Greenlam", Duration = "3:08", NumberOfAuditions = 829, AlbumId = album3.Id, ArtistId = artist3.Id, CategoryId = сategory3.Id });
            //Track track14 = ctx.Tracks.Add(new Track() { Id = 14, Name = "Tin", Duration = "3:47", NumberOfAuditions = 730, AlbumId = album4.Id, ArtistId = artist4.Id, CategoryId = сategory4.Id });
            //Track track15 = ctx.Tracks.Add(new Track() { Id = 15, Name = "Andalax", Duration = "2:39", NumberOfAuditions = 621, AlbumId = album5.Id, ArtistId = artist5.Id, CategoryId = сategory5.Id });
            //Track track16 = ctx.Tracks.Add(new Track() { Id = 16, Name = "Veribet", Duration = "2:17", NumberOfAuditions = 840, AlbumId = album6.Id, ArtistId = artist6.Id, CategoryId = сategory1.Id });
            //Track track17 = ctx.Tracks.Add(new Track() { Id = 17, Name = "Home Ing", Duration = "2:53", NumberOfAuditions = 849, AlbumId = album7.Id, ArtistId = artist7.Id, CategoryId = сategory2.Id });
            //Track track18 = ctx.Tracks.Add(new Track() { Id = 18, Name = "Prodder", Duration = "2:17", NumberOfAuditions = 789, AlbumId = album8.Id, ArtistId = artist8.Id, CategoryId = сategory3.Id });
            //Track track19 = ctx.Tracks.Add(new Track() { Id = 19, Name = "Zathin", Duration = "3:32", NumberOfAuditions = 839, AlbumId = album9.Id, ArtistId = artist9.Id, CategoryId = сategory4.Id });
            //Track track20 = ctx.Tracks.Add(new Track() { Id = 20, Name = "Cookley", Duration = "2:50", NumberOfAuditions = 839, AlbumId = album10.Id, ArtistId = artist10.Id, CategoryId = сategory5.Id });
            //ctx.SaveChanges();

            //Playlist playlist1 = ctx.Playlists.Add(new Playlist() { Id = 1, Name = "playlist1", UserId = user.Id });
            //ctx.SaveChanges();

        }
    }
}
