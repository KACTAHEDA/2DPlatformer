using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float __smoothSpeed = 0.1f;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private bool _isFollowX = true;
    [SerializeField] private bool _isFollowY = true;

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (_player == null)
            return;

        Vector3 desiredPosition = new Vector3(
            _isFollowX ? _player.transform.position.x + _offset.x : transform.position.x,
            _isFollowY ? _player.transform.position.y + _offset.y : transform.position.y,
            transform.position.z);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, __smoothSpeed);
        transform.position = smoothPosition;
    }
}
