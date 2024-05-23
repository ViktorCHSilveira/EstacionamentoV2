using MediatR;
using Domain;
using Domain.Entities;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Establishiment {
    public class List {

        public class Query : IRequest<List<Establishment>> { }



        public class Handler : IRequestHandler<Query, List<Establishment>> {


            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext) {
                _dataContext = dataContext;
            }

            public async Task<List<Establishment>> Handle(Query request, CancellationToken cancellationToken) {

                return await _dataContext.Establishment.ToListAsync();
            }
        }
    }
}
