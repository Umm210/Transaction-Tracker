using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace UTracker.Models
{
    public class AddTransactionsDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }  // Unique identifier
        public string Title { get; set; } // Title of the transaction
        public string TransactionType { get; set; } // Debit or Credit
        public decimal Amount { get; set; } // Transaction Amount
        public DateTime Date { get; set; } // Transaction Date
        public string Category { get; set; } // Transaction Category
        public string Notes { get; set; } // Transaction Notes
        public string Custom { get; set; } // Custom Category
    }
}

