using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private Quaternion _lookAtRight;
    private Quaternion _lookAtLeft;

    private void Awake()
    {
        _lookAtRight = transform.localRotation;
        Vector3 invertedForvard = -transform.right;
        _lookAtLeft = Quaternion.FromToRotation(transform.right, invertedForvard) * _lookAtRight;

    }

    public void Rotate(float direction)
    {
        if (direction == 0)
            return;

        if (direction > 0 && transform.localRotation != _lookAtRight)
            transform.localRotation = _lookAtRight;
        else if (direction < 0 && transform.localRotation != _lookAtLeft)
            transform.localRotation = _lookAtLeft;
    }
}
