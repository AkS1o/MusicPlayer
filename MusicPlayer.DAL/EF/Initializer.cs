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

            var track1 = new Track() { Name = "Track", Duration = "3:25"};
            track1.Categories = category;
            ctx.Tracks.Add(track1);
            ctx.SaveChanges();

            var track2 = new Track() { Name = "Track1", Duration = "3:25" };
            track1.Categories = category;
            ctx.Tracks.Add(track2);
            ctx.SaveChanges();

            var track3 = new Track() { Name = "Track2", Duration = "3:25" };
            track1.Categories = category;
            ctx.Tracks.Add(track3);
            ctx.SaveChanges();

        }
    }
}
