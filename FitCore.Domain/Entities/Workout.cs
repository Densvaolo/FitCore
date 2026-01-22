using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Domain.Entities
{
    public class Workout
    {
        public Guid Id { get; set; } 
        public DateTime Date { get; set; }
        public int Type { get; set; } 
        public string? Notes { get; set; }
        public ICollection<ExerciseSet> Sets { get; set; } = new List<ExerciseSet>();
        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}
