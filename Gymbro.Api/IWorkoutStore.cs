using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymbro.Api.Models;

namespace Gymbro.Api
{
    public interface IWorkoutStore
    {
        Task Update(Workout workout);
        Task<IReadOnlyCollection<Workout>> Get(string userId);
    }
}