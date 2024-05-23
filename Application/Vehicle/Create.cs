using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle {
    public class Create {

        public class Command : IRequest { 

            public Domain.Entities.Vehicle Vehicle { get; set; }

        }

        public class Handler : IRequestHandler<Command> {

            private readonly DataContext context;

            public Handler(DataContext context) {
                this.context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken) {
               
                context.Add(request.Vehicle);

                await context.SaveChangesAsync();
            }
        }
    }
}
