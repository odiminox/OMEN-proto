using System.Collections.Generic;
using OMEN.Core.Entity.Actor;
using OMEN.Factory;
using UnityEngine;

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
                    var position = bspEntity.GetVector("origin");
                    var angle = bspEntity.GetInt("angle");

                    createdEntity = CreatePlayerInfoStart(angle, position);
                    break;
                }
            }

            return createdEntity;
        }

        public void DestroyEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        private Entity.Entity CreatePlayerInfoStart(float angle, Vector4 origin)
        {
            EntityInfoPlayerStart entity = new EntityInfoPlayerStart()
            {
                Angle = angle,
                Origin = origin
            };
            
            return entity;
        }
    }
}