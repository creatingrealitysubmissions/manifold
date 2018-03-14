using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Input_UnityEvent : MonoBehaviour
{
    public KeyCode Key;
    public UnityEvent InputEvent;

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            InputEvent.Invoke();
        }
    }
}
