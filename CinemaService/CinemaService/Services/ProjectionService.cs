using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Interfaces;
using CinemaService.Interfaces.IProjectionType;
using CinemaService.Interfaces.ITheater;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;


namespace CinemaService.Services
{
   public class ProjectionService : IProjectionService
   {
      private IProjectionRepository repository;
      private IMovieRepository movieRepository;
      private IProjectionTypeRepository projectionTypeRepository;
      private ITheaterRepository theaterRepository;

      private IMapper mapper { get; set; }

      public ProjectionService(IProjectionRepository repository, IMovieRepository movieRepository,
                               IMapper mapper, IProjectionTypeRepository projectionTypeRepository, ITheaterRepository theaterRepository)
      {
         this.repository = repository;
         this.movieRepository = movieRepository;
         this.projectionTypeRepository = projectionTypeRepository;
         this.theaterRepository = theaterRepository;
         this.mapper = mapper;
      }

      public IEnumerable<ProjectionResponse> GetAll()
      {

         var projections = repository.GetAll()
                                     .Where(x => x.Deleted == false);

         return mapper.Map<IEnumerable<ProjectionResponse>>(projections);


      }

      public IEnumerable<ProjectionResponse> GetByDate(DateTime dateTime)
      {
         var projections = repository.GetAll()
                                     .Where(p => p.DateTimeShowing.Date.Equals(dateTime.Date) && p.Deleted == false)
                                     .OrderBy(p => p.Movie.Name)
                                     .OrderBy(p => p.DateTimeShowing);

         return mapper.Map<IEnumerable<ProjectionResponse>>(projections);


      }

      public IEnumerable<ProjectionResponse> Filter(ProjectionFilter projectionFilter)
      {
         var projections = repository.GetAll()
                                     .Where(x => x.Deleted == false); ;

         if (!string.IsNullOrWhiteSpace(projectionFilter.MovieName))
         {
            projections = projections.Where(n => n.Movie.Name.Contains(projectionFilter.MovieName));
         }

         if (projectionFilter.StartDateTime != null || projectionFilter.EndDateTime != null)
         {
            projections = projections.Where(x => x.DateTimeShowing >= projectionFilter.StartDateTime && x.DateTimeShowing <= projectionFilter.EndDateTime);
         }

         if (projectionFilter.StartPrice != null || projectionFilter.EndPrice != null)
         {
            projections = projections.Where(x => x.TicketPrice >= projectionFilter.StartPrice && x.TicketPrice <= projectionFilter.EndPrice);
         }

         if (!string.IsNullOrWhiteSpace(projectionFilter.ProjectionType))
         {
            projections = projections.Where(x => x.ProjectionType.TypeName.Contains(projectionFilter.ProjectionType));
         }

         if (!string.IsNullOrWhiteSpace(projectionFilter.Theatar))
         {
            projections = projections.Where(x => x.Theater.Name.Contains(projectionFilter.Theatar));
         }

         if (projectionFilter.OrderBy == "MovieName")
         {
            projections = projections.OrderBy(x => x.Movie.Name);
         }

         if (projectionFilter.OrderBy == "MovieNameDesc")
         {
            projections = projections.OrderByDescending(x => x.Movie.Name);
         }

         if (projectionFilter.OrderBy == "DateTimeShowing")
         {
            projections = projections.OrderBy(x => x.DateTimeShowing);
         }

         if (projectionFilter.OrderBy == "DateTimeShowingDesc")
         {
            projections = projections.OrderByDescending(x => x.DateTimeShowing);
         }

         if (projectionFilter.OrderBy == "ProjectionTypeName")
         {
            projections = projections.OrderBy(x => x.ProjectionType.TypeName);
         }

         if (projectionFilter.OrderBy == "ProjectionTypeNameDesc")
         {
            projections = projections.OrderByDescending(x => x.ProjectionType.TypeName);
         }

         if (projectionFilter.OrderBy == "TheaterName")
         {
            projections = projections.OrderBy(x => x.Theater.Name);
         }

         if (projectionFilter.OrderBy == "TheaterNameDesc")
         {
            projections = projections.OrderByDescending(x => x.Theater.Name);
         }

         return mapper.Map<IEnumerable<ProjectionResponse>>(projections);


      }

