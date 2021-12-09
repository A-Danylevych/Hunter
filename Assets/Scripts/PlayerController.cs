using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D playerRigidbody;
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Go();
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue inputValue)
    {
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
        
    }
}
