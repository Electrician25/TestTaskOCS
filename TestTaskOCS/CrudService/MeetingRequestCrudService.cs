using Microsoft.EntityFrameworkCore;
using TestTaskOCS.Data;
using TestTaskOCS.Entities;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.CrudService
{
    public class MeetingRequestCrudService : IMeetingRequestCrudServices
    {
        private readonly ApplicationContext _applicationContext;

        public MeetingRequestCrudService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<MeetingRequest> FindMeetingByIdAsync(Guid id)
        {
            var meetingRequest = await _applicationContext.MeetingRequests.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception("Error occurred when trying to find an entity by id!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllMeetingsAsync()
        {
            return await _applicationContext.MeetingRequests.ToArrayAsync()
            ?? throw new Exception("Error occurred when trying to get all entities!");
        }

        public async Task<MeetingRequest> AddMeetingAsync(MeetingRequest meetingRequest)
        {
            if (meetingRequest == null)
            {
                throw new Exception("Error occurred when trying to add entity!");
            }

            await _applicationContext.MeetingRequests.AddAsync(meetingRequest);
            _applicationContext.SaveChanges();
            return meetingRequest;
        }

        public async Task<MeetingRequest> UpdateMeetingAsync(Guid id, MeetingRequest newMeetingRequest)
        {
            var currentMeetingRequest = await _applicationContext.MeetingRequests.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception("Error occurred while trying to update entity");

            _applicationContext.Remove(currentMeetingRequest);
            await _applicationContext.AddAsync(newMeetingRequest);
            _applicationContext.SaveChanges();
            return newMeetingRequest;
        }

        public async Task<MeetingRequest> DeleteMeetingAsync(Guid id)
        {
            var currentMeetingRequest = await _applicationContext.MeetingRequests.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception("Error occurred while trying to delete entity");

            _applicationContext.MeetingRequests.Remove(currentMeetingRequest);
            _applicationContext.SaveChanges();
            return currentMeetingRequest;
        }

        public async Task<MeetingRequest> FindMeetingRequestByDataAsync(DateTime dataTime)
        {
            var meetingRequest = await _applicationContext.MeetingRequests.FirstOrDefaultAsync(x => x.Date == dataTime)
            ?? throw new Exception("An error occurred while trying to find data!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllMeetingRequestByOlderDateAsync(DateTime olderDate)
        {
            var meetingRequest = await _applicationContext.MeetingRequests.Where(x => x.Date > olderDate).ToArrayAsync()
            ?? throw new Exception("Error when trying to find all dates older than a certain number!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllUnsubmitMeetingRequestByOlderDateAsync(DateTime olderDate)
        {
            var meetingRequest = await _applicationContext.MeetingRequests.Where(x => x.Date > olderDate && x.IsRequestSend == false).ToArrayAsync()
            ?? throw new Exception("Error when trying to find all dates older than a certain number!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindAllUnsubmitMeetingRequest()
        {
            var meetingRequest = await _applicationContext.MeetingRequests.Where(x => x.IsRequestSend == false).ToArrayAsync()
            ?? throw new Exception("Error when trying to find all unsubmited meeting requests!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindUnsubmitMeetingRequestByUserId(Guid id)
        {
            var meetingRequest = await _applicationContext.MeetingRequests.Where(x => x.Author == id && x.IsRequestSend == false).ToArrayAsync()
            ?? throw new Exception("Error when trying to find all unsubmited meeting requests by user id!");

            return meetingRequest;
        }

        public async Task<MeetingRequest[]> FindMeetingRequestByActivity(string activtity)
        {
            var meetingRequest = await _applicationContext.MeetingRequests.Where(x => x.RequestTopic == activtity).ToArrayAsync()
            ?? throw new Exception("Error when trying to find all unsubmited meeting requests by user id!");

            return meetingRequest;
        }
    }
}