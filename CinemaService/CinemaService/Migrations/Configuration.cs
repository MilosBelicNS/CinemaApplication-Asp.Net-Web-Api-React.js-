namespace CinemaService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CinemaService.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    internal sealed class Configuration : DbMigrationsConfiguration<CinemaService.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaService.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("Administrator"));

            context.SaveChanges();


            var user1 = new User { Email = "milos@gmail.com",
                                   UserName = "milos1", 
                                   Name = "Milos", 
                                   LastName = "Belic", 
                                   RegistrationDate = DateTime.Now };
            manager.Create(user1, "Sifra.123");

            context.SaveChanges();

            var user2 = new User { Email = "nikola@gmail.com", 
                                   UserName = "nikola23", 
                                   Name = "Nikola", 
                                   LastName = "Nikolic", 
                                   RegistrationDate = DateTime.Now, 
                                   PurchasedTickets = null };
            manager.Create(user2, "Sifra.1234");

            context.SaveChanges();


            var admin = context.Users.FirstOrDefault(x => x.Email == "milos@gmail.com");

            manager.AddToRole(admin.Id, "Administrator");

            
            
            



            context.ProjectionTypes.AddOrUpdate(
               new ProjectionType()
               {

                   TypeName = "2D"
               },
                new ProjectionType()
                {

                    TypeName = "3D"
                },
                 new ProjectionType()
                 {

                     TypeName = "4D"
                 }

              ) ;
            context.SaveChanges();
           



            context.Theaters.AddOrUpdate(
               new Theater()
               {

                   Name = "T1",
                   Free = true,
                   ProjectionTypes = null,
                   Seats = new List<Seat>()

               },
                new Theater()
                {
                    Name = "T2",
                    Free = true,
                    ProjectionTypes = null,
                    Seats = new List<Seat>()
                },
                 new Theater()
                 {
                     Name = "T3",
                     Free = true,
                     ProjectionTypes = null,
                     Seats = new List<Seat>()
                 }

              )  ;
            context.SaveChanges();

            for (int i = 1; i <= 30; i++)
            {

                context.Seats.AddOrUpdate(
                     new Seat()
                     {
                        
                         Free = true,
                         TheaterId = 1,
                         /*PurchasedTickets = null*/
                     },
                      new Seat()
                      {

                          Free = true,
                          TheaterId = 2,
                          /*PurchasedTickets = null*/
                      },
                       new Seat()
                       {

                           Free = true,
                           TheaterId = 3,
                           /*PurchasedTickets = null*/
                       }




              );
            }
            context.SaveChanges();




            context.Movies.AddOrUpdate(
               new Movie()
               {
                   Name = "Da 5 Bloods",
                   Director = "Spike Lee",
                   Duration = 154,
                   Studio = "Netflix",
                   Country = "United States",
                   Year = 2020,
                   PicturePath = @"\slika1.jpg",
                   Description = "Four African-American vets battle the forces of man and nature when they return to Vietnam seeking the remains of their fallen squad leader and the gold fortune he helped them hide.",
                   Actors = new List<string> { "Delroy Lindo", "Jonathan Majors", "Clarke Peters" },
                   Genres = new List<string> { "War", "Drama" }
               },
               new Movie()
               {
                   Id = 2,
                   Name = "Tenet",
                   Director = "Christopher Nolan",
                   Duration = 150,
                   Studio = "Warner Bros. Pictures",
                   Country = "United Kingdom",
                   PicturePath = @"\slika2.jpg",
                   Year = 2020,
                   Description = "Armed with only one word, Tenet, and fighting for the survival of the entire world, a Protagonist journeys through a twilight world of international espionage on a mission that will unfold in something beyond real time..",
                   Actors = new List<string> { "John David Washington", "Robert Pattinson", "Elizabeth Debicki", "Dimple Kapadia" },
                   Genres = new List<string> { "Action", "Thriller" }
               },
                new Movie()
                {
                    Id = 1,
                    Name = "Mank",
                    Director = " David Fincher",
                    Duration = 131,
                    Studio = "Netflix",
                    Country = "United States",
                    PicturePath = @"\slika5.jpg",
                    Year = 2020,
                    Description = "1930's Hollywood is reevaluated through the eyes of scathing social critic and alcoholic screenwriter Herman J. Mankiewicz as he races to finish the screenplay of Citizen Kane (1941)",
                    Actors = new List<string> { "Gary Oldman", "Amanda Seyfried", "Lily Collins", "Arliss Howard" },
                    Genres = new List<string> { "Drama", "Comedy" }
                },
                 new Movie()
                 {
                     Id = 3,
                     Name = "I'm Thinking of Ending Things",
                     Director = "Charlie Kaufman",
                     Duration = 134,
                     Studio = "Netflix",
                     Country = "United States",
                     PicturePath = @"\slika4.jpg",
                     Year = 2020,
                     Description = "Full of misgivings, a young woman travels with her new boyfriend to his parents' secluded farm. Upon arriving, she comes to question everything she thought she knew about him, and herself.",
                     Actors = new List<string> { "Jesse Plemons", "Jessie Buckley", "Toni Collette", "David Thewlis" },
                     Genres = new List<string> { "Horror" }
                 },
                 new Movie()
                 {
                     Id = 4,
                     Name = "Borat Subsequent",
                     Director = "Jason Woliner",
                     Duration = 96,
                     Studio = "Four by Two Films",
                     Country = "United States",
                     PicturePath = @"\slika3.jpg",
                     Year = 2020,
                     Description = "Borat returns from Kazakhstan to America and this time he reveals more about the American culture, the COVID-19 pandemic and the political elections.",
                     Actors = new List<string> { "Sacha Baron Cohen", "Rudy Giuliani", "Maria Bakalova" },
                     Genres = new List<string> { "Comedy", "Mockumentary" }
                 }); ;


            context.SaveChanges();

            context.Projections.AddOrUpdate(
                new Projection()
                {
                    Id = 1,
                    DateTimeShowing = new DateTime(2021, 10, 01, 16, 00, 00),
                    TicketPrice = 4,
                    MovieId = 1,
                    ProjectionTypeId = 1,
                    TheaterId = 1,
                    UserId = admin.Id
                },
                new Projection()
                {
                    Id = 4,
                    DateTimeShowing = new DateTime(2021, 10, 01, 18, 45, 00),
                    TicketPrice = 5,
                    MovieId = 2,
                    ProjectionTypeId = 2,
                    TheaterId = 1,
                    UserId = admin.Id
                }

               );
            context.SaveChanges();

            context.Tickets.AddOrUpdate(
                new Ticket()
                {
                    Id = 1,
                    DatePurchased = DateTime.Now,
                    Purchased = true,
                    ProjectionId = 1,
                    UserId = context.Users.FirstOrDefault(x => x.UserName == "nikola23").Id,
                    SeatId = context.Seats.FirstOrDefault().Id

                }
               );
            context.SaveChanges();
        }
    }
}
