using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : DesiredVelocityProvider
{
    [SerializeField]
    private Transform objectToFollow;

    [SerializeField, Range(0,10)]
    private float arriveRadius;

    void Start()
    {
        objectToFollow = GetComponent<>().transform;
    }
        
    public override Vector3 GetDesiredVelocity()
    {
        var distance = (objectToFollow.position - transform.position);
        float k = 1;
        if (distance.magnitude < arriveRadius)
        {
            k = distance.magnitude / arriveRadius;
        }

        return distance.normalized * Bunny.VelocityLimit * k;
    }


}
