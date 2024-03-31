using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.Controllers
{
    [ApiController]
    [Route("/api/meetingTopic")]
    public class RequestMeetingTopicController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _meetingRequestCrudServices;

        public RequestMeetingTopicController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _meetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet("{id}")]
        public async Task<MeetingRequest[]> GetRequestTopic(string topic)
        {
            return await _meetingRequestCrudServices.FindMeetingRequestByActivity(topic);
        }
    }
}