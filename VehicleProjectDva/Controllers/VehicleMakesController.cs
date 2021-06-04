using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars.Service.Data;
using Cars.Service.Models;
using Project.Service.Services;
using Project.Service.Interfaces;

namespace VehicleProjectDva.Controllers
{
    public class VehicleMakesController : Controller
    {

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            VehicleMakeService = vehicleMakeService;
        }

       public IVehicleMakeService VehicleMakeService { get; set; }

        // GET: VehicleMakes
        public async Task<IActionResult> Index()
        {
            var foundVehicleMakes = await VehicleMakeService.FindAllVehicleMakesAsync();
           return View(foundVehicleMakes);

        }

        // GET: VehicleMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await VehicleMakeService.GetVehicleMakeAsync(id.Value);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                var createdVehicleMake = await VehicleMakeService.CreateVehicleMakeAsync(vehicleMake);
                if(createdVehicleMake > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(vehicleMake);
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var vehicleMake = await VehicleMakeService.GetVehicleMakeAsync(id.Value);
            if (vehicleMake == null)
            {
                return NotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (id != vehicleMake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await VehicleMakeService.UpdateVehicleMakeAsync(vehicleMake);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakeExists(vehicleMake.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var foundVehicleMakes = await VehicleMakeService.GetVehicleMakeAsync(id);
            if (foundVehicleMakes == null)
            {
                return NotFound();
            }

            return View(foundVehicleMakes);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            
            var deletedVehicleMakes = await VehicleMakeService.DeleteVehicleMakeAsync(id);
            if (deletedVehicleMakes == 0)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VehicleMakeExists(int id)
        {
            return VehicleMakeService.CheckIfExistsAsync(id);
        }
    }
}
