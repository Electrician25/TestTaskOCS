using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.Controllers
{
    [ApiController]
    [Route("/api/meetingDate/")]
    public class RequestMeetingDateController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _meetingRequestCrudServices;

        public RequestMeetingDateController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _meetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet("{id}")]
        public async Task<MeetingRequest> GetMeetingRequestByDataAsync(DateTime id)
        {
            return await _meetingRequestCrudServices.FindMeetingRequestByDataAsync(id);
        }
    }
}