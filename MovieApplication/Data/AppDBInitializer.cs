using MovieApplication.Models;

namespace MovieApplication.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name="Cinema1",
                            Logo="",
                            Description="This is the description of the first cinema"

                        },
                        new Cinema()
                        {
                            Name="Cinema2",
                            Logo="",
                            Description="This is the description of the second cinema"

                        },
                        new Cinema()
                        {
                            Name="Cinema3",
                            Logo="",
                            Description="This is the description of the third cinema"

                        },
                    });
                    context.SaveChanges();


                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                        FullName="Actor1",
                        Bio="This is Actor1 Bio",
                        ProfilePictureURL=""
                        },
                        new Actor()
                        {
                        FullName="Actor2",
                        Bio="This is Actor2 Bio",
                        ProfilePictureURL=""
                        },
                        new Actor()
                        {
                        FullName="Actor3",
                        Bio="This is Actor3 Bio",
                        ProfilePictureURL=""
                        },
                    });
                    context.SaveChanges();

                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                        FullName="Producer1",
                        Bio="This is Producer1 Bio",
                        ProfilePictureURL=""
                        },
                        new Producer()
                        {
                        FullName="Producer2",
                        Bio="This is Producer2 Bio",
                        ProfilePictureURL=""
                        },
                        new Producer()
                        {
                        FullName="Producer3",
                        Bio="This is Producer3 Bio",
                        ProfilePictureURL=""
                        }

                    });
                    context.SaveChanges();

                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name="Kantara",
                            Description="Kantara Movie Desc",
                            Price=234.4,
                            ImageURL="",
                            StartDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(-2),
                            CinemaId=4,
                            ProducerId=4,
                            MovieCategory=Enums.MovieCategory.Devotional
                        },
                        new Movie()
                        {
                            Name="Avatar",
                            Description="Avatar Movie Desc",
                            Price=534.4,
                            ImageURL="",
                            StartDate=DateTime.Now.AddDays(3),
                            EndDate=DateTime.Now.AddDays(45),
                            CinemaId=5,
                            ProducerId=6,
                            MovieCategory=Enums.MovieCategory.Science
                        },
                          new Movie()
                        {
                            Name="Love Today",
                            Description="Love Today Movie Desc",
                            Price=34.4,
                            ImageURL="",
                            StartDate=DateTime.Now.AddDays(13),
                            EndDate=DateTime.Now.AddDays(5),
                            CinemaId=4,
                            ProducerId=6,
                            MovieCategory=Enums.MovieCategory.Comedy
                        }

                    });
                    context.SaveChanges();

                }
                //Actors & Movies
                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=7
                        },
                         new Actor_Movie()
                        {
                            ActorId=4,
                            MovieId=8
                        },
                          new Actor_Movie()
                        {
                            ActorId=6,
                            MovieId=9
                        },


                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
