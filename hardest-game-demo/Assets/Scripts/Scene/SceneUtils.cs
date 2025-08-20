using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneUtils
{
    public static void LoadSceneSafe(string sceneName)
    {
        try
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        catch (System.ArgumentException e)
        {
            Debug.LogError($"Failed to load scene '{sceneName}': {e.Message}");
        }
    }

    public static void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextIndex);
        }
        else
        {
            LoadSceneSafe(SceneNames.END_SCENE);
        }
    }

    public static void RestartCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        LoadSceneSafe(currentScene);
    }
}