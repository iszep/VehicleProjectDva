using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cars.Service.Models;

namespace Project.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> GetVehicleMakeAsync(int id);

        Task<int> CreateVehicleMakeAsync(VehicleMake vehicleMake);


        Task<int> DeleteVehicleMakeAsync(int id);

        Task<int> UpdateVehicleMakeAsync(VehicleMake vehicleMake);

        Task<IEnumerable<VehicleMake>> FindAllVehicleMakesAsync();

        bool CheckIfExistsAsync(int id);
    }
}
