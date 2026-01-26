using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Features.Workouts.Commands.CreateWorkout
{
    public class WorkoutSetDto
    {
        public string ExerciseName { get; set; } = string.Empty;
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}
