using AutoMapper;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CinemaService.Services
{
    public class MovieService : IMovieService
    {

        public IMovieRepository movieRepository { get; set; }
        public IProjectionRepository projectionRepository { get; set; }
        public  IMapper mapper{ get;  set; }

        public MovieService(IMovieRepository movieRepository,IProjectionRepository projectionRepository,  IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.projectionRepository = projectionRepository;
            this.mapper = mapper;
        }
      
        public IEnumerable<MovieResponse> GetAll()
        {

            var movies = movieRepository.GetAll()
                                        .Where(x => x.Deleted == false);
           
            var mappedMovies = mapper.Map<IEnumerable<MovieResponse>>(movies);
                                        
            return mappedMovies;
        }

        public IEnumerable<MovieDTO> Filter(MovieFilter movieFilter)
        {
            var movies =  movieRepository.GetAll()
                                         .Where(x => x.Deleted == false);

            if (!string.IsNullOrWhiteSpace(movieFilter.Name))
            {
                movies = movies.Where(n => n.Name.Contains(movieFilter.Name));
            }

            if (movieFilter.DurationStart != null & movieFilter.DurationStart != 0 || movieFilter.DurationStop != null & movieFilter.DurationStop != 0)
            {
                movies = movies.Where(x => x.Duration >= movieFilter.DurationStart && x.Duration <= movieFilter.DurationStop);
            }

            if (movieFilter.Genre != null & movieFilter.Genre != "")
            {
                movies = movies.Where(x => x.Genres.Contains(movieFilter.Genre));
            }

            if (movieFilter.Country != null & movieFilter.Country != "")
            {
                movies = movies.Where(x => x.Country.Contains(movieFilter.Country));
            }

            if (movieFilter.StartYear != null & movieFilter.StartYear != 0 && movieFilter.EndYear != null & movieFilter.EndYear != 0)//jel dobro?
            {
                movies = movies.Where(x => x.Year >= movieFilter.StartYear && x.Year <= movieFilter.EndYear);
            }

            if (movieFilter.OrderBy == "Name")
            {
                movies = movies.OrderBy(x => x.Name);
            }

            if (movieFilter.OrderBy == "NameDesc")
            {
                movies = movies.OrderByDescending(x => x.Name);
            }

            if (movieFilter.OrderBy == "Duration")
            {
                movies = movies.OrderBy(x => x.Duration);
            }

            if (movieFilter.OrderBy == "DurationDesc")
            {
                movies = movies.OrderByDescending(x => x.Duration);
            }

            if (movieFilter.OrderBy == "Country")
            {
                movies = movies.OrderBy(x => x.Country);
            }

            if (movieFilter.OrderBy == "CountryDesc")
            {
                movies = movies.OrderByDescending(x => x.Country);
            }

            if (movieFilter.OrderBy == "Year")
            {
                movies = movies.OrderBy(x => x.Year);
            }

            if (movieFilter.OrderBy == "YearDesc")
            {
                movies = movies.OrderByDescending(x => x.Year);
            }

            var mappedMovies = mapper.Map<IEnumerable<MovieDTO>>(movies);

            return mappedMovies;
        }

         public MovieResponse GetById(int id)
         {
            var movie = movieRepository.GetById(id);

            MovieResponse mappedMovie = mapper.Map<MovieResponse>(movie);

            return mappedMovie;

         }

        public void Create(MovieRequest movieRequest)
        {

            Movie movie = mapper.Map<Movie>(movieRequest);
            movieRepository.Create(movie);
        }

        public void Update(int id, MovieRequest movieRequest)
        {
            Movie movie = mapper.Map<Movie>(movieRequest);
            movie.Id = id;

            movieRepository.Update(movie);
        }


        public void Delete(int id)
        {
            var projectionsWithMovie = projectionRepository.GetAll()
                                                           .Where(p => p.Movie.Id == id);

            if(projectionsWithMovie != null)
            {
                foreach (Projection p in projectionsWithMovie)
                {
                    p.Movie.Deleted = true;
                }
                
            }
            movieRepository.Delete(id);


        }
    }
}