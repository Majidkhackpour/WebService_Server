﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_CustomerLog")]
    public class CustomerLog : ICustomerLog
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        public EnCustomerLogType Side { get; set; }
        public string Description { get; set; }
        public Guid Parent { get; set; }
        public decimal Price { get; set; }
    }
}
