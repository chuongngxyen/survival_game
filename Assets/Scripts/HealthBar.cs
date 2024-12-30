using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider easeHealthSlider;
    [SerializeField] private float maxHealth = 100f;
    private float health;

    private float lerpSpeed = 0.05f;
    private Slider healthSlider;
    private void Awake()
    {
        health = maxHealth;
        healthSlider = GetComponent<Slider>();
        
    }
    private void Start()
    {
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;
        easeHealthSlider.maxValue = maxHealth;
    }

    private void Update()
    {
        if (health < 0)
        {
            health = 0;
        }
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
        }
    }

    public void takeDamage (float damage)
    {
        health -= damage;   
    }

    public void SetMaxHealth ()
    {
        health = maxHealth;
    }

    public float getHealth() { 
        return health;
    }
}
