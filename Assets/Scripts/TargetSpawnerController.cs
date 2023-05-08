using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetSpawnData
{
    public Vector3 position; // La position de spawn de la cible
    public float spawnDelay; // Le délai avant le prochain spawn
}

public class TargetSpawnerController : MonoBehaviour
{
    public GameObject targetPrefab; // Le prefab de la cible à générer
    public List<TargetSpawnData> targetSpawnDataList; // La liste des données de spawn des cibles

    private int currentSpawnIndex = 0; // L'index de spawn actuel

    void Start()
    {
        // Démarrer la génération de cibles
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        // Vérifier si la liste des données de spawn est vide
        if (targetSpawnDataList.Count == 0)
            yield break;

        // Parcourir la liste des données de spawn
        for (int i = 0; i < targetSpawnDataList.Count; i++)
        {
            // Obtenir les données de spawn pour l'index actuel
            TargetSpawnData spawnData = targetSpawnDataList[i];

            // Générer une nouvelle cible avec les données de spawn
            Instantiate(targetPrefab, spawnData.position, Quaternion.identity);

            // Attendre le délai spécifié avant le prochain spawn
            yield return new WaitForSeconds(spawnData.spawnDelay);
        }
    }
}
