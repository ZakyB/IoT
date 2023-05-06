using UnityEngine;
using System.Collections;
using MidiJack;

public class MidiInput : MonoBehaviour
{
    void Update()
    {
        if (MidiMaster.GetKeyDown(60)) // La touche 60 est Do central
        {
            Debug.Log("Do central a été appuyé !");
        }
    }
}
