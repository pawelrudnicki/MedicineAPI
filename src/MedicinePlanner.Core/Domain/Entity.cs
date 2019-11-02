using System;

namespace MedicinePlanner.Api.Controllers
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity() {
            Id = Guid.NewGuid();
        }
    }
}