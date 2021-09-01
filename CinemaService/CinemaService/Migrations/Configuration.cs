namespace CinemaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CinemaService.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Validation;

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

            var user1 =  new User
            {
                Email = "milos@gmail.com",
                UserName = "milos1",
                Name = "Milos",
                LastName = "Belic",
                RegistrationDate = DateTime.Now
            };
           manager.Create(user1, "Sifra.123");

            context.SaveChanges();

            var user2 = new User
            {
                Email = "nikola@gmail.com",
                UserName = "nikola23",
                Name = "Nikola",
                LastName = "Nikolic",
                RegistrationDate = DateTime.Now
            };
            manager.Create(user2, "Sifra.1234");

            context.SaveChanges();

            var user3 = new User
            {
                Email = "pera@gmail.com",
                UserName = "perica33",
                Name = "Petar",
                LastName = "Kodic",
                RegistrationDate = DateTime.Now,
                
            };
            manager.Create(user3, "Kodic.1234");

            context.SaveChanges();


           ApplicationUser admin = context.MyUsers.FirstOrDefault(x => x.UserName == "milos1");
           // var admin = context.Users.FirstOrDefault(x => x.UserName == "milos1");

            manager.AddToRole(admin.Id, "Administrator");



            //1
            string[] projectionTypes = new string[3] { "2D", "3D", "4D" };
            for (int i = 0; i < projectionTypes.Length; i++)
            {
                context.ProjectionTypes.AddOrUpdate(
                new ProjectionType()
                {
                    TypeName = projectionTypes[i]
                });
            }

            //context.SaveChanges();


            //2-----NE RADI
            //IEnumerable<ProjectionType> projectionTypes = new string[3] { "2D", "3D", "4D" }
            //.AsEnumerable()
            //.Select(element => new ProjectionType(element))
            //.ToArray();
            //context.ProjectionTypes.AddOrUpdate(projectionTypes);
            //context.SaveChanges();




            string[] theaterNames = new string[3] { "T1", "T2", "T3" };

            for (int i = 0; i < theaterNames.Length; i++)
            {
                context.Theaters.AddOrUpdate(
                   new Theater()
                   {

                       Name = theaterNames[i],
                       Free = true,
                       ProjectionTypes = new HashSet<ProjectionType>()

                   });
            }



            context.SaveChanges();



            context.Theaters.Find(1).ProjectionTypes.Add(context.ProjectionTypes.Find(1));
            context.Theaters.Find(1).ProjectionTypes.Add(context.ProjectionTypes.Find(2));
            context.Theaters.Find(2).ProjectionTypes.Add(context.ProjectionTypes.Find(1));
            context.Theaters.Find(2).ProjectionTypes.Add(context.ProjectionTypes.Find(2));
            context.Theaters.Find(3).ProjectionTypes.Add(context.ProjectionTypes.Find(3));
            context.SaveChanges();


            for (int i = 1; i < 3; i++)
            {
                Theater theater = context.Theaters.Find(i);

                for (int j = 1; j <= 30; j++)
                {
                    context.Seats.AddOrUpdate(
                         new Seat()
                         {
                             Free = true,
                             SerialNumber = j,
                             Theater = theater,


                         }

                  );

                }


            }

            for (int j = 1; j <= 10; j++)
            {
                context.Seats.AddOrUpdate(
                     new Seat()
                     {
                         Free = true,
                         SerialNumber = j,
                         Theater = context.Theaters.Find(3),


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
                    
                     Name = "Borat Subsequent",
                     Director = "Jason Woliner",
                     Duration = 96,
                     Studio = "Four by Two Films",
                     Country = "United States",
                     PicturePath = @"\slika3.jpg",
                     Year = 2020,
                     Description = "Borat returns from Kazakhstan to America and this time he reveals more about the American culture, the COVID-19 pandemic and the political elections.",
                     Actors = new List<string>() {"Sacha Baron Cohen", "Rudy Giuliani", "Maria Bakalova" },
                     Genres = new List<string>() { "Comedy", "Mockumentary" }

                 },
                  new Movie()
                  {
                    
                      Name = "Nomadland",
                      Director = "Chloé Zhao",
                      Duration = 108,
                      Studio = "Searchlight Pictures",
                      Country = "United States",
                      Year = 2020,
                      PicturePath = @"\slika6.jpg",
                      Description = "A woman in her sixties, after losing everything in the Great Recession, embarks on a journey through the American West, living as a van-dwelling modern-day nomad.",
                      Actors = new List<string> { "Frances McDormand", "David Strathairn", "Linda May" },
                      Genres = new List<string> { "Drama", "Western" }
                  },
               new Movie()
               {
                 
                   Name = "Minari",
                   Director = "Lee Isaac Chung",
                   Duration = 115,
                   Studio = "A24",
                   Country = "United States",
                   PicturePath = @"\slika7.jpg",
                   Year = 2020,
                   Description = "A Korean family starts a farm in 1980s Arkansas.",
                   Actors = new List<string> { "Steven Yeun", "Yeri Han", "Alan S. Kim" },
                   Genres = new List<string> { "Drama" }
               },
                new Movie()
                {
                  
                    Name = "Soul",
                    Director = "Pete Docter",
                    Duration = 100,
                    Studio = "Walt Disney Studios",
                    Country = "United States",
                    PicturePath = @"\slika8.jpg",
                    Year = 2020,
                    Description = "After landing the gig of a lifetime, a New York jazz pianist suddenly finds himself trapped in a strange land between Earth and the afterlife.",
                    Actors = new List<string> { "Jamie Foxx", "Tina Fey", "Graham Norton", "Rachel House", "Alice Braga", "Richard Ayoade" },
                    Genres = new List<string> { "Family", "Comedy" }
                },
                 new Movie()
                 {
                   
                     Name = "Another Round - Mads Mikkelsen in Druk",
                     Director ="Thomas Vinterberg",
                     Duration = 117,
                     Studio = "Nordisk Film",
                     Country = "Denmark",
                     PicturePath = @"\slika4.jpg",
                     Year = 2020,
                     Description = "Four high school teachers consume alcohol on a daily basis to see how it affects their social and professional lives.",
                     Actors = new List<string> { "Mads Mikkelsen","Thomas Bo Larsen","Magnus Millang","Lars Ranthe" },
                     Genres = new List<string> { "Drama","Comedy" }
                 },
                 new Movie()
                 {
                     
                     Name = "Onward",
                     Director = "Dan Scanlonr",
                     Duration = 102,
                     Studio = "Four by Two Films",
                     Country = "United States",
                     PicturePath = @"\slika10.jpg",
                     Year = 2020,
                     Description = "Borat returns from Kazakhstan to America and this time he reveals more about the American culture, the COVID-19 pandemic and the political elections.",
                     Actors = new List<string> { "Tom Holland", "Chris Pratt","Julia Louis-Dreyfus","Octavia Spencer" },
                     Genres = new List<string> { "Family", "Adventure" }
                 });



            context.SaveChanges();

            context.Projections.AddOrUpdate(
                new Projection()
                {
                    
                    DateTimeShowing = new DateTime(2021, 09, 01, 12, 00, 00),
                    TicketPrice = 4,
                    Movie = context.Movies.Find(8),
                    ProjectionType = context.ProjectionTypes.Find(1),
                    Theater = context.Theaters.Find(1),
                    Admin = context.MyUsers.Find(admin.Id)
                },
                new Projection()
                {
                    
                    DateTimeShowing = new DateTime(2021, 09, 01, 13, 50, 00),
                    TicketPrice = 7,
                    Movie = context.Movies.Find(10),
                    ProjectionType = context.ProjectionTypes.Find(3),
                    Theater = context.Theaters.Find(3),
                    Admin = context.MyUsers.Find(admin.Id)
                },
                 new Projection()
                 {
                     
                     DateTimeShowing = new DateTime(2021, 09, 01, 16, 00, 00),
                     TicketPrice = 6,
                     Movie = context.Movies.Find(5),
                     ProjectionType = context.ProjectionTypes.Find(1),
                     Theater = context.Theaters.Find(2),
                     Admin = context.MyUsers.Find(admin.Id)
                 },
                  new Projection()
                  {
                      
                      DateTimeShowing = new DateTime(2021, 09, 01, 18, 45, 00),
                      TicketPrice = 6,
                      Movie = context.Movies.Find(1),
                      ProjectionType = context.ProjectionTypes.Find(1),
                      Theater = context.Theaters.Find(2),
                      Admin = context.MyUsers.Find(admin.Id)
                  },
                   new Projection()
                   {
                       
                       DateTimeShowing = new DateTime(2021, 09, 01, 16, 00, 00),
                       TicketPrice = 6,
                       Movie = context.Movies.Find(2),
                       ProjectionType = context.ProjectionTypes.Find(1),
                       Theater = context.Theaters.Find(2),
                       Admin = context.MyUsers.Find(admin.Id)
                   }

               ) ;
            context.SaveChanges();


            context.Tickets.AddOrUpdate(
                     new Ticket()
                     {
                         
                         DatePurchased = DateTime.Now,
                         Purchased = true,
                         Projection = context.Projections.Find(1),
                         Customer = context.MyUsers.Find(user2.Id),
                         Seat = context.Seats.Find(1)
                     },
                     
                      new Ticket()
                      {
                          
                          DatePurchased = DateTime.Now,
                          Purchased = true,
                          Projection = context.Projections.Find(1),
                          Customer = context.MyUsers.Find(user3.Id),
                          Seat = context.Seats.Find(2)
                      },
                      new Ticket()
                      {
                          
                          DatePurchased = DateTime.Now,
                          Purchased = true,
                          Projection = context.Projections.Find(2),
                          Customer = context.MyUsers.Find(user2.Id),
                          Seat = context.Seats.Find(1)
                      },
                      new Ticket()
                      {
                         
                          DatePurchased = DateTime.Now,
                          Purchased = true,
                          Projection = context.Projections.Find(2),
                          Customer = context.MyUsers.Find(user3.Id),
                          Seat = context.Seats.Find(2)
                      },
                      new Ticket()
                      {
                          
                          DatePurchased = DateTime.Now,
                          Purchased = true,
                          Projection = context.Projections.Find(5),
                          Customer = context.MyUsers.Find(user3.Id),
                          Seat = context.Seats.Find(2)
                      });
            context.SaveChanges();
           


        }
    }
    
}
