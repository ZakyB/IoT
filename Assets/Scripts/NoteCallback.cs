using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// NoteCallback.cs - This script shows how to define a callback to get notified
// on MIDI note-on/off events.

sealed class NoteCallback : MonoBehaviour
{
    public int noteNumber;
    private float resetDelay = 0.1f; // Délai de réinitialisation en secondes

    private void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null){
                Debug.Log("pouet");
                return;
            } else {
                Debug.Log("prout");
            }

            midiDevice.onWillNoteOn += (note, velocity) =>
            {
                Debug.Log("prout");
                noteNumber = note.noteNumber;
                Debug.Log(noteNumber);

                StartCoroutine(ResetNoteNumber());
            };
        };
    }

    private System.Collections.IEnumerator ResetNoteNumber()
    {
        yield return new WaitForSeconds(resetDelay);
        noteNumber = 0;
    }
}
