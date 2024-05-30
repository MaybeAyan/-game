using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            currentHealth = 0;
            gameObject.SetActive(false);
        }

        healthSlider.value = currentHealth;
    }
}
