using OMEN.Core.Entity;

namespace OMEN.Factory
{
    public interface IFactory
    {
        public IEntity CreateEntity(string entityName);
    }
}