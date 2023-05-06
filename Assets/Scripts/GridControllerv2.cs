using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControllerv2 : MonoBehaviour
{
    public GameObject linePrefab; // Le prefab de la ligne à générer
    public float lineOffset = 0.1f; // La distance entre les lignes et les cibles
    public TargetSpawnerController targetSpawner; // La référence au script TargetSpawnerController

    private float[] lineXPositions; // Les positions X des lignes à générer

    void Start()
    {
        // Initialise les positions X des lignes en fonction des positions des cibles
        lineXPositions = new float[]
        {
            targetSpawner.leftPossibleX - 1f,
            targetSpawner.leftPossibleX + 1f,
            targetSpawner.middlePossibleX - 1f,
            targetSpawner.middlePossibleX + 1f,
            targetSpawner.rightPossibleX - 1f,
            targetSpawner.rightPossibleX + 1f
        };

        // Génère les lignes verticales
        for (int i = 0; i < lineXPositions.Length; i++)
        {
            Vector3 linePosition = new Vector3(lineXPositions[i], 0f, 0f);
            GameObject line = Instantiate(linePrefab, linePosition, Quaternion.identity);
            line.transform.parent = transform;
            line.transform.localScale = new Vector3(0.1f, 10f, 1f); // Ajuste la taille de la ligne
        }
    }
}
