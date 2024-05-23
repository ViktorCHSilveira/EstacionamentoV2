using MediatR;
using Domain;
using Domain.Entities;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Vehicle {
    public class List {

        public class Query : IRequest<List<Domain.Entities.Vehicle>> { }



        public class Handler : IRequestHandler<Query, List<Domain.Entities.Vehicle>> {


            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext) {
                _dataContext = dataContext;
            }

            public async Task<List<Domain.Entities.Vehicle>> Handle(Query request, CancellationToken cancellationToken) {

                return await _dataContext.Vehicle.ToListAsync();
            }
        }
    }
}
