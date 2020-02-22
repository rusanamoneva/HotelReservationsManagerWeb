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
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private const int PageSize = 10;
        private readonly ReservationsManagerDb _context;

        public RoomController(ILogger<RoomController> logger)
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
        public async Task<IActionResult> Index(RoomIndexViewModel model)
        {
            model.Pager ??= new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<RoomViewModel> items = await _context.Rooms.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(r => new RoomViewModel()
            {
                Id = r.Id,
                Capacity = r.Capacity,
                RoomType = r.RoomType,
                IsFree = r.IsFree,
                PricePerAdult = r.PricePerAdult,
                PricePerChild = r.PricePerChild,
                Number = r.Number
            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Rooms.CountAsync() / (double)PageSize);

            return View(model);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            RoomCreateViewModel model = new RoomCreateViewModel();

            return View(model);
        }

        // POST: Cars/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomCreateViewModel createModel)
        {
            //var model = "";
            RoomTypeEnum roomTypeEnum = new RoomTypeEnum();
            roomTypeEnum = (RoomTypeEnum)(createModel.RoomType);


            if (ModelState.IsValid)
            {
                Room room = new Room
                {
                    Capacity = createModel.Capacity,
                    RoomType = roomTypeEnum,
                    IsFree = createModel.IsFree,
                    PricePerAdult = createModel.PricePerAdult,
                    PricePerChild = createModel.PricePerChild,
                    Number = createModel.Number
                };


                _context.Add(room);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(createModel);
        }
    }
}