      public IEnumerable<ProjectionResponse> GetByMovieId(int movieId, string sortType)
      {
         var projections = repository.GetAll().Where(x => x.Movie.Id == movieId && x.DateTimeShowing > DateTime.Now && x.SoldOut == false);

         if (sortType.Contains("DateTimeShowing"))
         {
            projections = projections.OrderBy(x => x.DateTimeShowing);
         }

         if (sortType.Contains("DateTimeShowingDesc"))
         {
            projections = projections.OrderByDescending(x => x.DateTimeShowing);
         }


         return mapper.Map<IEnumerable<ProjectionResponse>>(projections);

      }

      public ProjectionById GetById(int id)
      {
         var projection = repository.GetById(id);

         int? freeSeats = projection.Theater.Seats.Where(x => x.Free == true).Count();

         ProjectionById projectionById = mapper.Map<ProjectionById>(projection);

         projectionById.FreeSeats = freeSeats;

         return projectionById;


      }

      private DateTime? MakeEndOfProjection(Projection projection)
      {
         if (projection != null)
         {
            DateTime krajProjekcije = projection.DateTimeShowing.AddMinutes(projection.Movie.Duration).AddMinutes(15.0);
            return krajProjekcije;
         }
         return null;
      }

      public void Create(ProjectionRequest projectionRequest)
      {

         Projection projection = new Projection();
         projection.Movie = movieRepository.GetById(projectionRequest.MovieId);
         projection.ProjectionType = projectionTypeRepository.GetById(projectionRequest.ProjectionTypeId);
         projection.Theater = theaterRepository.GetById(projectionRequest.TheaterId);
         projection.DateTimeShowing = projectionRequest.DateTimeShowing;
         projection.TicketPrice = projectionRequest.TicketPrice;
         projection.EndOfProjection = MakeEndOfProjection(projection);



         if (projection.Theater.ProjectionTypes.Contains(projection.ProjectionType))
         {
            throw new Exception("This theater doesn't support the selected projection type, choose another!!");
         }


         var projections = repository.GetAll()
                                             .Where(x => x.Theater.Id == projection.Theater.Id)
                                             .Where(p => p.DateTimeShowing.Year.Equals(projection.DateTimeShowing.Year)
                                         && p.DateTimeShowing.Month.Equals(projection.DateTimeShowing.Month)
                                         && p.DateTimeShowing.Day.Equals(projection.DateTimeShowing.Day)
                                         && p.Deleted == false)
                                             .OrderByDescending(x => x.DateTimeShowing);
         int numbOfProj = projections.Count();

         if (numbOfProj == 0)
         {
            repository.Create(projection);
            
         }


         if (int.Parse(ConfigurationManager.AppSettings.Get("maxProjByDay")) < numbOfProj + 1)
         {
            throw new Exception("One theater can only have 6 projections per day, put another date!");
         }


         var projectionBefore = projections.Where(x => x.DateTimeShowing < projection.DateTimeShowing)
                                                      .FirstOrDefault();

         var projectionAfter = projections.Where(x => x.DateTimeShowing > projection.DateTimeShowing)
                                                       .LastOrDefault();
        

         if (projectionBefore != null)
         {
            projectionBefore.EndOfProjection = MakeEndOfProjection(projectionBefore);

            if (projection.DateTimeShowing >= projectionBefore.EndOfProjection && (projectionAfter == null || projection.EndOfProjection <= projectionAfter.DateTimeShowing))
            {
               repository.Create(projection);
            }

            throw new Exception("The entered projection time is incorrect, check the list of projections and see what time will be correct");


         }



      }

      public void Delete(int id)
      {
         Projection projection = repository.GetById(id);

         if (projection.Tickets != null)
         {
            projection.Deleted = true;
         }

         repository.Delete(id);
      }


   }
}