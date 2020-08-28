using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Joystick joystick;

    public Vector2 GetDirection()
    {
        return new Vector3(joystick.Horizontal, joystick.Vertical);
    }
}
