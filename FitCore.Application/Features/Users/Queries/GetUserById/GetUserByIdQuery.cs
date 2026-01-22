using FitCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
