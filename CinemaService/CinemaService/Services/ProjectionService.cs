using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;
using CinemaService.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaService.Services
{
    public class ProjectionService : IProjectionService
    {
        public IProjectionRepository repository { get; set; }
        public IMapper mapper { get; set; }

        public ProjectionService(IProjectionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<ProjectionResponse> GetAll()
        {

            var projections = repository.GetAll();

            var mappedProjections = mapper.Map<IEnumerable<ProjectionResponse>>(projections);

            return mappedProjections;
        }

        public  IEnumerable<ProjectionResponse> GetByDate(DateTime dateTime)
        {
             var projections =  repository.GetAll()
                                          .Where(p => p.DateTimeShowing.Day.Equals(dateTime.Day))
                                          .OrderBy(p => p.Movie.Name)
                                          .OrderBy(p => p.DateTimeShowing);

            var mappedProjections = mapper.Map<IEnumerable<ProjectionResponse>>(projections);

            return mappedProjections;
        }

        public IEnumerable<ProjectionResponse> Filter(ProjectionFilter projectionFilter)
        {
            var projections = repository.GetAll();

            if (!string.IsNullOrWhiteSpace(projectionFilter.MovieName))
            {
                projections = projections.Where(n => n.Movie.Name.Contains(projectionFilter.MovieName));
            }

            if (projectionFilter.StartDateTime != null  || projectionFilter.EndDateTime != null)
            {
                projections = projections.Where(x => x.DateTimeShowing >= projectionFilter.StartDateTime && x.DateTimeShowing <= projectionFilter.EndDateTime);
            }

            if (projectionFilter.StartPrice != null & projectionFilter.StartPrice != 0 || projectionFilter.EndPrice != null & projectionFilter.EndPrice != 0)
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

            var mappedProjections = mapper.Map<IEnumerable<ProjectionResponse>>(projections);

            return mappedProjections;
        }

        public ProjectionById GetById(int id)
        {
            var projection = repository.GetById(id);

            var mappedProjection = mapper.Map<ProjectionById>(projection);

            return mappedProjection;
        }

        public void Create(ProjectionRequest projectionRequest)
        {
            Projection projection = mapper.Map<Projection>(projectionRequest);
            repository.Create(projection);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }


    }
}