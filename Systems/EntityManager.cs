using PingPong.Entities;

namespace PingPong.Systems
{
    public class EntityManager<T> where T : class
    {
        private static EntityManager<T>? _instance;
        public static EntityManager<T> Instance => _instance ??= new EntityManager<T>();

        private readonly List<T> _entities = new List<T>();

        public T Add(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _entities.Remove(entity);
            return entity;
        }

        public List<T> GetAll()
        {
            return _entities;
        }

        public void Update()
        {
            foreach (var entity in _entities)
            {
                // Call draw method on entity using reflection
                entity.GetType().GetMethod("Update")?.Invoke(entity, null);
            }
        }

        public void Draw()
        {
            foreach (var entity in _entities)
            {
                // Call draw method on entity using reflection
                entity.GetType().GetMethod("Draw")?.Invoke(entity, null);
            }
        }
    }
}