using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Gaming");
    }
    public void OpenSettings()
    {
        
        SceneManager.LoadScene("NomDeLaSceneDesParametres");
    }
    public void OpenScore()
    {
        
        SceneManager.LoadScene("RecordScore");
    }

   
}