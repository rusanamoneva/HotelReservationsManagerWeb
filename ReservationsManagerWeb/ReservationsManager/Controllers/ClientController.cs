using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles = "User")]
    [Authorize]
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

        [AllowAnonymous]
        // GET: Client
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
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Clients.CountAsync() / (double)PageSize);

            
           
            return View(model);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            ClientCreateViewModel model = new ClientCreateViewModel();

            return View(model);
        }

        // POST: Client/Create        
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

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            ClientEditViewModel model = new ClientEditViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                IsAdult = client.IsAdult

            };

            return View(model);
        }

        // POST: Client/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientEditViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client()
                {
                    Id = editModel.Id,
                    Name = editModel.Name,
                    Surname = editModel.Surname,
                    Email = editModel.Email,
                    PhoneNumber = editModel.PhoneNumber,
                    IsAdult = editModel.IsAdult
                };

                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        client.Id = editModel.Id;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editModel);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Client client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string searchString)
        {
            var clients = from m in _context.Clients
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(s => s.Name == searchString || s.Surname == searchString);
            }

            return View(await clients.ToListAsync());
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
