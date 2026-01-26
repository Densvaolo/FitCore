using FitCore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Workouts.Queries
{
    public class GetWorkoutsListQuery : IRequest<List<Workout>>
    {
        public Guid UserId { get; set; }

    }
}
