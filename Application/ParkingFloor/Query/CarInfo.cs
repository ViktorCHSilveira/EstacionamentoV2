using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ParkingFloor.Query
{
    public class CarInfo
    {

        public class Query : IRequest<Domain.Entities.ParkingFloor>
        {

            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Domain.Entities.ParkingFloor>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }
            public async Task<Domain.Entities.ParkingFloor> Handle(Query request, CancellationToken cancellationToken)
            {

                return await context.ParkingFloor.FindAsync(request.Id);
            }
        }
    }
}
