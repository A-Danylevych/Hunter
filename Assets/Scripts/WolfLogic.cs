using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfLogic : MonoBehaviour
{
    [SerializeField] private float lifeTime = 60f;
    private List<Seek> _seeks;
    private Coroutine _destroying;

    private void Awake()
    {
        _seeks = new List<Seek>();
    }

    private void Start()
    {
        StartCoroutine(SelfDestroying());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Water" ||
            LayerMask.LayerToName(other.gameObject.layer) == "Wolfs" ) return;
        var seek = gameObject.AddComponent<Seek>();
        seek.objectToFollow = other.gameObject.transform;
        seek.ChangeWeight(3);
        _seeks.Add(seek);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var flee = _seeks.Find(x => x.objectToFollow == other.gameObject.transform);
        _seeks.Remove(flee);
        Destroy(flee);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Rabbits" || LayerMask.LayerToName(other.gameObject.layer) == "Mooses")
        {
            Destroy(other.gameObject);
            StopCoroutine(_destroying);
            _destroying = StartCoroutine(SelfDestroying());
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Water")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestroying()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
