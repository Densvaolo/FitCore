using FitCore.Application.Common.Interfaces;
using FitCore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly IFitCoreDbContext _context;

        public GetUserByIdQueryHandler(IFitCoreDbContext context) => _context = context;

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                      .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
         
            return user;
        }
    }
}
