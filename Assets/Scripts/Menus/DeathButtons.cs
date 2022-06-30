using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButtons : MonoBehaviour
{
    private int levelIndex = 1;
    public void OnClickRetry()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
