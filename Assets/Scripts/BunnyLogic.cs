using System;
using System.Collections;
using System.Collections.Generic;
using Behavior;
using Unity.VisualScripting;
using UnityEngine;

public class BunnyLogic : MonoBehaviour
{
    private readonly List<Flee> _flees = new List<Flee>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        var flee = gameObject.AddComponent<Flee>();
        flee.objectToFlee = other.gameObject.transform;
        flee.ChangeWeight(10);
        _flees.Add(flee);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var flee = _flees.Find(x => x.objectToFlee == other.gameObject.transform);
        _flees.Remove(flee);
        Destroy(flee);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Water") return;
        Destroy(gameObject);
    }
}
