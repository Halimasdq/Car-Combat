using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadingscenes : MonoBehaviour
{
    public GameObject Loading;
    public Slider loader;
    
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine (LoadAsynchronously  (sceneIndex));
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Loading.SetActive (true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loader.value = progress;
            yield return null;
        }
    }

    public void QuitApplicationFun()
    {
        Application.Quit();
    }

}
