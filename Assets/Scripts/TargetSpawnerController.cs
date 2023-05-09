using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public Canvas endGameCanvas;
    public RectTransform endGamePanel;
    public EndMenuController endMenuController; // Référence au EndMenuController
    public int targetCount = 0;

    private int currentSpawnIndex = 0; // L'index de spawn actuel

    void Start()
    {
        // Démarrer la génération de cibles
        targetCount = targetSpawnDataList.Count;
        Debug.Log("Nombre total de cibles : " + targetCount);
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        // Parcourir la liste des données de spawn
        for (int i = 0; i < targetSpawnDataList.Count; i++)
        {
            // Générer une nouvelle cible avec les données de spawn
            Instantiate(targetPrefab, targetSpawnDataList[i].position, Quaternion.identity);

            // Attendre le délai spécifié avant le prochain spawn
            yield return new WaitForSeconds(targetSpawnDataList[i].spawnDelay);
        }

        // Appeler la méthode appropriée dans EndMenuController après un délai de 4 secondes
        Invoke("ShowEndMenu", 4f);
    }

    void ShowEndMenu()
    {
        // Appeler la méthode appropriée dans EndMenuController
        endGameCanvas.gameObject.SetActive(true);
        endMenuController.ShowEndMenu();
        endGamePanel.DOAnchorPosX(3f, 1f);  
    }
}
