using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Flee : DesiredVelocityProvider
{
    public Transform objectToFlee;

    public override Vector3 GetDesiredVelocity()
    {
        return -(objectToFlee.position - transform.position).normalized * Animal.VelocityLimit;
    }
    
}
