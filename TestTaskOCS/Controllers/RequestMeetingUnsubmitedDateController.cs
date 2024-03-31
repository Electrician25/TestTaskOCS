using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.Controllers
{
    [ApiController]
    [Route("/api/unsubmitedDate/")]
    public class RequestMeetingUnsubmitedDateController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _meetingRequestCrudServices;

        public RequestMeetingUnsubmitedDateController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _meetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet("{id}")]
        public async Task<MeetingRequest[]> GetAllUnsubmitMeetingRequestByOlderDateAsync(DateTime id)
        {
            return await _meetingRequestCrudServices.FindAllUnsubmitMeetingRequestByOlderDateAsync(id);
        }
    }
}