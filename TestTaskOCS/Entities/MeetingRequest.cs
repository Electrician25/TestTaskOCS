using System.ComponentModel.DataAnnotations;

namespace TestTaskOCS.Entities
{
    public class MeetingRequest
    {
        [Key]
        public int Id { get; set; }
        public string RequestTopic { get; set; } = null!;

        [StringLength(100)]
        public string MeetingName { get; set; } = null!;

        [StringLength(300)]
        public string MeetinDescription { get; set; }

        [StringLength(1000)]
        public string MeetingPlan { get; set; } = null!;
    }
}