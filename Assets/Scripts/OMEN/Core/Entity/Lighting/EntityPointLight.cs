using UnityEngine;

namespace OMEN.Core.Entity.Lighting
{
    public class EntityPointLight : EntityLight
    {
        public float Range;
        public float Intensity;

        public override void InitialiseComponents()
        {
            _lightType = LightType.Point;
            
            Light light = WorldObject.AddComponent<Light>();
            light.type = _lightType;
            light.range = Range;
            light.intensity = Intensity;
            light.shadows = LightShadows.Soft;
        }
    }
}