using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behavior;
using UnityEngine;

public class MooseLogic : MonoBehaviour
{
    private List<Flee> _flees;
    private List<GameObject> _neighbors;
    private List<Flee> _neighborFlees;
    private List<Seek> _neighborSeeks;
    private Seek _cohesion;

    private void Awake()
    {
        _flees = new List<Flee>();
        _neighbors = new List<GameObject>();
        _neighborFlees = new List<Flee>();
    }
    private void Update()
    {
        Cohesion();
    }
    
    private void Cohesion()
    {
        Destroy(_cohesion);
        float cohesionX = 0;
        float cohesionY = 0;
        foreach (var position in _neighbors.Select(neighbor => neighbor.transform.position))
        {
            cohesionX += position.x;
            cohesionY += position.y;
        }

        cohesionX /= _neighbors.Count;
        cohesionY /= _neighbors.Count;
        var cohesion = new RectTransform();
        cohesion.position = new Vector3(cohesionX, cohesionY, 0);
        var seek = gameObject.AddComponent<Seek>();
        seek.objectToFollow = cohesion;
        seek.ChangeWeight(3);
        _cohesion = seek;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FleeLogicEnemyEnter(other);
        NeighborEnter(other);
    }

    private void FleeLogicEnemyEnter(Component other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Wolfs" || !other.gameObject.CompareTag("Player")) return;
        var flee = gameObject.AddComponent<Flee>();
        flee.objectToFlee = other.gameObject.transform;
        flee.ChangeWeight(10);
        _flees.Add(flee);
    }

    private void NeighborEnter(Component other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Mooses") return;
        Separation(other);
        Alignment(other);
        _neighbors.Add(other.gameObject);
    }

    private void Separation(Component other)
    {
        var flee = gameObject.AddComponent<Flee>();
        flee.objectToFlee = other.gameObject.transform;
        flee.ChangeWeight(5);
        _neighborFlees.Add(flee);
    }

    private void Alignment(Component other)
    {
        var seek = gameObject.AddComponent<Seek>();
        seek.objectToFollow = other.gameObject.transform;
        seek.ChangeWeight(1);
        _neighborSeeks.Add(seek);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        FleeLogicEnemyExit(other);
        NeighborsExit(other);
    }

    private void FleeLogicEnemyExit(Component other)
    {
        var flee = _flees.Find(x => x.objectToFlee == other.gameObject.transform);
        _flees.Remove(flee);
        Destroy(flee);
    }

    private void NeighborsExit(Component other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Mooses") return;
        StopSeparation(other);
        StopAlignment(other);
        _neighbors.Remove(other.gameObject);
    }

    private void StopSeparation(Component other)
    {
        var flee = _neighborFlees.Find(x => x.objectToFlee == other.gameObject.transform);
        _neighborFlees.Remove(flee);
        Destroy(flee);
    }

    private void StopAlignment(Component other)
    {
        var seek = _neighborSeeks.Find(x => x.objectToFollow == other.gameObject.transform);
        _neighborSeeks.Remove(seek);
        Destroy(seek);
    }
}
