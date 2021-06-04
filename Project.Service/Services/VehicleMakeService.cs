using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Service.Data;
using Cars.Service.Models;
using Microsoft.EntityFrameworkCore;
using Project.Service.Interfaces;

namespace Project.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public VehicleMakeService(VehicleDBContext vehicleDBContext, IMapper mapper)
        {
            Mapper = mapper;
            VehicleDBContext = vehicleDBContext;
        }

        public VehicleDBContext VehicleDBContext { get; set; }

        public IMapper Mapper { get; set; }

        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            var returnedVehicleMake = await VehicleDBContext.VehicleMakes.FirstAsync(y => y.Id == id);
            if(returnedVehicleMake == null)
            {
                throw new Exception("Error.");
            }
            return returnedVehicleMake;
        }

        public async Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake)
        {
           if(vehicleMake == null || vehicleMake.Name == null || vehicleMake.Abrv == null)
           {
                throw new Exception("Missing info.");
           }
            VehicleDBContext.Add(vehicleMake);
            var numberOfCreated = await VehicleDBContext.SaveChangesAsync();
            return numberOfCreated;
        }

        public async Task<int> DeleteVehicleMakeAsync(int id)
        {
            var returnedVehicleMake = await VehicleDBContext.VehicleMakes.FirstAsync(y => y.Id == id);
            if (returnedVehicleMake == null)
            {
                throw new Exception("Not found.");
            }
            VehicleDBContext.VehicleMakes.Remove(returnedVehicleMake);
            var numberOfDeleted = await VehicleDBContext.SaveChangesAsync();
            return numberOfDeleted;
        }

        public async Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            if (vehicleMake == null)
            {
                throw new Exception("Missing info.");
            }
            VehicleDBContext.Update(vehicleMake);
            var numberOfUpdated = await VehicleDBContext.SaveChangesAsync();
            return numberOfUpdated;
        }

        public async Task<IEnumerable<VehicleMake>> FindAllVehicleMakesAsync()
        {
            var returnedVehicleMakes = await VehicleDBContext.VehicleMakes.ToListAsync();
            return returnedVehicleMakes;
        }

        public bool CheckIfExistsAsync(int id)
        {
            return VehicleDBContext.VehicleMakes.Any(y => y.Id == id);
        }

    }
}
