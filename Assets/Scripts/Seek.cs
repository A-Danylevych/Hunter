using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : DesiredVelocityProvider
    {
        [SerializeField]
        private Transform objectToFollow;

        void Awake()
        {
            objectToFollow = GetComponent<PlayerController>().transform;
        }

        public override Vector2 GetDesiredVelocity()
        {
            return (objectToFollow.position - transform.position).normalized * Vehicle.VelocityLimit;
        }
    }

public class Vehicle
{
    public static float VelocityLimit
    {
        get => 200;
        private set => VelocityLimit = value;
    } 
}
