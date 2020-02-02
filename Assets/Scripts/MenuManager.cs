using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject options;
    public Resolution[] r;
    public int currentRes;
    public bool fullScreen;

    private void Start()
    {
        Time.timeScale = 1;
        r = Screen.resolutions;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        options.SetActive(false);
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        options.SetActive(false);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false);
        options.SetActive(true);
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextRes()
    {
        if(currentRes+1 >= r.Length)
        {
            currentRes = 0;
        }
        else
        {
            currentRes++;
        }

        GameObject.Find("Resolution").GetComponent<Text>().text = "Resolution: " + r[currentRes].ToString();
    }

    public void PrevRes()
    {
        if (currentRes-1 < 0)
        {
            currentRes = r.Length-1;
        }
        else
        {
            currentRes++;
        }

        GameObject.Find("Resolution").GetComponent<Text>().text = "Resolution: " + r[currentRes].ToString();
    }
    public void FullscreenTrue()
    {
        fullScreen = true;
        GameObject.Find("Fullscreen").GetComponent<Text>().text = "Fullscreen: On";
    }

    public void FullscreenFalse()
    {
        fullScreen = false;
        GameObject.Find("Fullscreen").GetComponent<Text>().text = "Fullscreen: Off";
    }

    public void vSyncOn()
    {
        QualitySettings.vSyncCount = 1;
        GameObject.Find("VSync").GetComponent<Text>().text = "VSync: On";
    }

    public void vSyncOff()
    {
        QualitySettings.vSyncCount = 0;
        GameObject.Find("VSync").GetComponent<Text>().text = "VSync: Off";
    }

    public void ApplySettings()
    {
        Screen.SetResolution(r[currentRes].width, r[currentRes].height, fullScreen);
    }
}
