using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.ApplicationControllers
{
    [ApiController]
    [Route("/api/meetings/")]
    public class RequestMeetingController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _meetingRequestCrudServices;

        public RequestMeetingController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _meetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet("{id}")]
        public async Task<MeetingRequest> GetMeetingRequestByIdAsync(Guid id)
        {
            return await _meetingRequestCrudServices.FindMeetingByIdAsync(id);
        }

        [HttpGet]
        public async Task<MeetingRequest[]> GetAllMeetingRequests()
        {
            return await _meetingRequestCrudServices.FindAllMeetingsAsync();
        }

        [HttpPost]
        public async Task<MeetingRequest> CreateMeetingRequestAsync(MeetingRequest meetingRequest)
        {
            return await _meetingRequestCrudServices.AddMeetingAsync(meetingRequest);
        }

        [HttpPut("{id}")]
        public async Task<MeetingRequest> UpdateMeetingRequestAsync(Guid id, MeetingRequest meetingRequest)
        {
            return await _meetingRequestCrudServices.UpdateMeetingAsync(id, meetingRequest);
        }

        [HttpDelete("{id}")]
        public async Task<MeetingRequest> DeleteMeetingRequestAsync(Guid id)
        {
            return await _meetingRequestCrudServices.DeleteMeetingAsync(id);
        }
    }
}