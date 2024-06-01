using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    public Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool isShooting()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
