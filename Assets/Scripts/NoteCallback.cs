using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using System.Collections;
using System.Collections.Generic;

// NoteCallback.cs - This script shows how to define a callback to get notified
// on MIDI note-on/off events.

public class NoteCallback : MonoBehaviour
{
    public int noteNumber = 0;
    public float resetDelay = 0.1f; // Délai de réinitialisation en secondes
    private Coroutine resetCoroutine;

    private static NoteCallback instance; // Instance unique de NoteCallback

    private void Awake()
    {
        // Vérifier s'il y a déjà une instance de NoteCallback
        if (instance == null)
        {
            // Si ce n'est pas le cas, définir cette instance comme l'instance unique
            instance = this;
            DontDestroyOnLoad(gameObject); // Rendre l'objet persistant
        }
        else
        {
            // S'il y a déjà une instance de NoteCallback, détruire cet objet
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            Debug.Log(resetDelay);
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) =>
            {
                noteNumber = note.noteNumber;
                Debug.Log(noteNumber);

            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
            }

            resetCoroutine = StartCoroutine(ResetNoteNumber());

            };
        };
    }

    private IEnumerator ResetNoteNumber()
    {
        yield return new WaitForSeconds(resetDelay);
        noteNumber = 0;
    }

    private void OnDestroy()
    {
        // Arrêter la coroutine lors de la destruction de l'objet
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }
    }
}
