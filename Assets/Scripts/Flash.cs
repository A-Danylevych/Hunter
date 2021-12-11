using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Flash : MonoBehaviour
{
    [SerializeField] private float flashSpeed = 20f;
    [SerializeField] private float lifeTime = 1f;
    private Rigidbody2D _flashRigidbody2D;
    private PlayerController _player;
    private Vector3 _vector;

    void Awake()
    {
        _flashRigidbody2D = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        _vector= _player.transform.right;
        StartCoroutine(nameof(SelfDestroying));
    }

    void Update()
    {
        _flashRigidbody2D.velocity = _vector * flashSpeed;
    }

    IEnumerator SelfDestroying()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Animals")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
