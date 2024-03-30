using Microsoft.EntityFrameworkCore;
using TestTaskOCS.Data;
using TestTaskOCS.Entities;
using TestTaskOCS.Interfaces;

namespace TestTaskOCS.CrudService
{
    public class MeetingRequestCrudServices : IMeetingRequestCrudServices
    {
        private readonly ApplicationContext _ApplicationContext;

        public MeetingRequestCrudServices(ApplicationContext applicationContext)
        {
            _ApplicationContext = applicationContext;
        }

        public async Task<MeetingRequest> FindMeetingByIdAsync(int id)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("An error occurred when trying to find an entity by id!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllMeetingsAsync()
        {
            return await _ApplicationContext.MeetingRequests
                .ToArrayAsync()
                ?? throw new Exception("An error occurred when trying to get all entities!");
        }

        public async Task<MeetingRequest> AddMeetingAsync(MeetingRequest meetingRequest)
        {
            if (meetingRequest == null)
                throw new Exception("An error occurred when trying to add entity!");

            try
            {
                await _ApplicationContext.MeetingRequests
               .AddAsync(meetingRequest);
            }
            catch { }

            _ApplicationContext.SaveChanges();
            return meetingRequest;
        }

        public async Task<MeetingRequest> UpdateMeetingAsync(int id, MeetingRequest newMeetingRequest)
        {
            var currentMeetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("An error occurred while trying to update entity");

            currentMeetingRequest.RequestTopic = newMeetingRequest.RequestTopic;
            currentMeetingRequest.MeetingPlan = newMeetingRequest.MeetingPlan;
            currentMeetingRequest.MeetingName = newMeetingRequest.MeetingName;
            currentMeetingRequest.MeetingDescription = newMeetingRequest.MeetingDescription;

            _ApplicationContext.SaveChanges();
            return newMeetingRequest;
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