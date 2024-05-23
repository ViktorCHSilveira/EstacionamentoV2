using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle {
    public class Update {

        public class Command : IRequest {

            public Domain.Entities.Vehicle Vehicle { get; set; }
        }

        public class Handler : IRequestHandler<Command> {

            private readonly DataContext context;
            private readonly IMapper mapper;

            public Handler(DataContext context, 
                           IMapper mapper) {

                this.context = context;
                this.mapper = mapper;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken) {

                var vehicle = context.Vehicle.Find(request.Vehicle.Id);

                mapper.Map(request.Vehicle, vehicle);
               
                await context.SaveChangesAsync();
            }
        }
    }
}
