using System.Collections.Generic;
using OMEN.Core.Entity;
using OMEN.Core.Entity.Lighting;
using OMEN.Core.Exceptions;

namespace OMEN.Factory
{
    public class LightFactory : IEntityFactory
    {
        private List<Entity> lights = new List<Entity>();
        
        public Entity CreateEntityFromBsp(LibBSP.Entity bspEntity)
        {
            Entity createdEntity = null;
            string entityName = bspEntity.Name;
            
            switch (entityName)
            {
                case "pointlight":
                {
                    float range = bspEntity.GetFloat("range");
                    float intensity = bspEntity.GetFloat("intensity");
                    
                    createdEntity = CreatePointLight(range, intensity);
                    
                    break;
                }
                default:
                {
                    throw new FactoryInvalidType(entityName);
                }
            }
            
            lights.Add(createdEntity);
            
            return createdEntity;
        }

        public void DestroyEntity(int id)
        {
        }

        private Entity CreatePointLight(float range, float intensity)
        {
            EntityPointLight entity = new EntityPointLight
            {
                Range = range,
                Intensity = intensity
            };

            return entity;
        }
    }
}