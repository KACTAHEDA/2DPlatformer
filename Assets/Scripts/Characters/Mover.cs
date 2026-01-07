using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private float _minToMove = 0.05f;

    private Rigidbody2D _rigidbody;

    public bool IsMoveing { get; private set; }
    public float Direction { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IsMoveing = MathF.Abs(_rigidbody.velocity.x) > _minToMove;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Move(float direction)
    {
        Direction = Mathf.Sign(direction);
        _rigidbody.velocity = new Vector2(Direction * _speed, _rigidbody.velocity.y);
    }

    public void Stop()
    {
        Direction = 0f;
        _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
    }
}
