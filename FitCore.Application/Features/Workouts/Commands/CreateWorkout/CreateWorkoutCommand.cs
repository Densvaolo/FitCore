using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Workouts.Commands.CreateWorkout
{
    public class CreateWorkoutCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string Notes { get; set; } = string.Empty;
        public List<WorkoutSetDto> Sets { get; set; } = new List<WorkoutSetDto>();
    }
}
