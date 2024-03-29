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

        public async Task<MeetingRequest> GetRequestById(int id)
        {
            var meet = _ApplicationContext
        }

        public async Task<MeetingRequest[]> GetAllRequests()
        {

        }

        public async Task<MeetingRequest> CreateRequest()
        {

        }

        public async Task<MeetingRequest> UpdateRequest()
        {

        }

        public async Task<MeetingRequest> DeleteRequest()
        {

        }
    }
}