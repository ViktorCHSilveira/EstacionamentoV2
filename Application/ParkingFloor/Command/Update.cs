using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParkingFloor.Command
{
    public class Update
    {

        public class Command : IRequest
        {

            public Domain.Entities.ParkingFloor ParkingFloor { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {

            private readonly DataContext context;
            private readonly IMapper mapper;

            public Handler(DataContext context,
                            IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {

                var car = context.ParkingFloor.Find(request.ParkingFloor.Id);

                mapper.Map(request.ParkingFloor, car);

                await context.SaveChangesAsync();

            }
        }
    }
}
