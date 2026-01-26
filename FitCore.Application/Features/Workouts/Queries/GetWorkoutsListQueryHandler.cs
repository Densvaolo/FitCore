using FitCore.Application.Common.Interfaces;
using FitCore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Workouts.Queries
{
    public class GetWorkoutsListQueryHandler : IRequestHandler<GetWorkoutsListQuery, List<Workout>>
    {
        private readonly IFitCoreDbContext _context;

        public GetWorkoutsListQueryHandler(IFitCoreDbContext context) => _context = context;

        public async Task<List<Workout>> Handle(GetWorkoutsListQuery request, CancellationToken cancellationToken)
        {          
            return await _context.Workouts
                .Where(w => w.UserId == request.UserId)
                .Include(w => w.Sets)
                .ToListAsync(cancellationToken);
        }
    }
}
