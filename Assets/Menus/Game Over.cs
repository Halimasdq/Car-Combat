using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject YouWin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UserPlayer")
        {
            YouWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("level 1");
    }
}