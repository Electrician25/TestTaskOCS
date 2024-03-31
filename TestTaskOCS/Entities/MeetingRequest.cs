using System.ComponentModel.DataAnnotations;

namespace TestTaskOCS.Entities
{
    public class MeetingRequest
    {
        [Key]
        public Guid Id { get; set; }

        public string RequestTopic { get; set; } = null!;

        public Guid Author { get; set; }

        public DateTime Date { get; set; }

        public bool IsRequestSend { get; set; }

        [StringLength(100)]
        public string MeetingName { get; set; } = null!;

        [StringLength(300)]
        public string? MeetingDescription { get; set; }

        [StringLength(1000)]
        public string MeetingPlan { get; set; } = null!;
    }
}