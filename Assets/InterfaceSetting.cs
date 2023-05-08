using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceSetting : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public GameObject settingsPanel;
    private bool settingsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        // Vérifie si les préférences sont déjà enregistrées
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
        }

        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            int fullscreenValue = PlayerPrefs.GetInt("Fullscreen");
            fullscreenToggle.isOn = fullscreenValue == 1;
        }
    }

    // Méthode appelée lorsque le volume est modifié
    public void OnVolumeChanged()
    {
        float volumeValue = volumeSlider.value;

        // Enregistre la valeur du volume
        PlayerPrefs.SetFloat("Volume", volumeValue);
        PlayerPrefs.Save();

        // Applique le volume aux paramètres du jeu
        AudioListener.volume = volumeValue;
    }

    // Méthode appelée lorsque l'état de la case à cocher fullscreen est modifié
    public void OnFullscreenToggle()
    {
        bool fullscreenValue = fullscreenToggle.isOn;

        // Enregistre l'état de fullscreen
        int fullscreenInt = fullscreenValue ? 1 : 0;
        PlayerPrefs.SetInt("Fullscreen", fullscreenInt);
        PlayerPrefs.Save();

        // Applique l'état fullscreen
        Screen.fullScreen = fullscreenValue;
    }

    // Méthode appelée lorsque le bouton du menu paramètre est cliqué
    public void ToggleSettingsPanel()
    {
        settingsOpen = !settingsOpen;
        settingsPanel.SetActive(settingsOpen);
    }
}
