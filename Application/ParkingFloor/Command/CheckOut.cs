using API.Controllers.ParkingFloor.Responses;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParkingFloor.Command {
    public class CheckOut {

        public class Command : IRequest<ParckingFloorResponse> {

            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, ParckingFloorResponse> {

            private readonly DataContext context;

            public Handler(DataContext context) {
                this.context = context;
            }
            public async Task<ParckingFloorResponse> Handle(Command request, CancellationToken cancellationToken) {

                var response = new ParckingFloorResponse();

                var parkingFloor = await context.ParkingFloor.FindAsync(request.Id);

                if (parkingFloor == null) {
                    
                    response.FlagError = true;
                    response.Msg = $"Nao foi encotnrado estadia com o Id: {request.Id}";
                    return response;
                }


                var parkedTime = DateTime.Now.AddHours(-(parkingFloor.CheckInDt.Hour));

                if (TimeSpan.FromHours(parkedTime.Hour).TotalHours > parkingFloor.HoursPaydInAdvance) {

                    response.FlagError = true;
                    response.Msg = $"E preciso fazer o acerto de {TimeSpan.FromHours(parkedTime.Hour)} horas para poder fazer o CheckOut";
                    return response;

                }

                if (!parkingFloor.Payed) {
                    response.FlagError = true;
                    response.Msg = "Existe valores em aberto! Caso precisa de ajuda fale com um funcionario no local";
                    return response;
                }

                parkingFloor.CheckOutDt = DateTime.Now;

                context.Update(parkingFloor);

                await context.SaveChangesAsync();

                response.FlagError = false;
                response.Msg = "Check out feito com sucesso";
                return response;

            }
        }
    }
}
