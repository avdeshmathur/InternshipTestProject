using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject MainMenuUI;
    public Dropdown resolutionDropdown;
    public GameObject AboutUI;
    public GameObject Option;
    public static bool mainMenuUI = true;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void back()
    {
        Option.SetActive(false);
        AboutUI.SetActive(false);
        MainMenuUI.SetActive(true);
        mainMenuUI = true;
    }

    public void option()
    {
        Option.SetActive(true);
        MainMenuUI.SetActive(false);
        mainMenuUI = false;
    }

    public void about()
    {
        AboutUI.SetActive(true);
        MainMenuUI.SetActive(false);
        mainMenuUI = false;
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void fullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void setResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
