using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string _input = "Horizontal";

    public float MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        MoveInput = Input.GetAxisRaw(_input);
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
