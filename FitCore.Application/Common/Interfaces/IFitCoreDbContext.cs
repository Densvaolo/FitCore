using FitCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Application.Common.Interfaces
{
    public interface IFitCoreDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Workout> Workouts { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
