using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneUtils.LoadSceneSafe(SceneNames.LEVEL_1);
    }

    public void GoToHome()
    {
        SceneUtils.LoadSceneSafe(SceneNames.START_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
