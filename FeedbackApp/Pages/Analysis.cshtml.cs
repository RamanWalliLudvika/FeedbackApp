using FeedbackApp.Data;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Pages
{
    public class AnalysisModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Feedback> Feedbacks { get; set; }


        public double AvgWorkload { get; set; }
        public double AvgWorkDifficulty { get; set; }
        public double AvgTasksFinished { get; set; }
        public double AvgStressLevel { get; set; }
        public double AvgCooperationLevel { get; set; }
        public double AvgWorkSatisfaction { get; set; }
        public double AvgLearningTime { get; set; }
        public int TotalProblems { get; set; }

        public AnalysisModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // Hämtar alla feedback från databasen
            Feedbacks = await _context.Feedbacks.ToListAsync();

            // Beräknar antal unika arbetsbelastningar
            AvgWorkload = Math.Round(Feedbacks.Average(f => f.Workload), 1); 
            AvgWorkDifficulty = Math.Round(Feedbacks.Average(f => f.Workdifficulty),1);
            AvgTasksFinished = Math.Round(Feedbacks.Average(f => f.TasksFinished), 1);
            AvgStressLevel = Math.Round(Feedbacks.Average(f => f.StressLevel), 1);
            AvgCooperationLevel = Math.Round(Feedbacks.Average(f => f.CooperationLevel), 1);
            AvgWorkSatisfaction = Math.Round(Feedbacks.Average(f => f.WorkSatisfaction), 1);
            AvgLearningTime = Math.Round(Feedbacks.Average(f => f.LearningTime), 1);
            TotalProblems = Feedbacks.Sum(f => f.ProblemAmount);



        }
    }
}
