using System;
using BSPImporter;
using UnityEngine;

namespace OMEN.Core.Entity.Actor
{
    public class ActorInfoPrefabSpawner : MonoBehaviour
    {
        public GameObject CreatePlayerStartPrefab()
        {
            var playerStartPrefab = Resources.Load("Prefabs/PlayerStart");
            var playerStartInstance = (GameObject)Instantiate(playerStartPrefab);

            if (null == playerStartInstance)
            {
               //TODO throw proper exception 
               throw new NullReferenceException("player start prefab is null");
            }

            return playerStartInstance;
        }
    }
    
    public class EntityInfoPlayerStart : EntityActor
    {
        public float Angle;
        public Vector4 Origin;
        
        public override void InitialiseComponents()
        {
            _actorType = ActorType.InfoPlayerStart;
            _angle = Angle;
            _origin = Vector4.one;

            ActorInfoPrefabSpawner spawner = WorldObject.AddComponent<ActorInfoPrefabSpawner>();
            var playerStart = spawner.CreatePlayerStartPrefab();
            
            playerStart.transform.parent = WorldObject.transform;
            playerStart.transform.localPosition = new Vector3(0, 0, 0);
            
            var quakePos = new Vector3(Origin.x, Origin.y, Origin.z);
            var convertedUnityPos = quakePos.SwizzleYZ().ScaleInch2Meter();
            WorldObject.transform.position = convertedUnityPos;

            // TODO set player rotation
            var rot = playerStart.transform.localEulerAngles;
            //playerStart.transform.localEulerAngles = new Vector3(rot.x, Angle, rot.y);
        }
    }
}