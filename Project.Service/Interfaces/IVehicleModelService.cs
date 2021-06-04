using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cars.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> GetVehicleModelAsync(int id);

        Task<int> CreateVehicleModelAsync(VehicleModel vehicleModel);


        Task<int> DeleteVehicleModelAsync(int id);

        Task<int> UpdateVehicleModelAsync(VehicleModel vehicleModel);

        Task<IEnumerable<VehicleModel>> FindAllVehicleModelsAsync();

        bool CheckIfExistsAsync(int id);
    }
}
