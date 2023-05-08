using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Gaming");
    }
}