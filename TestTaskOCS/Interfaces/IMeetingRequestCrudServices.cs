using TestTaskOCS.Entities;

namespace TestTaskOCS.Interfaces
{
    public interface IMeetingRequestCrudServices
    {
        public Task<MeetingRequest> FindMeetingByIdAsync(int id);
        public Task<MeetingRequest[]> FindAllMeetingsAsync();
        public Task<MeetingRequest> AddMeetingAsync(MeetingRequest meetingRequest);
        public Task<MeetingRequest> UpdateMeetingAsync(int id, MeetingRequest meetingRequest);
        public Task<MeetingRequest> DeleteMeetingAsync(int id);
    }
}