using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    public void Reset()
    {
        SceneManager.GetActiveScene();
    }

  
}