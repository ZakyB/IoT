using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    //public TextMeshProUGUI endMenuText;
    public float shootZoneMin = -3.95f;
    public float shootZoneMax = -1.55f;
    public float sweetZoneMin = -2.5f;
    public float sweetZoneMax = -3f;
    public int score = 0;
    public int totalShot = 0;
    public int totalHit = 0;
    public int totalSweet = 0;
    public int chainBoost = 1;
    private NoteCallback noteCallback;
    public Animator animator; // Référence à l'Animator du cowboy

    private bool canShoot = true; // Variable pour contrôler si le joueur peut tirer
    private int initialScore = 0;
    private int initialChainBoost = 1;
    public bool menu = false;
    private AudioSource audioSource; // Référence à l'objet AudioSource

    public AudioClip soundMIDI50; // AudioClip pour la zone 1 (par exemple)
    public AudioClip soundMIDI52; // AudioClip pour la zone 2 (par exemple)
    public AudioClip soundMIDI54; // AudioClip pour la zone 3 (par exemple)


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        noteCallback = FindObjectOfType<NoteCallback>();
    }

    void Update()
    {
        int xZone = GetXZoneFromArduino();
        //Debug.Log(jsp);
        bool jsp = GetTargetInDeadZone();
        if (jsp == true){
            chainBoost = 1;
        }
        if (canShoot && xZone != 0)
        {
            animator.SetTrigger("Shot");
            totalShot++;
            canShoot = false; // Le joueur ne peut pas tirer pendant le délai
            StartCoroutine(ResetShootAbility()); // Lance la coroutine pour réinitialiser la possibilité de tirer

            // Détecte si une cible est présente dans la zone de tir correspondante
            GameObject target = GetTargetInShootZone(xZone);
            if (target != null)
            {
                // Détruit le GameObject Target
                totalHit++;
                Destroy(target);
            }
            xZone = 0;
        }

        /*scoreText.text = "Score: " + score.ToString();
        scoreText.text += "\nMultiplicateur: " + chainBoost.ToString();*/
        scoreText.SetText("Score: " + score.ToString()+"\nMultiplicateur: " + chainBoost.ToString());
        //endMenuText.SetText("Score : "+score.ToString()+"\n\nTaux de tir réussi : 100%\n\nTaux de tir parfait : 100%");
    }

    public void ResetScore()
    {
        score = initialScore;
        chainBoost = initialChainBoost;
    }

    int GetXZoneFromArduino()
    {
        // Implémentez ici la logique pour obtenir la valeur de xZone à partir des boutons de l'Arduino
        // Vous pouvez utiliser le script NoteCallback pour écouter les événements de notes MIDI et récupérer les valeurs correspondantes
        // Par exemple, si 50 correspond à la touche J, 52 correspond à la touche K et 54 correspond à la touche L,
        // vous pouvez utiliser une variable pour stocker la valeur de xZone correspondante et la renvoyer ici

        // Exemple de logique :
        int noteNumber = noteCallback.noteNumber; // Obtient la valeur de noteNumber de NoteCallback

        int xZone = 0; // Valeur par défaut si aucun bouton n'est enfoncé
        //AudioClip audioClip;
        if (noteNumber == 50)
        {
            xZone = 3;
            audioSource.clip = soundMIDI50;
        }
        else if (noteNumber == 52)
        {
            xZone = 5;
            audioSource.clip = soundMIDI52;
            //audioClips[1].Play();
        }
        else if (noteNumber == 54)
        {
            xZone = 7;
            audioSource.clip = soundMIDI54;
            //audioClips[2].Play();
        }
        audioSource.Play();
        return xZone;
    }

    GameObject GetTargetInShootZone(int xZone)
    {
        // recherche tous les GameObjects ayant le tag "Target"
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        // parcourt tous les GameObjects et vérifie si l'un d'entre eux se trouve dans la zone de tir
        foreach (GameObject target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            if (targetPosition.y >= sweetZoneMin && targetPosition.y <= sweetZoneMax && targetPosition.x == xZone)
            {
                score += 30 * chainBoost;
                totalSweet++;
                if (chainBoost < 5)
                {
                    chainBoost++;
                }
                return target;
            }
            else if (targetPosition.y >= shootZoneMin && targetPosition.y <= shootZoneMax && targetPosition.x == xZone)
            {
                score += 10 * chainBoost;
                if (targetPosition.y < sweetZoneMin)
                {
                    chainBoost = 1;
                }
                else if (chainBoost < 5)
                {
                    chainBoost++;
                }
                return target;
            }
        }

        // si aucun GameObject Target n'est présent dans la zone de tir, retourne null
        chainBoost = 1;
        return null;
    }
    bool GetTargetInDeadZone()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            if (targetPosition.y <= -4.5f)
            {
                Destroy(target);
                Debug.Log("pouet");
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetShootAbility()
    {
        yield return new WaitForSeconds(0.2f); // Attendre pendant le délai de 0.1 seconde
        canShoot = true; // Réactiver la possibilité de tirer
        
    }
}

