using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public Image play;
    public Image setting;
    public Image entertainer;
    public Image mario;
    public Image fewDollars;

    public void LoadListOfMusic()
    {
        play.gameObject.SetActive(false);
        setting.gameObject.SetActive(false);
        entertainer.gameObject.SetActive(true);
        mario.gameObject.SetActive(true);
        fewDollars.gameObject.SetActive(true);
    }
    public void LoadEntertainerScene()
    {
        SceneManager.LoadScene("Entertainer");
    }
    public void LoadMarioScene()
    {
        SceneManager.LoadScene("Mario");
    }
    public void LoadFewDollarsScene()
    {
        SceneManager.LoadScene("FewDollars");
    }

}