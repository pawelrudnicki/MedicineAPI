using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicinePlanner.Core.Domain
{
    public class Medicine
    {
        private static List <string> _accessibility = new List<string>
        {
            "high", "medium", "low"
        };
        public Guid Id { get; protected set; }
        public String Name { get; protected set; }
        public Decimal Price { get; protected set; }
        public Double Dosage { get; protected set; } //5.0 g / 80kg
        public String Accessibility { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Medicine()
        {
        }

        public Medicine(Guid id, string name, decimal price, double dosage, string accessibility)
        {
            Id = id;
            SetName(name);
            SetPrice(price);
            SetDosage(dosage);
            SetAccessibility(accessibility);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name can not be empty.");
            }

            if (Name == name) 
            {
                Name = name;
            }

            Name = name.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPrice(decimal price) 
        {
            if (Price == price)
            {
                return;
            }

            Price = price;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDosage(double dosage)
        {
            if (Dosage == dosage)
            {
                return;
            }

            Dosage = dosage;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetAccessibility(string accessibility)
        {
            if (string.IsNullOrWhiteSpace(accessibility))
            {
                Accessibility = _accessibility.FirstOrDefault();
            }

            accessibility = accessibility.ToLowerInvariant();

            if (!_accessibility.Contains(accessibility))
            {
                throw new Exception($"Medicine can not have a accessibility '{accessibility}'");
            }

            Accessibility = accessibility;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}