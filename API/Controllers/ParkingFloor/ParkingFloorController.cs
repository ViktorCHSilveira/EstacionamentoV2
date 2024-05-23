using API.Controllers.Core;
using API.Controllers.ParkingFloor.Responses;
using Application.ParkingFloor.Command;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ParkingFloor
{
    public class ParkingFloorController : BaseApiController
    {

        [HttpPost("checkin")]
        public async Task<ActionResult> DoCheckIn(Domain.Entities.ParkingFloor obj)
        {

            var response = await Mediator.Send(new CheckIn.Command { ParkingFloor = obj });


            if (response.FlagError) {

                return BadRequest(response.Msg);

            }

            return Ok(response.Msg);

        }

        [HttpPost("checkOut")]

        public async Task<ActionResult> DoCheckOut(Guid Id) { 
        
            var response = await Mediator.Send(new CheckOut.Command { Id = Id });

            if (response.FlagError)
            {
                return BadRequest(response.Msg);
            }

            return Ok(response.Msg);

        }
    }
}
