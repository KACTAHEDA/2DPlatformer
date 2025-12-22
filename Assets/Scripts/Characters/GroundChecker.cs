using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radius;

    private float _coroutineTemp = 0.2f;

    public bool IsGrounded { get; private set; }


    private void Start()
    {
        StartCoroutine(CheckGroundCoroutine());
    }

    private IEnumerator CheckGroundCoroutine()
    {
        var delay = new WaitForSeconds(_coroutineTemp);

        while (gameObject.activeInHierarchy)
        {
            IsGrounded = Physics2D.OverlapCircle(transform.position, _radius, _ground);

            yield return delay;
        }
    }
}
