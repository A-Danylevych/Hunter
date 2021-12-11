using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behavior;
using UnityEngine;

public class MooseLogic : MonoBehaviour
{
    private List<Flee> _flees;
    private List<Animal> _neighbors;
    private Separation _separation;
    private Aligment _aligment;
    private Cohesion _cohesion;
    private Animal _animal;

    private void Awake()
    {
        _flees = new List<Flee>();
        _neighbors = new List<Animal>();
        _animal = GetComponent<Animal>();
    }
    private void Start()
    {
        Flocking();
    }
    
    private void Flocking()
    {
        Separation();
        Alignment();
        Cohesion();
    }

    private void Separation()
    {
        _separation = gameObject.AddComponent<Separation>();
        _separation.neighbors = _neighbors;
        _separation.animal = _animal;
    }

    private void Alignment()
    {
        _aligment = gameObject.AddComponent<Aligment>();
        _aligment.neighbors = _neighbors;
    }
    private void Cohesion()
    {
        _cohesion = gameObject.AddComponent<Cohesion>();
        _cohesion.neighbors = _neighbors;
        _cohesion.animal = _animal;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FleeLogicEnemyEnter(other);
        NeighborEnter(other);
    }

    private void FleeLogicEnemyEnter(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Wolfs" || !other.gameObject.CompareTag("Player")) return;
        var flee = gameObject.AddComponent<Flee>();
        flee.objectToFlee = other.gameObject.transform;
        flee.ChangeWeight(10);
        _flees.Add(flee);
    }

    private void NeighborEnter(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Mooses") return;
        if (_neighbors.Contains(other.gameObject.GetComponent<Animal>())) return;
        _neighbors.Add(other.gameObject.GetComponent<Animal>());
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        FleeLogicEnemyExit(other);
        NeighborsExit(other);
    }

    private void FleeLogicEnemyExit(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Mooses") return;
        var flee = _flees.Find(x => x.objectToFlee == other.gameObject.transform);
        _flees.Remove(flee);
        Destroy(flee);
    }

    private void NeighborsExit(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) != "Mooses") return;
        _neighbors.Remove(other.gameObject.GetComponent<Animal>());
    }
    
}
