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
        }
    }
}
