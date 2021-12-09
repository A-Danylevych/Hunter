using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : DesiredVelocityProvider
    {
        [SerializeField]
        private Transform objectToFollow;
        
        public override Vector2 GetDesiredVelocity()
        {
            return (objectToFollow.position - transform.position).normalized * Vehicle.VelocityLimit;
        }
    }

public class Vehicle
{
    public static float VelocityLimit { get; set; }
}
