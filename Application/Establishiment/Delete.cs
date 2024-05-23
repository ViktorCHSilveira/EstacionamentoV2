using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Establishiment {
    public class Delete {

        public class Command : IRequest {

            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command> {

            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken) {

                var establishiment = await context.Establishment.FindAsync(request.Id);

                context.Remove(establishiment);

                await context.SaveChangesAsync();

            }
        }
    }
}
