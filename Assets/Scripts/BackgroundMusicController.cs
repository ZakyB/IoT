using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip backgroundMusic; // La musique de fond à jouer

    private AudioSource audioSource;

    void Start()
    {
        // Créer un composant AudioSource attaché à l'objet
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // Ne pas répéter la musique
        audioSource.clip = backgroundMusic;

        // Démarrer la lecture de la musique de fond
        audioSource.Play();

        // Désactiver le script une fois que la musique est terminée
        Invoke("DisableScript", backgroundMusic.length);
    }

    void DisableScript()
    {
        enabled = false;
    }
}
