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
        private readonly IJwtService _JwtService;

        public RequestForMeetingController(IMeetingRequestCrudServices meetingRequestCrudServices,
            IJwtService jwtService)
        {
            _MeetingRequestCrudServices = meetingRequestCrudServices;
            _JwtService = jwtService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MeetingRequest> GetMeetingRequestByIdAsync(Guid id)
        {
            return await _MeetingRequestCrudServices
                .FindMeetingByIdAsync(id);
        }

        [HttpGet]
        [Route("getAllMeetingsRequests")]
        public async Task<MeetingRequest[]> GetAllMeetingRequests()
        {
            var token = _JwtService.GenerateToken();
            return await _MeetingRequestCrudServices
                .FindAllMeetingsAsync();
        }

        [HttpGet]
        [Route("date/{id}")]
        public async Task<MeetingRequest> GetMeetingRequestByDataAsync(DateTime id)
        {
            return await _MeetingRequestCrudServices
                .FindMeetingRequestByDataAsync(id);
        }

        [HttpGet]
        [Route("dateOlder/{id}")]
        public async Task<MeetingRequest[]> GetAllMeetingRequestByOlderDateAsync(DateTime id)
        {
            return await _MeetingRequestCrudServices
                .FindAllMeetingRequestByOlderDateAsync(id);
        }

        [HttpGet]
        [Route("dateUnsubmitOlder/{id}")]
        public async Task<MeetingRequest[]> GetAllUnsubmitMeetingRequestByOlderDateAsync(DateTime id)
        {
            return await _MeetingRequestCrudServices
                .FindAllUnsubmitMeetingRequestByOlderDateAsync(id);
        }

        [HttpGet]
        [Route("topic/{id}")]
        public async Task<MeetingRequest[]> GetRequestTopic(string topic)
        {
            return await _MeetingRequestCrudServices.FindMeetingRequestByActivity(topic);
        }

        [HttpGet]
        [Route("dataUser/{id}/unsubmit")]
        public async Task<MeetingRequest[]> GetAllUnsubmitMeetingRequestByUserIdAsync(Guid id)
        {
            return await _MeetingRequestCrudServices
                .FindUnsubmitMeetingRequestByUserId(id);
        }

        [HttpGet]
        [Route("getAllUnsubmitedRequests")]
        public async Task<MeetingRequest[]> GetAllUnsubmitMeetingRequest()
        {
            return await _MeetingRequestCrudServices
                .FindAllUnsubmitMeetingRequest();
        }
        #region
        [HttpPost]
        [Route("createMeetingRequest")]
        public async Task<MeetingRequest> CreateMeetingRequestAsync(
            MeetingRequest meetingRequest)
        {
            return await _MeetingRequestCrudServices
                .AddMeetingAsync(meetingRequest);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<MeetingRequest> UpdateMeetingRequestAsync(
            Guid id, MeetingRequest meetingRequest)
        {
            return await _MeetingRequestCrudServices
                .UpdateMeetingAsync(id, meetingRequest);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<MeetingRequest> DeleteMeetingRequestAsync(Guid id)
        {
            return await _MeetingRequestCrudServices
                .DeleteMeetingAsync(id);
        }
        #endregion

    }
}