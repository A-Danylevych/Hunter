using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BunnyLogic : MonoBehaviour
{
    private readonly List<Flee> _flees = new List<Flee>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        var flee = gameObject.AddComponent<Flee>();
        flee.objectToFlee = other.gameObject.transform;
        flee.ChangeWeight(2);
        _flees.Add(flee);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var flee = _flees.Find(x => x.objectToFlee == other.gameObject.transform);
        _flees.Remove(flee);
        Destroy(flee);
    }
}
