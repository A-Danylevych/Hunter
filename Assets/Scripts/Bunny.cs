using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Bunny : MonoBehaviour
    {
    private Vector2 velocity;
    private Vector2 acceleration;
    [SerializeField]
    private float mass = 1;
    
    [SerializeField, Range(1, 20)]
    private float steeringForceLimit = 5;
    private float velocityLimit = 3;
    private const float Epsilon = 0.01f;
    public float VelocityLimit => velocityLimit;
    public void ApplyForce(Vector2 force)
    {
        force /= mass;
        acceleration += force;
    }
    private void Update()
    {
        ApplyFriction();
        
        ApplyForces();
        
        ApplySteeringForce();

        void ApplyFriction()
        {
            var friction = -velocity.normalized * 0.5f;
            ApplyForce(friction);
        }
        void ApplyForces()
        {
            velocity += acceleration * Time.deltaTime;
        
            //limit velocity
            velocity = Vector2.ClampMagnitude(velocity, velocityLimit);
            //on small values object might start to blink, so we considering 
            //small velocities as zeroes
            if (velocity.magnitude < Epsilon)
            {
                velocity = Vector3.zero;
                return;
            }
        
            transform.position += velocity * Time.deltaTime;
            acceleration = Vector2.zero;
            transform.rotation = Quaternion.LookRotation(velocity);
        }
        void ApplySteeringForce()
            {
                var provider = GetComponent<DesiredVelocityProvider>();
                if (provider == null)
                {
                    return;
                }

                var desiredVelocity = provider.GetDesiredVelocity();
                var steeringForce = Vector2.ClampMagnitude(desiredVelocity - velocity, steeringForceLimit);
                ApplyForce(steeringForce);   
            }

    }    
}

internal class DesiredVelocityProvider
{
    public Vector3 GetDesiredVelocity()
    {
        throw new System.NotImplementedException();
    }

    public int Weight { get; set; }
}
