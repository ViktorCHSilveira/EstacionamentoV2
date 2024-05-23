using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Establishiment {
    public class Update {

        public class Command : IRequest {

            public Establishment Establishiment { get; set; }
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

                var establishiment = context.Establishment.Find(request.Establishiment.Id);

                mapper.Map(request.Establishiment, establishiment);
               
                await context.SaveChangesAsync();
            }
        }
    }
}
