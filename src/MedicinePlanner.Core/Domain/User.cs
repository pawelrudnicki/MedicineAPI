using System;
using System.Collections.Generic;

namespace MedicinePlanner.Core.Domain
{
    public class User
    {
        private static List<string> _roles = new List<string>
        {
            "admin", "patient", "doctor", "user"
        };
        public Guid Id { get; protected set; }
        public string Role { get; protected set; }
        public string Name { get; protected set; }
        public string FullName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User() 
        {
        }

        public User(Guid userId, string email, string password, string salt, string name, string role)
        {
            Id = userId;
            SetEmail(email);
            SetPassword(password);
            SetName(name);
            SetRole(role);
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name) 
        {
            if (string.IsNullOrWhiteSpace(name)) 
            {
                throw new Exception("Name can not be empty.");
            }

            Name = name.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email) 
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password) 
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 20) 
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }

            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role) 
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new Exception("Role can not be empty.");
            }

            role = role.ToLowerInvariant();

            if (!_roles.Contains(role))
            {
                throw new Exception($"User can not have a role '{role}'");
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}