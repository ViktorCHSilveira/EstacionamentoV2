using MediatR;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Microsoft.EntityFrameworkCore;
using API.Controllers.ParkingFloor.Responses;
using System.Reflection.Metadata.Ecma335;

namespace Application.ParkingFloor.Command
{
    public class CheckIn
    {

        public class Command : IRequest<ParckingFloorResponse>
        {

            public Domain.Entities.ParkingFloor ParkingFloor { get; set; }
        }

        public class Hanler : IRequestHandler<Command, ParckingFloorResponse>
        {

            private readonly DataContext context;

            public Hanler(DataContext context)
            {
                this.context = context;
            }
            public async Task<ParckingFloorResponse> Handle(Command request, CancellationToken cancellationToken)
            {

                var response =  new ParckingFloorResponse();

                var establishiment = context.Establishment.Find(request.ParkingFloor.EstablishimentId);

                if (establishiment == null) {
                    response.FlagError = true;
                    response.Msg = $"Nao foi possivel encontrar o cadastro da Empresa do id: {request.ParkingFloor.EstablishimentId}. Favaor Solicitacar o cadastro com o setor responsavel";

                    return response;
                }

                var vehicle = context.Vehicle.Find(request.ParkingFloor.VehicleId);

                if (vehicle == null) {
                    response.FlagError = true;
                    response.Msg =  $"Nao foi possivel encontrar o cadastro do veiculo com o  id: {request.ParkingFloor.VehicleId}. Favaor Cadastrar o Veiculo";
                    return response;
                }

                var spotUsed = await context.ParkingFloor.Where(e => e.EstablishimentId == establishiment.Id && e.CheckOutDt == null).ToListAsync();


                if (spotUsed.Count() >= establishiment.QtdeVagasCarros) {

                    response.FlagError = true;
                    response.Msg = $"Nao a vagas disponivel para essa empresa";
                    return response;

                }

                request.ParkingFloor.CheckInDt = DateTime.Now;

                context.Add(request.ParkingFloor);

                await context.SaveChangesAsync();

                response.FlagError = false;
                response.Msg = "CheckIn realizado com sucesso";

                return response;

            }
        }
    }
}
