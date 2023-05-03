using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float shootZoneMinY = -3f;
    public float shootZoneMaxY = -2.5f;
    public GameObject targetPrefab; // le prefab du GameObject Target
    public Animator animator; // Référence à l'Animator du cowboy

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Shot");
            // détecte si une cible est présente dans la zone de tir
            GameObject target = GetTargetInShootZone();
            if (target != null)
            {
                // détruit le GameObject Target
                
                Destroy(target);
            }
        }
    }

    GameObject GetTargetInShootZone()
    {
        // recherche tous les GameObjects ayant le tag "Target"
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        // parcourt tous les GameObjects et vérifie si l'un d'entre eux se trouve dans la zone de tir
        foreach (GameObject target in targets)
        {
            Vector3 targetPosition = target.transform.position;
            if (targetPosition.y >= shootZoneMinY && targetPosition.y <= shootZoneMaxY)
            {
                Debug.Log("Bien vu !");
                return target;
            }
        }

        // si aucun GameObject Target n'est présent dans la zone de tir, retourne null
        Debug.Log("Raté !");
        return null;
    }
}   
