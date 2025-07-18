﻿using FeedbackApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
