using FriendOrganizer.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FriendOrganizer.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(f => f.FirstName,
                new Friend { FirstName = "Jonathan", LastName = "Ball" },
                new Friend { FirstName = "Pagan", LastName = "Ball" },
                new Friend { FirstName = "Kyle", LastName = "Dudeson" },
                new Friend { FirstName = "Steven", LastName = "Quirk" });
        }
    }
}
