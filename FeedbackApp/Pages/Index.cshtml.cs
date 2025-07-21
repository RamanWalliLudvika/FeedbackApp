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

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(SupportsGet = true)]
    public int PageSize { get; set; } = 10;

    public int TotalPages { get; set; }


    [BindProperty]
    public Feedback Feedback { get; set; }

    public List<Feedback> Feedbacks { get; set; }


    public async System.Threading.Tasks.Task OnGetAsync()
    {
        var totalCount = await _context.Feedbacks.CountAsync(); ;
        TotalPages = (int)Math.Ceiling((double)totalCount / PageSize);

        Feedbacks = await _context.Feedbacks
            .OrderByDescending(f => f.Date)
            .Skip((PageNumber - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

    }


    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine("[POST] OnPostAsync körs");
        _context.Feedbacks.Add(Feedback);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }
    
    //***METOD FOR ATT RENSA ALL DATA I FEEDBACKS TABELLEN***
    //public async Task<IActionResult> OnPostClearDataAsync()
    //{
    //    await _context.Database.ExecuteSqlRawAsync("DELETE FROM Feedbacks");
    //    await _context.Database.ExecuteSqlRawAsync("DELETE FROM sqlite_sequence WHERE name = 'Feedbacks'");
    //    return RedirectToPage();
    //}

}
