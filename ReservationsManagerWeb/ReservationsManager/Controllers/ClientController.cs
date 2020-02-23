using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationsManager.Models;
using ReservationsManager.Models.Client;
using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private const int PageSize = 10;
        private readonly ReservationsManagerDb _context;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
            _context = new ReservationsManagerDb();
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

        // GET: Cars
        public async Task<IActionResult> Index(ClientIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<ClientViewModel> items = await _context.Clients.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ClientViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                IsAdult = c.IsAdult
            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Rooms.CountAsync() / (double)PageSize);

            return View(model);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ClientCreateViewModel model = new ClientCreateViewModel();

            return View(model);
        }

        // POST: Cars/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientCreateViewModel createModel)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client
                {
                    Name = createModel.Name,
                    Surname = createModel.Surname,
                    Email = createModel.Email,
                    PhoneNumber = createModel.PhoneNumber,
                    IsAdult = createModel.IsAdult
                };


                _context.Add(client);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(createModel);
        }
    }
}
