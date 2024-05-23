using API.Controllers.Core;
using Application.Vehicle;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class VehicleController : BaseApiController {

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(Guid id) {

            var vehicle = Mediator.Send(new Details.Query { Id = id });

            return Ok(vehicle);
        }


        [HttpGet]
        public async Task<ActionResult> FindAll() {

            var vehicle = Mediator.Send(new List.Query());

            return Ok(vehicle);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle) {

            if (vehicle == null) return BadRequest();

            await Mediator.Send(new Create.Command { Vehicle = vehicle });

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Uptade(Guid id, Vehicle obj) {

            if (obj == null) return BadRequest();

            await Mediator.Send(new Update.Command { Vehicle = obj });

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {

            await Mediator.Send(new Delete.Command { Id = id });

            return Ok();
        }
        
    }
}
