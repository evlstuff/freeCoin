using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    Landing, Jumper
}

public class SceneCtrl : MonoBehaviour
{
    public Scenes NextScene;

    public void LoadNextScene()
    {
        StartCoroutine(LoadAsyncScene(NextScene.ToString()));
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
            OnSceneLoaded();
        }
    }

    void OnSceneLoaded()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
