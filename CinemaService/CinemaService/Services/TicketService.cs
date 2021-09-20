using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CinemaService.DTOs;
using CinemaService.Interfaces;
using CinemaService.Models;
using CinemaService.Models.DTOs;

namespace CinemaService.Services
{
   public class TicketService : ITicketService
   {

      private readonly ITicketRepository repository;

      private readonly IMapper mapper;

      public TicketService(ITicketRepository repository, IMapper mapper)
      {
         this.repository = repository;
         this.mapper = mapper;
      }


      public IEnumerable<TicketDtoAdmin> GetByProjectionId(int projectionId, string sortType)
      {
         var ticketsForAdmin = repository.GetAll().Where(x => x.Projection.Id == projectionId);

         if (sortType.Contains("CustomerName"))
         {
            ticketsForAdmin = ticketsForAdmin.OrderBy(x => x.Customer.Name);
         }

         if (sortType.Contains("CustomerNameDesc"))
         {
            ticketsForAdmin = ticketsForAdmin.OrderByDescending(x => x.Customer.Name);
         }

         if (sortType.Contains("DatePurchased"))
         {
            ticketsForAdmin = ticketsForAdmin.OrderBy(x => x.DatePurchased);
         }

         if (sortType.Contains("DatePurchasedDesc"))
         {
            ticketsForAdmin = ticketsForAdmin.OrderByDescending(x => x.DatePurchased);
         }

         return mapper.Map<IEnumerable<TicketDtoAdmin>>(ticketsForAdmin);
      }

      public TicketById GetById(int id)
      {
         Ticket ticket = repository.GetById(id);

         return mapper.Map<TicketById>(ticket);
      }

      public void Delete(int id)
      {
         var ticket = repository.GetById(id);

         if (ticket.Projection.DateTimeShowing < DateTime.Now)
         {
            repository.Delete(id);
         }

         throw new Exception("Projecton must be in past!");

      }

      public void Create(TicketRequest ticketRequest)
      {

         if (ticketRequest.Projection.SoldOut == true)
         {
            throw new Exception("The projection has been sold out!");
         }

         Ticket ticket = mapper.Map<Ticket>(ticketRequest);

         int soldTickets = ticket.Projection.Theater.Seats.Where(x => x.Free == false).Count();

         int soldTicketsAfterPurchase = soldTickets + ticketRequest.NumberOfTickets;

         int totalSeats = ticket.Projection.Theater.Seats.Count();


         if (soldTicketsAfterPurchase > totalSeats)
         {
            int difference = soldTicketsAfterPurchase - totalSeats;
            int allowedT = ticketRequest.NumberOfTickets - difference;


            throw new Exception("You can buy" + allowedT + "ticket/s");
         }



         if (soldTicketsAfterPurchase <= totalSeats)
         {


            if (soldTicketsAfterPurchase == totalSeats)
            {
               ticket.Projection.Theater.Free = false;
            }

            for (int i = 0; i < ticketRequest.NumberOfTickets; i++)
            {

               repository.Create(ticket);

            }

         }








      }



   }
}