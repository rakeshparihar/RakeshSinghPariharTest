using UnityEngine;

public class InputController : IInput
{
    public float SideMovement { get { return Input.GetAxis("Horizontal"); } }

    public float ForwardMovement { get { return Input.GetAxis("Vertical"); } }
}
