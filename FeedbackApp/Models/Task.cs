using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Models
{
    public class Task
    {
        public int TaskID { get; set; }

        public string? Tasktitle { get; set; }

        public double HoursSpent { get; set; }

        public int Priority { get; set; }


        [Range(0, 1, ErrorMessage = "Completion percentage must be between 0 and 1.")]
        public double Completionpercentage { get; set; }

        public string? Notes { get; set; }

        public Feedback? Feedback { get; set; }

        public User? User { get; set; }
    }
}
