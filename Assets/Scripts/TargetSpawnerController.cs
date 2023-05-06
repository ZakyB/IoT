using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnerController : MonoBehaviour
{
    public GameObject targetPrefab; // Le prefab de la cible à générer
    public float spawnInterval = 5f; // L'intervalle de temps entre chaque génération de cible
    public float leftPossibleX = 4f;
    public float middlePossibleX = 5f;
    public float rightPossibleX = 6f;
    public float minY = 1f; // La hauteur minimale de génération de la cible
    public float maxY = 3f; // La hauteur maximale de génération de la cible

    void Start()
    {
        InvokeRepeating("SpawnTarget", spawnInterval, spawnInterval);
    }

    void SpawnTarget()
    {
        float[] possibleX = { leftPossibleX, middlePossibleX, rightPossibleX };
        float randomX = possibleX[Random.Range(0, possibleX.Length)];
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }
}

