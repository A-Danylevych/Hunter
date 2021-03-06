using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject flash;
    [SerializeField] private Transform gun;
    [SerializeField, Range(0, 100)] private int filmCount = 10;
    private Vector2 _moveInput;
    private Rigidbody2D _playerRigidbody;
    private BoxCollider2D _playerBodyCollider;
    private bool _isAlive = true;
    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerBodyCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (!_isAlive)
        {
            Reload();
            return;
        }
        Go();
    }

    void OnMove(InputValue inputValue)
    {
        if (!_isAlive) return;
        _moveInput = inputValue.Get<Vector2>();
    }
    
    void OnFire(InputValue inputValue)
    {
        if (!_isAlive) return;
        if (filmCount == 0) return;
        Instantiate(flash, gun.position, transform.rotation);
        filmCount--;
    }

    void Go()
    {
        var steerAmount =  _moveInput.x * steerSpeed * Time.deltaTime;
        var moveAmount = _moveInput.y * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(moveAmount,0, 0);
    }
    void Reload()
    {
        SceneManager.LoadScene("UI");
    }
}
