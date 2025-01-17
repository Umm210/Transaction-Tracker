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
            _database.CreateTableAsync<AddTransaction>().Wait();
            _database.CreateTableAsync<AddDebt>().Wait();
        }

        public Task<int> RegisterUser(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUser(string username, string password)
        {
            return _database.Table<User>()
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();
        }

        public Task<int> AddTransaction(AddTransaction transaction)  // New method for adding transactions
        {
            return _database.InsertAsync(transaction);
        }

        public Task<List<AddTransaction>> GetAllTransactions()
        {
            return _database.Table<AddTransaction>().ToListAsync();
        }

        public Task<int> DeleteAllTransactions()
        {
            return _database.DeleteAllAsync<AddTransaction>();
        }


        public Task<int> AddDebt(AddDebt debt)  // Corrected method to add debt
        {
            return _database.InsertAsync(debt);  // This should now insert AddDebt records
        }

        public Task<List<AddDebt>> GetAllDebts()
        {
            return _database.Table<AddDebt>().ToListAsync();  // This fetches AddDebt records
        }

    }
}

