using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent _onSpacePressed = new UnityEvent();

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _onSpacePressed.Invoke();
        }

    }
}
