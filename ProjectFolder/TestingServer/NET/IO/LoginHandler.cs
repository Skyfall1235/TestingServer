using System.Globalization;
using System.Text.Json;


namespace TestingServer.NET.IO
{
    internal class LoginHandler
    {
        const string FILEPATH = "Data/users.json";
        private readonly Dictionary<string, string> _users = new();
        private readonly object _lock = new();

        /// <summary>
        /// Load users from a file at startup.
        /// </summary>
        public void LoadFromFile()
        {
            if (!File.Exists(FILEPATH)) return;

            var lines = File.ReadAllLines(FILEPATH);
            lock (_lock)
            {
                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        _users[parts[0]] = parts[1];
                    }
                }
            }
        }

        /// <summary>
        /// Save all users to a file.
        /// </summary>
        public void SaveToFile()
        {
            lock (_lock)
            {
                var lines = _users.Select(kvp => $"{kvp.Key}:{kvp.Value}");
                File.WriteAllLines(FILEPATH, lines);
            }
        }

        /// <summary>
        /// Registers a new user. Returns false if the username already exists.
        /// </summary>
        public Task<bool> RegisterUserAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return Task.FromResult(false);

            lock (_lock)
            {
                if (_users.ContainsKey(username))
                    return Task.FromResult(false);

                _users[username] = password; // no hashing, as requested
            }

            return Task.FromResult(true);
        }

        /// <summary>
        /// Validates a user's credentials.
        /// </summary>
        public Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            lock (_lock)
            {
                return Task.FromResult(_users.TryGetValue(username, out var storedPassword) && storedPassword == password);
            }
        }
    }
}
