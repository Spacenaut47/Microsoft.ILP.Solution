using Microsoft.ILP.UserService.Models;
using System.Text.Json;

namespace Microsoft.ILP.UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _filePath = "Data/users.json";

        public List<User> GetAllUsers()
        {
            if (!File.Exists(_filePath)) return new List<User>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public User GetUserById(int id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            var users = GetAllUsers();
            users.Add(user);
            SaveUsers(users);
        }

        public void UpdateUser(User user)
        {
            var users = GetAllUsers();
            var index = users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                users[index] = user;
                SaveUsers(users);
            }
        }

        public void DeleteUser(int id)
        {
            var users = GetAllUsers();
            var updated = users.Where(u => u.Id != id).ToList();
            SaveUsers(updated);
        }

        public int GetNextUserId()
        {
            var users = GetAllUsers();
            return users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
        }

        private void SaveUsers(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory("Data");
            File.WriteAllText(_filePath, json);
        }
    }
}
