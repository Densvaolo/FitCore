using FitCore.Application.Features.Workouts.Commands.CreateWorkout;
using FitCore.Application.Features.Workouts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpPost]
        public async Task<IActionResult> CreateWorkout(CreateWorkoutCommand command)
        {

            var workoutId = await _mediator.Send(command);
            if (workoutId == Guid.Empty)
            {
                return BadRequest("Failed to create workout.");
            }
            return Ok(workoutId);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWorkoutsByUserId(Guid userId)
        {
            var query = new GetWorkoutsListQuery { UserId = userId };
            var workouts = await _mediator.Send(query);
     
            return Ok(workouts);


        }
    }
}