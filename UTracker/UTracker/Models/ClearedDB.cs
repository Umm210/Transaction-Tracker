﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UTracker.Models
{
    public class ClearedDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }  // Unique identifier for each debt record
        public string DebtSource { get; set; }  // Source of the debt (e.g., Loan, Credit Card, etc.)
        public decimal DebtAmount { get; set; } // Total amount of the debt
        public DateTime DueDate { get; set; } = DateTime.Now; // Due date of the debt
        public string Notes { get; set; } // Add notes to debt

    }
}
