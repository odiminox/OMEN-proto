using OMEN.Core.Entity;

namespace OMEN.Factory
{
    public interface IEntityFactory
    {
        public Entity CreateEntityFromBsp(LibBSP.Entity bspEntity);
        public void DestroyEntity(int id);
    }
}