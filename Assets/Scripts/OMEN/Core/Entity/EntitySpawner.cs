using System.Collections;
using System.Collections.Generic;
using BSPImporter;
using OMEN.Factory;
using UnityEngine;

namespace OMEN.Core.Entity
{
    public class EntitySpawner
    {
        private LightFactory _lightFactory;

        public EntitySpawner()
        {
            _lightFactory = new LightFactory();
        }
        
        public void OnEntityCreated(BSPLoader.EntityInstance instance, List<BSPLoader.EntityInstance> targets)
        {
            Entity entity = null;
            
            switch (instance.entity.ClassName)
            {
                case "light":
                {
                    entity = _lightFactory.CreateEntityFromBsp(instance.entity);
                    entity.WorldObject = instance.gameObject;
                    entity.id = instance.gameObject.GetInstanceID();
                    entity.InitialiseComponents();
                    break;
                }
            }
        }
    }
}
