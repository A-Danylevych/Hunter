using System.Collections;
using System.Collections.Generic;
using Spawn;
using UnityEngine;

public class AvoidEdges : DesiredVelocityProvider
{
    private float edge = 0.05f;
        
    public override Vector3 GetDesiredVelocity()
    {
        var maxSpeed = Bunny.VelocityLimit;
        var v = Bunny.Velocity;
        
        // if (cam == null)
        // {
        //     return v;
        // }

        var config = GetComponent<SpawnConfigSO>();
        var point = 

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
