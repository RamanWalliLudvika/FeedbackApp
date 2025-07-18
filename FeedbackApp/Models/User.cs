﻿namespace FeedbackApp.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }

        public ICollection<Task>? Tasks { get; set; }


    }
}
