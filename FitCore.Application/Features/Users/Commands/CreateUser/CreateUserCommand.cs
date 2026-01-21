using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Users.Commands.CreateUser
{
    // IRequest<Guid> betyder: "När detta kommando är klart, får jag tillbaka ett Guid (användarens Id)"
    public class CreateUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double? CurrentWeight { get; set; }
        public double? GoalWeight { get; set; }
    }
}
