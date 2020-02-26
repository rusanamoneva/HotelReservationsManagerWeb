using Data;
using Data.Entities;
using Data.Enumeration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationsManager.Models;
using ReservationsManager.Models.Room;
using ReservationsManager.Models.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationsManager.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ILogger<RoomsController> _logger;
        private const int PageSize = 10;
        private readonly ReservationsManagerDb _context;

        public RoomsController(ILogger<RoomsController> logger)
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
        public async Task<IActionResult> Index(RoomsIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<RoomsViewModel> items = await _context.Rooms.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new RoomsViewModel()
            {
                Id = c.Id,
                Capacity = c.Capacity,
                PricePerAdult = c.PricePerAdult,
                PricePerChild = c.PricePerChild,
                IsFree = c.IsFree,
                Number = c.Number
            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Rooms.CountAsync() / (double)PageSize);

            return View(model);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            RoomsCreateViewModel model = new RoomsCreateViewModel();

            return View(model);
        }

        // POST: Cars/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomsCreateViewModel createModel)
        {
            //RoomTypeEnum roomTypeEnum = new RoomTypeEnum();
            //roomTypeEnum = (RoomTypeEnum)(createModel.RoomType);

            if (ModelState.IsValid)
            {
                Room room = new Room
                {
                    Capacity = createModel.Capacity,
                    PricePerAdult = createModel.PricePerAdult,
                    PricePerChild = createModel.PricePerChild,
                    //RoomType = roomTypeEnum,
                    RoomType = createModel.RoomType,
                    IsFree = createModel.IsFree,
                    Number = createModel.Number
                };


                _context.Add(room);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(createModel);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            RoomsEditViewModel model = new RoomsEditViewModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                PricePerAdult = room.PricePerAdult,
                PricePerChild = room.PricePerChild,
                RoomType = room.RoomType,
                IsFree = room.IsFree,
                Number = room.Number

            };

            return View(model);
        }

        // POST: Cars/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomsEditViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                Room room = new Room()
                {
                    Id = editModel.Id,
                    Capacity = editModel.Capacity,
                    PricePerAdult = editModel.PricePerAdult,
                    PricePerChild = editModel.PricePerChild,
                    IsFree = editModel.IsFree,
                    Number = editModel.Number
                };

                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        room.Id = editModel.Id;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editModel);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
