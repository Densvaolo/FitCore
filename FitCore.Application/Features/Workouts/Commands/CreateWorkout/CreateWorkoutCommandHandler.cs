using FitCore.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Workouts.Commands.CreateWorkout
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, Guid>
    {
        private readonly IFitCoreDbContext _context;

        public CreateWorkoutCommandHandler(IFitCoreDbContext context) => _context = context;

        public async Task<Guid> Handle (CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = new Domain.Entities.Workout
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Date = request.Date,
                Type = request.Type,
                Notes = request.Notes
            };
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync(cancellationToken);
            return workout.Id;
        }
    }
}
