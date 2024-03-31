using TestTaskOCS.Entities;

namespace TestTaskOCS.MeetingRequestInterface
{
    public interface IMeetingRequestCrudServices
    {
        public Task<MeetingRequest> FindMeetingByIdAsync(Guid id);
        public Task<MeetingRequest[]> FindAllMeetingsAsync();
        public Task<MeetingRequest> AddMeetingAsync(MeetingRequest meetingRequest);
        public Task<MeetingRequest> UpdateMeetingAsync(Guid id, MeetingRequest meetingRequest);
        public Task<MeetingRequest> DeleteMeetingAsync(Guid id);
        public Task<MeetingRequest> FindMeetingRequestByDataAsync(DateTime dataTime);
        public Task<MeetingRequest[]> FindAllMeetingRequestByOlderDateAsync(DateTime olderDate);
        public Task<MeetingRequest[]> FindAllUnsubmitMeetingRequestByOlderDateAsync(DateTime olderDate);
        public Task<MeetingRequest[]> FindAllUnsubmitMeetingRequest();
        public Task<MeetingRequest[]> FindUnsubmitMeetingRequestByUserId(Guid id);
        public Task<MeetingRequest[]> FindMeetingRequestByActivity(string activtity);
    }
}