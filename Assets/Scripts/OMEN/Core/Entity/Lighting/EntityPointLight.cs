using UnityEngine;

namespace OMEN.Core.Entity.Lighting
{
    public class EntityPointLight : EntityLight
    {
        public float Range;
        public float Intensity;

        public override void InitialiseComponents()
        {
            Light light = WorldObject.AddComponent<Light>();
            light.type = LightType.Point;
            light.range = Range;
            light.intensity = Intensity;
        }
    }
}