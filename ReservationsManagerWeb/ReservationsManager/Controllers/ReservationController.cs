using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using ReservationsManager.Models;
using ReservationsManager.Models.Reservation;
using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace ReservationsManager.Controllers
{
    //[Authorize(Roles = "User")]
    [Authorize]
    public class ReservationController : Controller
    {
        private const string password = Constants.emailPassword;

        private const int PageSize = 10;

        private readonly ILogger<ReservationController> _logger;

        private readonly ReservationsManagerDb _context;

        private UserManager<User> UserManager { get; set; }

        public ReservationController(ILogger<ReservationController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _context = new ReservationsManagerDb();
            this.UserManager = userManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        // GET: Reservation
        public async Task<IActionResult> Index(ReservationIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(r => new ReservationViewModel()
            {
                Id = r.Id,
                User = r.User,
                CheckInDate = r.CheckInDate,
                CheckOutDate = r.CheckOutDate,
                HasBreakfast = r.HasBreakfast,
                IsAllInclusive = r.IsAllInclusive,
                ClientReservations = r.ClientReservations.ToList()
            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Reservations.CountAsync() / (double)PageSize);

            return View(model);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            ReservationCreateViewModel model = new ReservationCreateViewModel();

            List<ReservationCreateClientViewModel> clients = _context.Clients
                .Select(x => new ReservationCreateClientViewModel(x.Id, x.Name))
                .ToList();

            List<ReservationCreateRoomViewModel> rooms = _context.Rooms.Select(x => new ReservationCreateRoomViewModel(x.Id, x.RoomType, x.PricePerAdult, x.PricePerChild, x.IsFree)).ToList();
            //rooms = rooms.Where(r => r.IsFree = true).ToList();

            List<ReservationCreateRoomViewModel> freeRooms = new List<ReservationCreateRoomViewModel>();

            foreach (var room in rooms)
            {
                if (room.IsFree)
                {
                    freeRooms.Add(room);
                }
            }

            model.CreateClient = clients;
            model.RoomsAdded = freeRooms;

            return View(model);
        }

        // POST: Reservation/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestReservationCreateViewModel createModel)
        {
            //User user = _context.Users.Find(userManager.GetUserId(User));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            //var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            User user = await UserManager.GetUserAsync(User);
            //string userEmail = user?.Email; // will give the user's Email

            List<Client> clients = new List<Client>();

            foreach (var clientId in createModel.ClientsId)
            {
                Client client = new Client();
                //client = (Client)_context.Clients.Where(x => x.Id == clientId);
                client = _context.Clients.FirstOrDefault(x => x.Id == clientId);
                clients.Add(client);
            }

            Room room = _context.Rooms.FirstOrDefault(x => x.Id == createModel.RoomId);
            room.IsFree = false;
            //room = _context.Rooms.FirstOrDefault(x => x.Id == createModel.RoomId);

            //ClientReservation clientReservation = new ClientReservation();
            //clientReservation.Client = clients[0];

            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    //User = createModel.User,
                    UserId = user.Id,
                    //User = user,
                    CheckInDate = createModel.CheckInDate,
                    CheckOutDate = createModel.CheckOutDate,
                    HasBreakfast = createModel.HasBreakfast,
                    IsAllInclusive = createModel.IsAllInclusive,
                    Room = room,
                    ClientReservations = clients.Select(client => new ClientReservation { Client = client }).ToList()
                };


                _context.Add(reservation);
                await _context.SaveChangesAsync();

                foreach (Client client in clients)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ReservationManager", "rusanamoneva@gmail.com"));
                    message.To.Add(new MailboxAddress($"{client.Email}"));
                    message.Subject = "Rreservation";
                    message.Body = new TextPart("Successful reservation!");

                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 587, false);
                        emailClient.Authenticate("rusanamoneva@gmail.com", password);
                        emailClient.Send(message);
                        emailClient.Disconnect(true);
                    }
                }
                

                return RedirectToAction(nameof(Index));
            }

            return View(createModel);
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            ReservationEditViewModel model = new ReservationEditViewModel
            {
                Id = reservation.Id,
                User = reservation.User,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate,
                HasBreakfast = reservation.HasBreakfast,
                IsAllInclusive = reservation.IsAllInclusive

            };

            return View(model);
        }

        // POST: Reservation/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationEditViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation()
                {
                    Id = editModel.Id,
                    User = editModel.User,
                    CheckInDate = editModel.CheckInDate,
                    CheckOutDate = editModel.CheckOutDate,
                    HasBreakfast = editModel.HasBreakfast,
                    IsAllInclusive = editModel.IsAllInclusive
                };

                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        reservation.Id = editModel.Id;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editModel);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Reservation reservation = await _context.Reservations.FindAsync(id);
            reservation.Room.IsFree = true;
            _context.Reservations.Remove(reservation);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
