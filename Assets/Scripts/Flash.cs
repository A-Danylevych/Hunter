using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private float flashSpeed = 20f;
    [SerializeField] private float lifeTime = 1f;
    private Rigidbody2D _flashRigidbody2D;
    private PlayerController _player;
    private Vector3 _vector;
    [SerializeField] private List<string> _animalsLayers = new List<string>();

    void Awake()
    {
        _flashRigidbody2D = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        _vector= _player.transform.right;
        StartCoroutine(SelfDestroying());
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
        if (_animalsLayers.Contains(LayerMask.LayerToName(other.gameObject.layer)))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
