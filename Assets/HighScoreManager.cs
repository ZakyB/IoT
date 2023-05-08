using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highScoreText;
    private int highScore;

    // Clé pour stocker le meilleur score dans PlayerPrefs
    private const string HighScoreKey = "HighScore";

    // Méthode appelée au démarrage du jeu
    void Start()
    {
        // Vérifier si le meilleur score est déjà enregistré
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey);
            UpdateHighScoreText();
        }
        else
        {
            // Aucun meilleur score enregistré, initialiser à 0
            highScore = 0;
        }
    }

    // Méthode appelée pour mettre à jour le meilleur score
    public void UpdateHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            UpdateHighScoreText();

            // Enregistrer le nouveau meilleur score dans PlayerPrefs
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }

    // Méthode appelée pour afficher le meilleur score à l'écran
    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
