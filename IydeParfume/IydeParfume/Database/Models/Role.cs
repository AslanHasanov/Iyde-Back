﻿using IydeParfume.Database.Models.Common;

namespace IydeParfume.Database.Models
{
    public class Role :BaseEntity<int>, IAuditable
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<User> Users { get; set; }
    }
}
