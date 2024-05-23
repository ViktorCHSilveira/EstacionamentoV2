using API.Controllers.Core;
using Application.Establishiment;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Establishiment
{


    public class EstablishimentController : BaseApiController
    {

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(Guid id)
        {

            var estabelishiment = Mediator.Send(new Details.Query { Id = id });

            return Ok(estabelishiment);
        }


        [HttpGet]
        public async Task<ActionResult> FindAll()
        {

            var establishiment = Mediator.Send(new List.Query());

            return Ok(establishiment);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Establishment establishment)
        {

            if (establishment == null) return BadRequest();

            await Mediator.Send(new Create.Command { Establishiment = establishment });

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Uptade(Guid id, Establishment obj)
        {

            if (obj == null) return BadRequest();

            await Mediator.Send(new Update.Command { Establishiment = obj });

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {

            await Mediator.Send(new Delete.Command { Id = id });

            return Ok();
        }
    }
}
