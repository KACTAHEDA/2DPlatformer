using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _smoothTime = 0.1f;

    private float _currentInput;
    private float _inputVelocity;

    public float MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        float rawInput = Input.GetAxisRaw("Horizontal");

        _currentInput = Mathf.SmoothDamp(
            _currentInput,
            rawInput,
            ref _inputVelocity,
            _smoothTime
        );

        MoveInput = _currentInput;
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
