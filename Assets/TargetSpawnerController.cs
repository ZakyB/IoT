using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnerController : MonoBehaviour
{
    public GameObject targetPrefab; // Le prefab de la cible à générer
    public float spawnInterval = 5f; // L'intervalle de temps entre chaque génération de cible
    public float minX = 3f; // La hauteur minimale de génération de la cible
    public float maxX = 7f; // La hauteur maximale de génération de la cible
    public float minY = 1f; // La hauteur minimale de génération de la cible
    public float maxY = 3f; // La hauteur maximale de génération de la cible

    void Start()
    {
        InvokeRepeating("SpawnTarget", spawnInterval, spawnInterval);
    }

    void SpawnTarget()
    {
        float randomY = Random.Range(minY, maxY);
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }
}

