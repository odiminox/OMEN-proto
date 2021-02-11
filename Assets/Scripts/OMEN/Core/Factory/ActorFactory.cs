using System.Collections.Generic;
using OMEN.Factory;

namespace OMEN.Core.Factory
{
    public class ActorFactory : IEntityFactory
    {
        private List<Entity.Entity> actors = new List<Entity.Entity>();
        
        public Entity.Entity CreateEntityFromBsp(LibBSP.Entity bspEntity)
        {
            Entity.Entity createdEntity = null;
            string className = bspEntity.ClassName;
            
            switch (className)
            {
                case "info_player_start":
                {
                    break;
                }
            }

            return createdEntity;
        }

        public void DestroyEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        private Entity.Entity CreatePlayerInfoStart(float angle)
        {
            return null;
        }
    }
}