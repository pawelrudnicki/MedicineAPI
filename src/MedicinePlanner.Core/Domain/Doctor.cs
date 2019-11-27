using System;

namespace MedicinePlanner.Core.Domain
{
    public class Doctor
    {
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public string Specialization { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Doctor()
        {
        }

        public Doctor(User user, string specialization)
        {
            UserId = user.Id;
            Name = user.Name;
            SetSpecialization(specialization);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetSpecialization(string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization)) 
            {
                throw new Exception("Specialization can not be empty.");
            }

            if (Specialization == specialization) 
            {
                return;
            }

            Specialization = specialization.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
    }
}