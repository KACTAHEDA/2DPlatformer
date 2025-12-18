using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 7f;

    protected Rigidbody2D Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    public void Move(float userInput)
    {
        float direction = Mathf.Asin(userInput);
        Rigidbody.velocity = new Vector2(direction * _speed, Rigidbody.velocity.y);
    }

    public void MoveToPoint(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}
