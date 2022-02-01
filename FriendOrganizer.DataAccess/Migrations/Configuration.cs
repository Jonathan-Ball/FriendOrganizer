namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
              f => f.FirstName,
              new Friend { FirstName = "Jonathan", LastName = "Ball" },
              new Friend { FirstName = "Pagan", LastName = "Ball" },
              new Friend { FirstName = "Steve", LastName = "Quirk" },
              new Friend { FirstName = "Erick", LastName = "Gerber" }
              );
            context.ProgrammingLanguages.AddOrUpdate(
              pl => pl.Name,
              new ProgrammingLanguage { Name = "C#" },
              new ProgrammingLanguage { Name = "TypeScript" },
              new ProgrammingLanguage { Name = "F#" },
              new ProgrammingLanguage { Name = "Swift" },
              new ProgrammingLanguage { Name = "Java" });

            context.SaveChanges();

            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
              new FriendPhoneNumber { Number = "+27 555 5556", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(m => m.Title,
              new Meeting
              {
                  Title = "Learn C#",
                  DateFrom = new DateTime(2022, 4, 10),
                  DateTo = new DateTime(2222, 4, 10),
                  Friends = new List<Friend>
                {
            context.Friends.Single(f => f.FirstName == "Jonathan" && f.LastName == "Ball"),
            context.Friends.Single(f => f.FirstName == "Steve" && f.LastName == "Quirk")
                }
              });
        }
    }
}
