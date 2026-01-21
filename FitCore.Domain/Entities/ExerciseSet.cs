using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Domain.Entities{
    public class ExerciseSet
    {
        public Guid Id  { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public int Reps { get; set; }
        public double Weight { get; set; }
        public double? DistanceKm { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid WorkoutID { get; set; }
        public Workout? Workout { get; set; }
    }
}
