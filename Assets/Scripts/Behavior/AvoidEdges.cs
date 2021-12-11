using Spawn;
using UnityEngine;

namespace Behavior
{
    public class AvoidEdges : DesiredVelocityProvider
    {
        private float edge = 0.05f;
        
        public override Vector3 GetDesiredVelocity()
        {
            var maxSpeed = Animal.VelocityLimit;
            var v = Animal.Velocity;
        
            var config = GetComponent<SpawnConfigSO>();
            var point = new Vector2();

            if (point.x > 1 - edge)
            {
                return new Vector3(-maxSpeed, 0, 0);
                
            }
            if (point.x < edge)
            {
                return new Vector3(maxSpeed, 0, 0);
            }
            if (point.y > 1 - edge)
            {
                return new Vector3(0, 0, -maxSpeed);
            }
            if (point.y < edge)
            {
                return new Vector3(0, 0, maxSpeed);
            }

            return v;
        }
    }
}
