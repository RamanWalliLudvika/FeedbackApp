using FeedbackApp.Data;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Feedback Feedback { get; set; }

    public List<Feedback> Feedbacks { get; set; }

    public async System.Threading.Tasks.Task OnGetAsync()
    {
        Feedbacks = await _context.Feedbacks
            .OrderByDescending(f => f.Date)
            .ToListAsync();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine("[POST] OnPostAsync körs");    
        _context.Feedbacks.Add(Feedback);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }
}
