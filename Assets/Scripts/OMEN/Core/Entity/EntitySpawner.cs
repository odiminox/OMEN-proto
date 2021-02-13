using System;
using System.Collections;
using System.Collections.Generic;
using BSPImporter;
using OMEN.Core.Factory;
using OMEN.Factory;
using UnityEngine;

namespace OMEN.Core.Entity
{
    public class EntitySpawner
    {
        private LightFactory _lightFactory;
        private ActorFactory _actorFactory;

        public EntitySpawner()
        {
            _lightFactory = new LightFactory();
            _actorFactory = new ActorFactory();
        }
        
        public void OnEntityCreated(BSPLoader.EntityInstance instance, List<BSPLoader.EntityInstance> targets)
        {
            Entity entity = null;

            string name = instance.entity.TypeName;

            // TODO Refactor repetitive calls out to bottom.
            // TODO Every Entity should be accounted for
            switch (name)
            {
                case "light":
                {
                    entity = _lightFactory.CreateEntityFromBsp(instance.entity);
                    entity.WorldObject = instance.gameObject;
                    entity.id = instance.gameObject.GetInstanceID();
                    entity.InitialiseComponents();
                    break;
                }
                case "actor":
                {
                    entity = _actorFactory.CreateEntityFromBsp(instance.entity);
                    entity.WorldObject = instance.gameObject;
                    entity.id = instance.gameObject.GetInstanceID();
                    entity.InitialiseComponents();
                    break;
                }
                case "trigger":
                {
                    break;
                }
            }
        }
    }
}
