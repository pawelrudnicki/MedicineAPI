using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicinePlanner.Core.Domain
{
    public class Patient
    {
        private static List<string> _bloodTypes = new List<string>
        {
            "0 rh-", "0 rh+", "a rh-", "a rh+", "b rh-", "b rh+", "ab rh-", "ab rh+"
        };
        private ISet<Medicine> _medicines = new HashSet<Medicine>();
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string BloodType { get; protected set; }
        public double Weight { get; protected set; }
        public double Height { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        
        public IEnumerable<Medicine> Medicines
        {
            get { return _medicines; }
            set { _medicines = new HashSet<Medicine>(value); }
        }

        protected Patient()
        {
        }

        public Patient(User user, int age, string bloodType, double weight, double height)
        {
            UserId = user.Id;
            Name = user.Name;
            SetAge(age);
            SetBloodType(bloodType);
            SetWeight(weight);
            SetHeight(height);
            CreatedAt = DateTime.UtcNow;
        }

        public void AddMedicine(string name, decimal price, double dosage, string accessibility)
        {
            _medicines.Add(Medicine.Create(Guid.NewGuid(), name, price, dosage, accessibility));
            UpdatedAt = DateTime.UtcNow;
        }

        public void DeleteMedicine(string name)
        {
            var medicine = Medicines.SingleOrDefault(x => x.Name == name);
            if (medicine == null)
            {
                throw new Exception($"Medicine with name: '{name}' for patient: '{Name}' was not found.");
            }
            _medicines.Remove(medicine);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetAge(int age)
        {
            if (age <= 0)
            {
                throw new Exception("Age can not be less than 1.");
            }

            if (Age == age)
            {
                return;
            }

            Age = age;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetBloodType(string bloodType)
        {
            if (string.IsNullOrWhiteSpace(bloodType))
            {
                throw new Exception("Blood type can not be empty.");
            }

            bloodType = bloodType.ToLowerInvariant();

            if (!_bloodTypes.Contains(bloodType))
            {
                throw new Exception($"Patient can not have a blood type '{bloodType}'");
            }

            BloodType = bloodType;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetWeight(double weight)
        {
            if (weight <= 0)
            {
                throw new Exception("Weight can not be less than 1.");
            }

            if (Weight == weight)
            {
                return;
            }

            Weight = weight;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetHeight(double height)
        {
            if (height <= 0)
            {
                throw new Exception("Height can not be less than 1.");
            }

            if (Height == height)
            {
                return;
            }

            Height = height;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}