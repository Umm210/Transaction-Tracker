using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UTracker.Models
{
    public class AddTransaction
    {
        public string Title { get; set; }
        public string TransactionType { get; set; } // Debit or Credit
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; } // e.g., Salary, Rent, Groceries, etc.
        public string Notes { get; set; }
    }
}

