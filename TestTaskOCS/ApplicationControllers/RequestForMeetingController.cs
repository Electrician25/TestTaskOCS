using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.Entities;
using TestTaskOCS.Interfaces;

namespace TestTaskOCS.ApplicationControllers
{
    [ApiController]
    [Route("/api/{controller}/")]
    public class RequestForMeetingController : ControllerBase
    {
        private readonly IMeetingRequestCrudServices _MeetingRequestCrudServices;

        public RequestForMeetingController(IMeetingRequestCrudServices meetingRequestCrudServices)
        {
            _MeetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MeetingRequest> GetMeetingRequestByIdAsync(int id)
        {
            return await _MeetingRequestCrudServices
                .FindMeetingByIdAsync(id);
        }

        [HttpGet]
        [Route("getAllMeetingsRequests")]
        public async Task<MeetingRequest[]> GetAllMeetingRequests()
        {
            return await _MeetingRequestCrudServices
                .FindAllMeetingsAsync();
        }

        [HttpPost]
        [Route("createMeetingRequest")]
        public async Task<MeetingRequest> CreateMeetingRequestAsync(
            MeetingRequest meetingRequest)
        {
            try
            {
                await _MeetingRequestCrudServices
               .AddMeetingAsync(meetingRequest);
            }

            catch { }
            return await _MeetingRequestCrudServices
                .AddMeetingAsync(meetingRequest);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<MeetingRequest> UpdateMeetingRequestAsync(
            int id, MeetingRequest meetingRequest)
        {
            return await _MeetingRequestCrudServices
                .UpdateMeetingAsync(id, meetingRequest);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<MeetingRequest> DeleteMeetingRequestAsync(int id)
        {
            return await _MeetingRequestCrudServices
                .DeleteMeetingAsync(id);
        }
    }
}