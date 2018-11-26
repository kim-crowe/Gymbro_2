using System;
using System.Threading.Tasks;
using Gymbro.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gymbro.Api.Controllers
{
    [Route("api/workouts")]

    public class WorkoutController : Controller
    {
        private IUserContext _userContext;
        private IWorkoutStore _workoutStore;

        public WorkoutController(IUserContext usercontext, IWorkoutStore workoutStore)
        {
            _userContext = usercontext;
            _workoutStore = workoutStore;

        }

        [HttpPost]
        public async Task<IActionResult> NewWorkout()
        {
            var newWorkout = new Workout
            {
                Date = DateTimeOffset.Now,
                UserId = _userContext.SignedInUser.Id,
                Id = Guid.NewGuid(),
                Exercises = new Exercise[0]                          
            };

            await _workoutStore.Update(newWorkout);
            return Json(newWorkout);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkout([FromBody]Workout workout)
        {
            workout.UserId = _userContext.SignedInUser.Id;
            if(workout.Id == Guid.Empty)
                workout.Id = Guid.NewGuid();
            
            await _workoutStore.Update(workout);
            return Ok();
        }

             
        [HttpGet]
        public async Task<IActionResult> GetWorkouts()
        {
            var data = await _workoutStore.Get(_userContext.SignedInUser.Id);
            return Json(data);
        }
        
        [HttpGet("sample")]
        public IActionResult GetSample()
        {
            var workout = new Workout
            {
                Id = Guid.Empty,
                UserId = "001",
                Date = DateTimeOffset.Now,
                Exercises = new Exercise[] 
                {
                    new Exercise 
                    {
                        Name = "Chest Press",
                        Equipment = "Barbell",
                        Sets = new Set[] 
                        {
                            new Set
                            {
                                Reps = 12,
                                Weight = 20
                            },
                            new Set
                            {
                                Reps = 12,
                                Weight = 20
                            },
                            new Set
                            {
                                Reps = 8,
                                Weight = 25
                            }
                        }
                    }
                }
            };

            return Json(workout);
        }
    }

}
