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


            context.ProgrammingLanguages.AddOrUpdate(pl => pl.Name,
                            new ProgrammingLanguage { Name = "C#" },
                            new ProgrammingLanguage { Name = "TypeScript" },
                            new ProgrammingLanguage { Name = "F#" },
                            new ProgrammingLanguage { Name = "Swift" },
                            new ProgrammingLanguage { Name = "Java" });

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
                new FriendPhoneNumber { Number = "+27 123 4567", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(m => m.Title,
            new Meeting
            {
                Title = "Programming in C#",
                DateFrom = new DateTime(2022, 2, 1),
                DateTo = new DateTime(2200, 12, 31),
                Friends = new List<Friend>
                {
                    context.Friends.Single(f => f.FirstName == "Jonathan" && f.LastName == "Ball"),
                    context.Friends.Single(f => f.FirstName == "Steven" && f.LastName == "Quirk"),
                }
            });
        }
    }
}
