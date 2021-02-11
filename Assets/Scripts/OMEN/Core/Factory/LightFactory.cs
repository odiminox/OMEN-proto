using System.Collections.Generic;
using OMEN.Core.Entity.Lighting;
using OMEN.Core.Exceptions;
using OMEN.Factory;
using UnityEngine;

namespace OMEN.Core.Factory
{
    public class LightFactory : IEntityFactory
    {
        private List<Entity.Entity> lights = new List<Entity.Entity>();
        
        // TODO exception handling
        public Entity.Entity CreateEntityFromBsp(LibBSP.Entity bspEntity)
        {
            Entity.Entity createdEntity = null;
            string className = bspEntity.ClassName;
            
            switch (className)
            {
                case "point_light":
                {
                    float range = bspEntity.GetFloat("range");
                    float intensity = bspEntity.GetFloat("intensity");
                    
                    createdEntity = CreatePointLight(range, intensity);
                    
                    break;
                }
                default:
                {
                    throw new FactoryInvalidType(className);
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