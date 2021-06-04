using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Service.Data;
using Cars.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.Service.Services
{
    public class VehicleModelService
    {
        public VehicleModelService(VehicleDBContext vehicleDBContext, IMapper mapper)
        {
            Mapper = mapper;
            VehicleDBContext = vehicleDBContext;
        }
        public VehicleDBContext VehicleDBContext { get; set; }

        public IMapper Mapper { get; set; }
        public async Task<VehicleModel> GetVehicleModelAsync(int id)
        {
            var returnedVehicleModel = await VehicleDBContext.VehicleModels.FirstAsync(y => y.Id == id);
            
            if (returnedVehicleModel == null)
            {
                throw new Exception("Error.");
            }
            return returnedVehicleModel;
        }

        public async Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel)
        {
            if (vehicleModel == null || vehicleModel.Name == null || vehicleModel.Abrv == null)
            {
                throw new Exception("Missing info.");
            }
            VehicleDBContext.Add(vehicleModel);
            var numberOfCreated = await VehicleDBContext.SaveChangesAsync();
            return numberOfCreated;
        }

        public async Task<int> DeleteVehicleModelAsync(int id)
        {
            var returnedVehicleModel = await VehicleDBContext.VehicleModels.FirstAsync(y => y.Id == id);
            if (returnedVehicleModel == null)
            {
                throw new Exception("Not found.");
            }
            VehicleDBContext.VehicleModels.Remove(returnedVehicleModel);
            var numberOfDeleted = await VehicleDBContext.SaveChangesAsync();
            return numberOfDeleted;
        }

        public async Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            if (vehicleModel == null)
            {
                throw new Exception("Missing info.");
            }
            VehicleDBContext.Update(vehicleModel);
            var numberOfUpdated = await VehicleDBContext.SaveChangesAsync();
            return numberOfUpdated;
        }

        public async Task<IEnumerable<VehicleModel>> FindAllVehicleModelsAsync()
        {
            var returnedVehicleModels = await VehicleDBContext.VehicleModels.ToListAsync();
            return returnedVehicleModels;
        }

        public bool CheckIfExistsAsync(int id)
        {
            return VehicleDBContext.VehicleModels.Any(y => y.Id == id);
        }
    }

}
