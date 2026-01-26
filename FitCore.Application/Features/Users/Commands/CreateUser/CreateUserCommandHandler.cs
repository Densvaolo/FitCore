using MediatR;
using FitCore.Domain.Entities;
using FitCore.Application.Common.Interfaces;
using FluentValidation;

namespace FitCore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IFitCoreDbContext _context;


        public CreateUserCommandHandler(IFitCoreDbContext context)
        {
            _context = context;
           
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CurrentWeight = request.CurrentWeight,
                GoalWeight = request.GoalWeight
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;

        }

    }
}
