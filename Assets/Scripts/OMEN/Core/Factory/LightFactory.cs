using System.Collections.Generic;
using OMEN.Core.Entity.Lighting;
using OMEN.Core.Exceptions;
using OMEN.Factory;

namespace OMEN.Core.Factory
{
    public class LightFactory : IEntityFactory
    {
        private List<Entity.Entity> lights = new List<Entity.Entity>();
        
        // TODO exception handling
        public Entity.Entity CreateEntityFromBsp(LibBSP.Entity bspEntity)
        {
            Entity.Entity createdEntity = null;
            string entityName = bspEntity.Name;
            var lighttype = bspEntity.GetInt("lighttype");
            
            switch (lighttype)
            {
                // Default, currently unused
                case 0:
                {
                    break;
                }
                // point light
                case 1:
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

        private Entity.Entity CreatePointLight(float range, float intensity)
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