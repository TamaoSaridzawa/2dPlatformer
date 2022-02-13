using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerManagement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private Vector2 moveVector;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private const string IsRun = "IsRun";

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");

        if (moveVector.x == 0)
        {
            Idle();
        }
        else
        {
            Run();
        }

        Jump();
    }

    private void Run()
    {
        if (moveVector.x < 0)
        {
            _spriteRenderer.flipX = false;
        }
        if (moveVector.x > 0)
        {
            _spriteRenderer.flipX = true;
        }
            _rigidbody2D.velocity = new Vector2(moveVector.x * _speed, _rigidbody2D.velocity.y);

            _animator.SetBool(IsRun, true);
    }

    private void Idle()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        _animator.SetBool(IsRun, false);
    }

    private void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.3f, _groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce);
        }
    }
}
