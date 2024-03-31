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

        public async Task<MeetingRequest> FindMeetingByIdAsync(Guid id)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Error occurred when trying to find an entity by id!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllMeetingsAsync()
        {
            return await _ApplicationContext.MeetingRequests.ToArrayAsync()
                ?? throw new Exception("Error occurred when trying to get all entities!");
        }

        public async Task<MeetingRequest> AddMeetingAsync(MeetingRequest meetingRequest)
        {
            if (meetingRequest == null)
                throw new Exception("Error occurred when trying to add entity!");

            try
            {
                await _ApplicationContext.MeetingRequests
               .AddAsync(meetingRequest);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            _ApplicationContext.SaveChanges();
            return meetingRequest;
        }

        public async Task<MeetingRequest> UpdateMeetingAsync(Guid id, MeetingRequest newMeetingRequest)
        {
            var currentMeetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Error occurred while trying to update entity");

            currentMeetingRequest.MeetingDescription = newMeetingRequest.MeetingDescription;
            currentMeetingRequest.RequestTopic = newMeetingRequest.RequestTopic;
            currentMeetingRequest.MeetingPlan = newMeetingRequest.MeetingPlan;
            currentMeetingRequest.MeetingName = newMeetingRequest.MeetingName;

            _ApplicationContext.SaveChanges();
            return newMeetingRequest;
        }

        public async Task<MeetingRequest> DeleteMeetingAsync(Guid id)
        {
            var currentMeetingRequest = await _ApplicationContext.MeetingRequests
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Error occurred while trying to delete entity");

            _ApplicationContext.MeetingRequests.Remove(currentMeetingRequest);
            _ApplicationContext.SaveChanges();
            return currentMeetingRequest;
        }

        public async Task<MeetingRequest> FindMeetingRequestByDataAsync(DateTime dataTime)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests.
                FirstOrDefaultAsync(x => x.Date == dataTime)
                ?? throw new Exception("An error occurred while trying to find data!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllMeetingRequestByOlderDateAsync(DateTime olderDate)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests
                .Where(x => x.Date > olderDate).ToArrayAsync()
                ?? throw new Exception("Error when trying to find all dates older than a certain number!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllUnsubmitMeetingRequestByOlderDateAsync(DateTime olderDate)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests
                .Where(x => x.Date > olderDate && x.IsRequestSend == false).ToArrayAsync()
                ?? throw new Exception("Error when trying to find all dates older than a certain number!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllUnsubmitMeetingRequest()
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests
                .Where(x => x.IsRequestSend == false).ToArrayAsync()
                ?? throw new Exception("Error when trying to find all unsubmited meeting requests!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindUnsubmitMeetingRequestByUserId(Guid id)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests.
                Where(x => x.Author == id && x.IsRequestSend == false).ToArrayAsync()
                ?? throw new Exception("Error when trying to find all unsubmited meeting requests by user id!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindMeetingRequestByActivity(string activtity)
        {
            var meetingRequest = await _ApplicationContext.MeetingRequests.
                    Where(x => x.RequestTopic == activtity).ToArrayAsync()
                    ?? throw new Exception("Error when trying to find all unsubmited meeting requests by user id!");

            return meetingRequest;
        }
    }
}