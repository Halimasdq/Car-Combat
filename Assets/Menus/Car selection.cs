using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelectionManager : MonoBehaviour
{
    public GameObject[] cars;
    public int currentCar;
    public bool inGameplayScene = false;

    void Start()
    {
        PlayerPrefs.SetInt("SelectedCarID", 1);

        if (inGameplayScene == true)
        {
            cars[PlayerPrefs.GetInt("SelectedCarID")].SetActive(true);
            currentCar = PlayerPrefs.GetInt("SelectedCarID");
        }

    }


    public void Right()
    {
        if (currentCar < cars.Length - 1)
        {
            currentCar += 1;
            for (int i = 0; i < cars.Length; i++)
            {
                if (currentCar < cars.Length)
                {
                    cars[i].gameObject.SetActive(false);
                    cars[currentCar].SetActive(true);
                }
            }
        }
    }


    public void Left()
    {
        if (currentCar > 0)
        {
            currentCar -= 1;
            for (int i = 0; i < cars.Length; i++)
            {
                if (currentCar < cars.Length)
                {
                    cars[i].gameObject.SetActive(false);
                    cars[currentCar].SetActive(true);
                }
            }
        }
    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedCarID", currentCar);
        SceneManager.LoadScene(1);
    }

}