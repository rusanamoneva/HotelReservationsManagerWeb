﻿using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationsManager.Models;
using ReservationsManager.Models.Reservation;
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
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;
        private const int PageSize = 10;
        private readonly ReservationsManagerDb _context;

        public ReservationController(ILogger<ReservationController> logger)
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
            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(await _context.Reservations.CountAsync() / (double)PageSize);

            return View(model);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            ReservationCreateViewModel model = new ReservationCreateViewModel();

            return View(model);
        }

        // POST: Reservation/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateViewModel createModel)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    User = createModel.User,
                    CheckInDate = createModel.CheckInDate,
                    CheckOutDate = createModel.CheckOutDate,
                    HasBreakfast = createModel.HasBreakfast,
                    IsAllInclusive = createModel.IsAllInclusive
                };


                _context.Add(reservation);
                await _context.SaveChangesAsync();

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
