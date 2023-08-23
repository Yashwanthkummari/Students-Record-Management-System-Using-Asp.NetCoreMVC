﻿using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace StudentsRecordManagementSystem.Models
{
    public class Students
    {
        public int Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Mobile { set; get; }
        public string Address { set; get; }
    }
}
