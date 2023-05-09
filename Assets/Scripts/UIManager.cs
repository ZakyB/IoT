using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
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
}

