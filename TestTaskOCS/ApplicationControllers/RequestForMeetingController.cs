using Microsoft.AspNetCore.Mvc;
using TestTaskOCS.CrudService;
using TestTaskOCS.Entities;

namespace TestTaskOCS.ApplicationControllers
{
    [ApiController]
    [Route("/api/")]
    public class RequestForMeetingController : ControllerBase
    {
        private readonly MeetingRequestCrudServices _MeetingRequestCrudServices;

        public RequestForMeetingController(MeetingRequestCrudServices meetingRequestCrudServices)
        {
            _MeetingRequestCrudServices = meetingRequestCrudServices;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MeetingRequest> GetMeetingRequestByIdAsync(int id) 
        {
            return await _MeetingRequestCrudServices.FindMeetingByIdAsync(id);
        }

        [HttpGet]
        public async Task<MeetingRequest[]> GetAllMeetingRequests()
        {
            return await _MeetingRequestCrudServices.FindAllMeetingsAsync();        
        }

        [HttpPost]
        public async Task<MeetingRequest> CreateMeetingRequestAsync(MeetingRequest meetingRequest)
        { 
            return await _MeetingRequestCrudServices.AddMeetingAsync(meetingRequest);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<MeetingRequest> UpdateMeetingRequestAsync(int id,MeetingRequest meetingRequest)
        {
            return await _MeetingRequestCrudServices.UpdateMeetingAsync(id,meetingRequest);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<MeetingRequest> DeleteMeetingRequestAsync(int id)
        { 
            return await _MeetingRequestCrudServices.DeleteMeetingAsync(id);
        }
    }
}