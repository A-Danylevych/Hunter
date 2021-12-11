using Spawn;
using UnityEngine;

namespace Behavior
{
    public class AvoidEdges : DesiredVelocityProvider
    {
        private float edge = 0.05f;
        [SerializeField] private BoxCollider2D  ground;
        
        public override Vector3 GetDesiredVelocity()
        {
            var maxSpeed = Animal.VelocityLimit;
            var v = Animal.Velocity;

            var center = ground.offset;
            var size = ground.size;
            var position = transform.position;
            

            if (center.x +position.x - size.x >1 - edge)
            {
                return new Vector3(-maxSpeed, 0, 0);
                
            }
            if (center.x - position.x - size.x  < edge)
            {
                return new Vector3(maxSpeed, 0, 0);
            }
            if (center.y + position.y - size.y > 1 - edge)
            {
                return new Vector3(0, -maxSpeed, 0 );
            }
            if (center.y - position.y - size.y  < edge)
            {
                return new Vector3(0, maxSpeed, 0);
            }

            return v;
        }
    }
}
