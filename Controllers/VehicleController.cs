using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tacografo_DB.Modelos;
using Tacografo_DB.Repositorios;

namespace Tacografo_DB.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private IVehicleCollection vehicleCollection = new VehicleCollection();
        private Alert alert = new Alert();

        [HttpGet]
        public async Task<IActionResult> GetFullVehiclesList()
        {
            return Ok(await vehicleCollection.GetFullVehicleList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(string id)
        {
            return Ok(await vehicleCollection.GetVehicleById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertVehicleData([FromBody]Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            await vehicleCollection.InsertVehicleData(vehicle);

            if (vehicle.FuelAlert)
                alert.SendAlert(vehicle.DeviceID);

            return Created("Vehicle inserted.", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleData([FromBody] Vehicle vehicle, string id)
        {
            if (vehicle == null)
                return BadRequest();

            vehicle.Id = new MongoDB.Bson.ObjectId(id);
            await vehicleCollection.UpdateVehicleData(vehicle);
            return Created("Vehicle updated.", true);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleData(string id)
        {
            await vehicleCollection.DeleteVehicleData(id);
            return NoContent();
        }
    }
}
