using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpspeed = 0.05f;

    public delegate void DamageTaken(float damage);
    public static event DamageTaken OnDamageTaken;

    // Reference to the game over screen
   // public GameObject gameOverScreen;

    void Start()
    {
        health = maxHealth;
        lerpspeed = 0.05f;
        UpdateHealthBar();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(10);
        }*/

        if (healthSlider != null && easeHealthSlider != null) // Add null check here
        {
            if (healthSlider.value != easeHealthSlider.value)
            {
                easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpspeed);
            }
        }

        /*
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpspeed);
        }
        
        // Check if health is zero and trigger game over
        if (health <= 0)
        {
            GameOver();
        }
        */
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        UpdateHealthBar();

        // Notify listeners that damage has been taken
        OnDamageTaken?.Invoke(damage);
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthBar();
    }

   // void GameOver()
    //{
        // Activate the game over screen
        //if (gameOverScreen != null)
        //{
        //    gameOverScreen.SetActive(true);
       // }
        // Optionally, you can pause the game or perform other game over actions here
    //}
}
