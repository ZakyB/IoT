using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public TextMeshPro scoreText;
    public float shootZoneMin = -3.95f;
    public float shootZoneMax = -1.55f;
    public float sweetZoneMin = -2.5f;
    public float sweetZoneMax = -3f;
    private int score = 0;
    private int chainBoost = 1;
    public Animator animator; // Référence à l'Animator du cowboy

    void Update()
    {
        int xZone = 0;
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            xZone = 3;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            xZone = 5;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            xZone = 7;
        }
        
        if (xZone != 0)
        {
            animator.SetTrigger("Shot");
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
                score += 30*chainBoost;
                if(chainBoost<5){
                    chainBoost++;
                }
                return target;
            } else if (targetPosition.y >= shootZoneMin && targetPosition.y <= shootZoneMax && targetPosition.x == xZone)
            {
                score += 10*chainBoost;
                if (targetPosition.y < sweetZoneMin)
                {
                    chainBoost = 1;
                } else if(chainBoost<5)
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
}   
