using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using UTracker.Models;

namespace UTracker.Models

{
    public class UserService
    {
        private readonly SQLiteAsyncConnection _database;

        public UserService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<TransactionsDB>().Wait();
            _database.CreateTableAsync<DebtDB>().Wait();
            _database.CreateTableAsync<ClearedDB>().Wait();
        }

        // Register User
        public Task<int> RegisterUser(User user)
        {
            return _database.InsertAsync(user);
        }

        // Get User Data
        public Task<User> GetUser(string username, string password)
        {
            return _database.Table<User>()
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();
        }

        // Insert Transaction into the DB
        public Task<int> AddTransaction(TransactionsDB transaction)  // New method for adding transactions
        {
            return _database.InsertAsync(transaction);
        }

        // Get Transaction Data
        public Task<List<TransactionsDB>> GetAllTransactions()
        {
            return _database.Table<TransactionsDB>().ToListAsync();
        }

        // Deleting All Transactions
        public Task<int> DeleteAllTransactions()
        {
            return _database.DeleteAllAsync<TransactionsDB>();
        }

        // Delete Transaction
        public Task<int> DeleteTransaction(TransactionsDB transaction)
        {
            return _database.DeleteAsync(transaction);
        }

        // Update Debt
        public Task<int> UpdateDebt(DebtDB updatedDebt)
        {
            return _database.UpdateAsync(updatedDebt);
        }


        // Insert Debt into DB
        public Task<int> DebtDB(DebtDB debt)  // Corrected method to add debt
        {
            return _database.InsertAsync(debt);  // This should now insert AddDebt records
        }

        // Get Debt Data
        public Task<List<DebtDB>> GetAllDebts()
        {
            return _database.Table<DebtDB>().ToListAsync();  // This fetches AddDebt records
        }

        // Add Cleared Debt
        public Task<int> AddClearedDebt(ClearedDB clearedDebt)
        {
            return _database.InsertAsync(clearedDebt);
        }

        // Delete Debt
        public Task<int> DeleteDebt(int debtId)
        {
            return _database.Table<DebtDB>()
                .Where(d => d.Id == debtId)
                .DeleteAsync();
        }

        // Get Cleared Debt Data
        public Task<List<ClearedDB>> GetAllClearedDebts()
        {
            return _database.Table<ClearedDB>().ToListAsync();
        }
    }
}

