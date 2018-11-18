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
        public async Task<IActionResult> CreateExerciseRecord([FromBody]ExerciseRecord exerciseRecord)
        {
            if(_userContext.SignedInUser.Id != exerciseRecord.UserId)
            {
                return Forbid();
            }
            await _exerciseRecordStore.CreateExerciseRecord(exerciseRecord);
            return Ok();
        }

             
        [HttpGet("by/date")]
        public async Task<IActionResult> GetExerciseRecordsForAGivenDate([FromQuery]DateTimeOffset date)
        {
            var record = await _exerciseRecordStore.GetExerciseRecordsForAGivenDate(date);
            return Json(record);
        }
        

        [HttpGet("by/exercise")]
        public async Task<IActionResult> GetExerciseRecordsForAGivenExercise([FromQuery]string exercise)
        {
            var record = await _exerciseRecordStore.GetExerciseRecordsForAGivenExercise(exercise);
            return Json(record);
        }
    }

}
