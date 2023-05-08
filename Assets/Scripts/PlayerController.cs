using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshProUGUI endMenuText;
    public float shootZoneMin = -3.95f;
    public float shootZoneMax = -1.55f;
    public float sweetZoneMin = -2.5f;
    public float sweetZoneMax = -3f;
    private int score = 0;
    private int chainBoost = 1;
    private NoteCallback noteCallback;
    public Animator animator; // Référence à l'Animator du cowboy

    private bool canShoot = true; // Variable pour contrôler si le joueur peut tirer

    void Start()
    {
        noteCallback = FindObjectOfType<NoteCallback>();
    }

    void Update()
    {
        int xZone = GetXZoneFromArduino();

        if (canShoot && xZone != 0)
        {
            animator.SetTrigger("Shot");
            canShoot = false; // Le joueur ne peut pas tirer pendant le délai
            StartCoroutine(ResetShootAbility()); // Lance la coroutine pour réinitialiser la possibilité de tirer

            // Détecte si une cible est présente dans la zone de tir correspondante
            GameObject target = GetTargetInShootZone(xZone);
            if (target != null)
            {
                // Détruit le GameObject Target
                Destroy(target);
            }
            xZone = 0;
        }

        scoreText.text = "Score: " + score.ToString();
        scoreText.text += "\nMultiplicateur: " + chainBoost.ToString();
        endMenuText.SetText("Score : "+score.ToString()+"\n\nTaux de tir réussi : 100%\n\nTaux de tir parfait : 100%");
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

        if (noteNumber == 50)
        {
            xZone = 3;
        }
        else if (noteNumber == 52)
        {
            xZone = 5;
        }
        else if (noteNumber == 54)
        {
            xZone = 7;
        }

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

    IEnumerator ResetShootAbility()
    {
        yield return new WaitForSeconds(0.2f); // Attendre pendant le délai de 0.1 seconde
        canShoot = true; // Réactiver la possibilité de tirer
    }
}

