using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tacografo_DB.Modelos;

namespace Tacografo_DB.Repositorios
{
    public interface IVehicleCollection
    {
        Task InsertVehicleData(Vehicle vehicle);
        Task UpdateVehicleData(Vehicle vehicle);
        Task DeleteVehicleData(string id);
        Task<List<Vehicle>> GetFullVehicleList();
        Task<Vehicle> GetVehicleById(string id);
    }
}
