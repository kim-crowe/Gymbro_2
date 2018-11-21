using System;
using System.Threading.Tasks;
using Gymbro.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gymbro.Api.Controllers
{
    [Route("api/records")]

    public class ExerciseRecordController : Controller
    {
        private IUserContext _userContext;
        private IExerciseRecordStore _exerciseRecordStore;

        public ExerciseRecordController(IUserContext usercontext, IExerciseRecordStore exerciseRecordStore)
        {
            _userContext = usercontext;
            _exerciseRecordStore = exerciseRecordStore;

        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseRecord([FromBody]ExerciseRecordRequest exerciseRecordRequest)
        {
            var exerciseRecord = new ExerciseRecord
            {
                Id = Guid.NewGuid(),
                UserId = _userContext.SignedInUser.Id,
                Date = exerciseRecordRequest.Date,
                Equipment = exerciseRecordRequest.Equipment,
                Exercise = exerciseRecordRequest.Exercise,
                Sets = exerciseRecordRequest.Sets
            };
            
            await _exerciseRecordStore.CreateExerciseRecord(exerciseRecord);
            return Ok();
        }

             
        [HttpGet("by/date")]
        public async Task<IActionResult> GetExerciseRecordsForAGivenDate([FromQuery]DateTimeOffset date)
        {
            System.Threading.Thread.Sleep(2);
            var record = await _exerciseRecordStore.GetExerciseRecordsForAGivenDate(_userContext.SignedInUser.Id, date);
            return Json(record);
        }
        

        [HttpGet("by/exercise")]
        public async Task<IActionResult> GetExerciseRecordsForAGivenExercise([FromQuery]string exercise)
        {
            var record = await _exerciseRecordStore.GetExerciseRecordsForAGivenExercise(_userContext.SignedInUser.Id, exercise);
            return Json(record);
        }
    }

}
