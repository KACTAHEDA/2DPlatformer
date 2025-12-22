using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string _horizontal = "Horizontal";
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private float _deadZone = 0.1f;

    private float _currentInput;

    public float MoveInput { get; private set; }

    public event Action Jump;
    public event Action KeyPressed;

    private void Update()
    {
        ReadMovement();
        ReadJump();
        ReadAnyKey();
    }

    private void ReadMovement()
    {
        _currentInput = Input.GetAxisRaw(_horizontal);
        MoveInput = Mathf.Abs(_currentInput) < _deadZone ? 0f : _currentInput;
    }

    private void ReadJump()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            Jump?.Invoke();
        }
    }

    private void ReadAnyKey()
    {
        if (Input.anyKeyDown)
        {
            KeyPressed?.Invoke();
        }
    }
}
