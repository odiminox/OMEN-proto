using UnityEngine;

namespace OMEN.Core.Entity
{
    public abstract class Entity : IEntity
    {
        public int id;
        public GameObject WorldObject;
        public virtual void InitialiseComponents() { }
    }
}