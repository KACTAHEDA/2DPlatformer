using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radius;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, _radius, _ground); 
    }
}
