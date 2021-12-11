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

            var center = ground.offset;
            var size = ground.size;
            var position = transform.position;
            

            if (Mathf.Abs(center.x -position.x) > size.x/2 - edge)
            {
                return new Vector3(-maxSpeed, 0, 0);
                
            }
            if (Mathf.Abs(center.x -position.x) < edge)
            {
                return new Vector3(maxSpeed, 0, 0);
            }
            if (Mathf.Abs(center.y -position.y) > size.y/2 - edge)
            {
                return new Vector3(0, -maxSpeed, 0 );
            }
            if (Mathf.Abs(center.y -position.y) < edge)
            {
                return new Vector3(0, maxSpeed, 0);
            }

            return Vector3.zero;
        }
    }
}
