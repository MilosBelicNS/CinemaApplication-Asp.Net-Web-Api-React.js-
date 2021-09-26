using System.Web.Http;
using AutoMapper;
using CinemaService.App_Start;
using CinemaService.Interfaces;
using CinemaService.Interfaces.IProjectionType;
using CinemaService.Interfaces.ITheater;
using CinemaService.Repository;
using CinemaService.Services;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.WebApi;

namespace CinemaService
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         // Web API configuration and services
         // Configure Web API to use only bearer token authentication.
         config.SuppressDefaultHostAuthentication();
         config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

         var settings = config.Formatters.JsonFormatter.SerializerSettings;

         settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
         settings.Formatting = Formatting.Indented;

         // Web API routes
         config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );

         var configuration = new MapperConfiguration(cfg =>
         {
            cfg.AddProfile<MappingProfile>();
         });

         var mapper = configuration.CreateMapper();

         //UnityDependency IOC
         var container = new UnityContainer();
         container.RegisterType<IMovieRepository, MovieRepository>();
         container.RegisterType<IMovieService, MovieService>();

         container.RegisterType<IProjectionRepository, ProjectionRepository>();
         container.RegisterType<IProjectionService, ProjectionService>();

         container.RegisterType<ITicketRepository, TicketRepository>();
         container.RegisterType<ITicketService, TicketService>();

         container.RegisterType<ITheaterRepository, TheaterRepository>();
         container.RegisterType<ITheaterService, TheaterService>();

         container.RegisterType<IProjectionTypeRepository, ProjectionTypeRepository>();
         container.RegisterType<IProjectionTypeService, ProjectionTypeService>();

         container.RegisterInstance(mapper);

         config.DependencyResolver = new UnityDependencyResolver(container);


      }
   }
}
