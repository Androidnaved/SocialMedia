﻿namespace SocialMedia.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Friends { get; set; } = new List<User>();
    }
}
