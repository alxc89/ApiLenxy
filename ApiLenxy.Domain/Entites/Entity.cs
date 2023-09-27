using ApiLenxy.Domain.Notifications;

namespace ApiLenxy.Domain.Entites
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    
        protected void SetId(Guid id) 
        {
            Id = id;
        }
    }
}
