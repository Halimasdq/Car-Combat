using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject[] cars;
    public int currentCar;
    public bool inGameplayScene = false;

    void Start()
    {
        PlayerPrefs.SetInt("SelectedCarID", 1);

        if (inGameplayScene)
        {
            currentCar = PlayerPrefs.GetInt("SelectedCarID");
            cars[currentCar].SetActive(true);
        }
    }

    public void Right()
    {
        if (currentCar < cars.Length - 1)
        {
            cars[currentCar].SetActive(false);
            currentCar++;
            cars[currentCar].SetActive(true);
        }
    }

    public void Left()
    {
        if (currentCar > 0)
        {
            cars[currentCar].SetActive(false);
            currentCar--;
            cars[currentCar].SetActive(true);
        }
    }

    public void Select()
    {
        // Debug statement to check if the method is called
       // Debug.Log("Select() method called.");

        PlayerPrefs.SetInt("SelectedCarID", currentCar);
        SceneManager.LoadScene(1);
    }
}


