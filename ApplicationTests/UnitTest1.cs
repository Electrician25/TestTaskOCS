using FluentAssertions;
using Moq;
using TestTaskOCS.CrudService;
using TestTaskOCS.Data;
using TestTaskOCS.Entities;

namespace ApplicationTests
{
    [TestClass]
    public class ApplicationCrudServicesTests
    {
        [TestMethod]
        public void WhenAddingNewMeetingRequest_AndRequestAlreadyExcist_ThrowException()
        {
            // Arrange.
            var meetingRequest = new MeetingRequest()
            {
                Id = 1,
                MeetingDescription = "–асскажу что нас ждет в новом релизе!",
                MeetingName = "Ќовые фичи C# vNext",
                MeetingPlan = "очень много текста... пр€мо детальный план доклада!",
                RequestTopic = "Report"
            };

            // Act.
            var mock = new Mock<ApplicationContext>();

            mock.Setup(context => context.Add(meetingRequest));

            var requestIsNotCorrect = () => new MeetingRequestCrudServices(mock.Object)
            .AddMeetingAsync(meetingRequest);

            // Assert.
            requestIsNotCorrect.Should().ThrowAsync<Exception>();
        }
    }
}