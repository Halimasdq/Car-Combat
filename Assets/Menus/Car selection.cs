using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carselection : MonoBehaviour
{
    public GameObject[] cars;
    public int currentcar;
    public bool inGamePlayScene;


    void Start()
    {

    }

    void Update()
    {

    }

    public void Right()
    {
        if (currentcar < cars.Length - 1)
        {
            currentcar += 1;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[currentcar].SetActive(true);
            }

        }
    }

    void Left()
    {
        if (currentcar > 0)
        {
            currentcar -= 1;
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SetActive(false);
                cars[currentcar].SetActive(true);
            }

        }

    }
}