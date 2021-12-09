using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    private Vector2 moveInput;
    private Rigidbody2D playerRigidbody;
    private Collider2D playerBodyCollider;
    private bool isAlive = true;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBodyCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (!isAlive) return;
        Go();
        Die();
    }

    void OnMove(InputValue inputValue)
    {
        if (!isAlive) return;
        moveInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue inputValue)
    {
        if (!isAlive) return;
        if (inputValue.isPressed)
        {
            Fire();
        }
    }

    void Go()
    {
        float steerAmount =  moveInput.x * steerSpeed * Time.deltaTime;
        float moveAmount = moveInput.y * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(moveAmount,0, 0);
    }

    void Fire()
    {
        Debug.Log("piy-piy!!");
    }

    void Die()
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            isAlive = false;
        }
    }
}
