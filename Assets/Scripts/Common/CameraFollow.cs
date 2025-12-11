using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _smooth = 5f;
    [SerializeField] private Vector3 _offset;


    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (_player == null)
            return;

        transform.position = Vector3.Lerp(
            transform.position,
            _player.transform.position + _offset,
            _smooth * Time.deltaTime
            );

    }
}
