using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Establishiment {
    public class Details {

        public class Query : IRequest<Establishment> {

            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Establishment> {
            
            private readonly DataContext context;

            public Handler( DataContext context) {
                this.context = context;
            }
            public async Task<Establishment> Handle(Query request, CancellationToken cancellationToken) {


                return await context.Establishment.FindAsync(request.Id); 
            }
        }


    }
}
