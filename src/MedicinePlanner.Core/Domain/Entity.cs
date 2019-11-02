using System;

namespace MedicinePlanner.Core.Domain
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity() {
            Id = Guid.NewGuid();
        }
    }
}