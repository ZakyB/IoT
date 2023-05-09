using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndMenuController : MonoBehaviour
{
    //public PlayerController playerController; // Référence au PlayerController
    //public TargetSpawnerController targetSpawnerController; // Référence au PlayerController
    public TextMeshProUGUI endMenuText;

    public void ShowEndMenu()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        TargetSpawnerController targetSpawnerController = FindObjectOfType<TargetSpawnerController>();
        
        // Mettez ici votre code pour afficher le menu de fin de partie
        int score = playerController.score;
        int totalShot = playerController.totalShot;
        int totalHit = playerController.totalHit;
        int totalSweet = playerController.totalSweet;
        int targetCount = targetSpawnerController.targetCount;
        float targetDestroyedRatio = (float)totalHit / targetCount;
        float shotAccuracyRatio = (float)totalHit / totalShot;
        float accuracyRate = (float)(targetDestroyedRatio * shotAccuracyRatio) * 100f;
        float accuracySweet = (float)totalSweet / totalHit * 100f;

        endMenuText.SetText("Score : "+score.ToString()+"\n\nTaux de tir réussi : "+accuracyRate.ToString("F2")+"%\n\nTaux de tir parfait : "+accuracySweet.ToString("F2")+"%");
        Debug.Log("TS:"+totalSweet+" TH"+totalHit);
        // endMenuText.SetText("targetDestroyedRatio : "+targetDestroyedRatio+"\n\nshotAccuracyRatio : "+shotAccuracyRatio+"\n\ntargetCount : "+accuracyRate);
        // Activez ici votre panneau de fin de partie
        gameObject.SetActive(true);
    }
    void Update()
    {
    PlayerController playerController = FindObjectOfType<PlayerController>();
    if(playerController.menu == true)
    {
        MainMenuButtonClicked();
        playerController.menu = false;
    }
    }
    public void ReplayButtonClicked()
    {
        // Rechargez la scène actuelle
        
        Scene currentScene = SceneManager.GetActiveScene();
        PlayerController playerController = FindObjectOfType<PlayerController>();
        playerController.ResetScore();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void MainMenuButtonClicked()
    {
        // Rechargez la scène du menu principal (assurez-vous d'ajuster l'index de la scène en conséquence)
        DestroyPlayer();
        DestroyUI();
        SceneManager.LoadScene("Menu");
        
    }

    private void DestroyPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

    }

    private void DestroyUI()
    {
        // Supposer que votre UI a un parent ou un conteneur dans la scène
        GameObject uiContainer = GameObject.Find("UI");

    }
}