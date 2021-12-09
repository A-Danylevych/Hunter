using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Flash : MonoBehaviour
{
    [SerializeField] private float flashSpeed = 20f;
    [SerializeField] private float lifeTime = 1f;
    private Rigidbody2D _bulletRigidbody2D;
    private PlayerController _player;
    private Vector3 _vector;
    void Start()
    {
        _bulletRigidbody2D = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerController>();
        _vector= _player.transform.right;
    }

    void Update()
    {
        _bulletRigidbody2D.velocity = _vector * flashSpeed;
        StartCoroutine(nameof(SelfDestroying));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Animal")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private IEnumerator SelfDestroying()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
