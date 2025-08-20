using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneUtils.LoadSceneSafe(SceneNames.LEVEL_1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
