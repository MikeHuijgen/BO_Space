using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
    private int levelIndex = 1;
    private int mainMenuIndex = 0;
    public void OnClickPlay()
    {
        SceneManager.LoadScene(levelIndex);
        Debug.Log("Pressed play");
    }

    public void OnClickedMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
        Debug.Log("Pressed main menu");
    }

    public void OnClickPQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
