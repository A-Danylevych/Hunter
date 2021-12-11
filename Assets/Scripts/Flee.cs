using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : DesiredVelocityProvider
{
    private Transform _objectToFlee;
        
    void Start()
    {
        _objectToFlee = FindObjectOfType<PlayerController>().transform;
    }
    
    public override Vector3 GetDesiredVelocity()
    {
        return -(_objectToFlee.position - transform.position).normalized * Bunny.VelocityLimit;
    }
}
