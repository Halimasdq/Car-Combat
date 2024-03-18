<<<<<<< Updated upstream
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadingscenes : MonoBehaviour
{
    public GameObject Loading;
    public Slider loader;

    public GameObject[] characters; // 0 , 1
    public Transform startingPosition;

   /* void Awake()
    {
        // Check if PlayerPrefs has the selected main character
        int mainCharacter = PlayerPrefs.GetInt("SelectedCarID");
        // 1 - black car
        // 2 - white car

        // Find the selected main character in the array and spawn it
        Instantiate(characters[mainCharacter - 1], startingPosition.position, startingPosition.rotation);
    }*/

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
>>>>>>> Stashed changes
