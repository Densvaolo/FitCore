using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double? CurrentWeight { get; set; }

        public double? GoalWeight  { get; set; }
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();

    }
}
