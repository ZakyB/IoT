using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputLogger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button pressed.");
        }
    }
}