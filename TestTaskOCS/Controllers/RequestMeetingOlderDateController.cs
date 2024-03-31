using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.Controllers
{
    [ApiController]
    [Route("/api/olderDate/")]
    public class RequestMeetingOlderDateController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _meetingRequestCrudServices;

        public RequestMeetingOlderDateController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _meetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet("{id}")]
        public async Task<MeetingRequest[]> GetAllMeetingRequestByOlderDateAsync(DateTime id)
        {
            return await _meetingRequestCrudServices.FindAllMeetingRequestByOlderDateAsync(id);
        }
    }
}