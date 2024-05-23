using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Establishiment {
    public class Create {

        public class Command : IRequest { 

            public Establishment Establishiment { get; set; }

        }

        public class Handler : IRequestHandler<Command> {

            private readonly DataContext context;

            public Handler(DataContext context) {
                this.context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken) {
               
                context.Add(request.Establishiment);

                await context.SaveChangesAsync();
            }
        }
    }
}
