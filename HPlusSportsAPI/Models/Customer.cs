﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HPlusSportsAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
