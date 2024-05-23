using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicle {
    public class Details {

        public class Query : IRequest<Domain.Entities.Vehicle> {

            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Domain.Entities.Vehicle> {
            
            private readonly DataContext context;

            public Handler( DataContext context) {
                this.context = context;
            }
            public async Task<Domain.Entities.Vehicle> Handle(Query request, CancellationToken cancellationToken) {


                return await context.Vehicle.FindAsync(request.Id); 
            }
        }


    }
}
