using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CinemaService.Services
{
    public class MovieService : IMovieService
    {

        private IMovieRepository movieRepository { get; set; }
        private IMapper mapper { get; set; }

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        public IEnumerable<MovieResponse> GetAll()
        {

            var movies = movieRepository.GetAll()
                                        .Where(x => x.Deleted == false);

            return mapper.Map<IEnumerable<MovieResponse>>(movies);
        }

        public IEnumerable<MovieResponse> Filter(MovieFilter movieFilter)
        {
            var movies = movieRepository.GetAll()
                                         .Where(x => x.Deleted == false);

            if (!string.IsNullOrEmpty(movieFilter.Name))
            {
                movies = movies.Where(n => n.Name.Contains(movieFilter.Name));
            }

            if (movieFilter.DurationStart != null || movieFilter.DurationStop != null)
            {
                movies = movies.Where(x => x.Duration >= movieFilter.DurationStart && x.Duration <= movieFilter.DurationStop);
            }

            if (!string.IsNullOrEmpty(movieFilter.Genre))
            {
                movies = movies.Where(x => x.Genre.Contains(movieFilter.Genre));
            }

            if (!string.IsNullOrEmpty(movieFilter.Country))
            {
                movies = movies.Where(x => x.Country.Contains(movieFilter.Country));
            }

            if (movieFilter.StartYear != null && movieFilter.EndYear != null)
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

            var mappedMovies = mapper.Map<IEnumerable<MovieResponse>>(movies);

            return mappedMovies;
        }

        public MovieById GetById(int id)
        {
            var movie = movieRepository.GetById(id);

            MovieById mappedMovie = mapper.Map<MovieById>(movie);

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

            Movie movie = movieRepository.GetById(id);

            if (movie.Projections != null)
            {
                movie.Deleted = true;
            }

            movieRepository.Delete(id);


        }
    }
}