using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.Controllers
{
    [ApiController]
    [Route("/api/unsubmited")]
    public class RequestMeetingUnsubmitedController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _meetingRequestCrudServices;

        public RequestMeetingUnsubmitedController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _meetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet("{id}")]
        public async Task<MeetingRequest[]> GetAllUnsubmitMeetingRequestByUserIdAsync(Guid id)
        {
            return await _meetingRequestCrudServices.FindUnsubmitMeetingRequestByUserId(id);
        }

        [HttpGet("getAllUnsubmitedRequests")]
        public async Task<MeetingRequest[]> GetAllUnsubmitMeetingRequest()
        {
            return await _meetingRequestCrudServices.FindAllUnsubmitMeetingRequest();
        }
    }
}