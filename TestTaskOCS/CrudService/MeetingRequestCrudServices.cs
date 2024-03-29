using Microsoft.EntityFrameworkCore;
using TestTaskOCS.Data;
using TestTaskOCS.Entities;

namespace TestTaskOCS.CrudService
{
    public class MeetingRequestCrudServices
    {
        private readonly ApplicationContext _ApplicationContext;

        public MeetingRequestCrudServices(ApplicationContext applicationContext)
        {
            _ApplicationContext = applicationContext;
        }

        public async Task<MeetingRequest> FindMeetingByIdAsync(int id)
        {
            var meet = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("An error occurred when trying to find an entity by id!");

            return meet;
        }

        public async Task<MeetingRequest[]> FindAllMeetingsAsync()
        {
            return await _ApplicationContext.MeetingRequests
                .ToArrayAsync() 
                ?? throw new Exception("An error occurred when trying to get all entities!");
        }

        public async Task<MeetingRequest> AddMeetingAsync(MeetingRequest meetingRequest)
        {
            await _ApplicationContext.MeetingRequests
                .AddAsync(meetingRequest);

            _ApplicationContext.SaveChanges();
            return meetingRequest;
        }

        public async Task<MeetingRequest> UpdateMeetingAsync(int id, MeetingRequest meetingRequest)
        {
            var currentMeetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("An error occurred while trying to update entity");

            currentMeetingRequest.RequesTopic = meetingRequest.RequesTopic;
            currentMeetingRequest.MeetingPlan = meetingRequest.MeetingPlan;
            currentMeetingRequest.MeetingName = meetingRequest.MeetingName;
            currentMeetingRequest.MeetinDescription = meetingRequest.MeetinDescription;

            _ApplicationContext.SaveChanges();
            return meetingRequest;
        }

        public async Task<MeetingRequest> DeleteMeetingAsync(int id)
        {
            var currentMeetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("An error occurred while trying to delete entity");

            _ApplicationContext.MeetingRequests.Remove(currentMeetingRequest);    
            _ApplicationContext.SaveChanges();
            return currentMeetingRequest;
        }
    }
}