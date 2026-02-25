using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private string _horizontal = "Horizontal";
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode _skill1 = KeyCode.E;
    [SerializeField] private float _deadZone = 0.1f;

    private float _currentInput;

    public event Action Jump;
    public event Action Attack;
    public event Action KeyPressed;
    public event Action SkillOnePressed;

    public float MoveInput { get; private set; }

    private void Update()
    {
        ReadMovement();
        ReadJump();
        ReadAnyKey();
        ReadAttack();
        ReadSkillOne();
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

    private void ReadAttack()
    {
        if (Input.GetKeyDown(_attackKey))
        {
            Attack?.Invoke();
        }
    }

    private void ReadAnyKey()
    {
        if (Input.anyKeyDown)
        {
            KeyPressed?.Invoke();
        }
    }

    private void ReadSkillOne()
    {
        if (Input.GetKeyDown(_skill1))
        {
            SkillOnePressed?.Invoke();           
        }
    }
}
