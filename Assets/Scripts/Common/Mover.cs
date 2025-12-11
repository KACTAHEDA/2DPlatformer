using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    protected Rigidbody2D Rigidbody;

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float move)
    {      
        Rigidbody.velocity = new Vector2(move * _speed, Rigidbody.velocity.y);
    }

    public void MoveToPoint(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}
