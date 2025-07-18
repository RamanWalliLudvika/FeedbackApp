namespace FeedbackApp.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }

        public string? Title { get; set; }

        public int Workload { get; set; }

        public int Workdifficulty{ get; set; }

        public int TasksFinished { get; set; }

        public int StressLevel { get; set; }

        public int CooperationLevel { get; set; }

        public int WorkSatisfaction { get; set; }

        public double LearningTime { get; set; }

        public int ProblemAmount { get; set; }

        public string? WeeklySummary { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public User? User { get; set; }

        public ICollection<Task>? Tasks { get; set; }


    }
}
