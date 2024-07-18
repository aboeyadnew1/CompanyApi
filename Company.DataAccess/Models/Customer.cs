﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRegistration { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();


    }
}
