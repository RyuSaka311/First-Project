using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBox : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _input;

    [SerializeField]
    float _moveSpeed = 5f;

    Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        var dir = h * Vector2.right + v * Vector2.up;
        
        if (dir != Vector2.zero)
        {
            var velo = _rb2d.linearVelocity;
            velo = _moveSpeed * dir;
            _rb2d.linearVelocity = velo;
        }
        else
        {
            _rb2d.linearVelocity = Vector2.zero;
        }
    }
}
