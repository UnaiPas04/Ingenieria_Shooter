using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour, IHealthObserver
{
    public Slider healthBar;

    public void OnHealthChange(int currentHealth, int maxHealth)
    {
        Debug.Log((float)currentHealth/maxHealth);
        healthBar.value = (float)currentHealth / maxHealth;
    }

    public void OnDeath()
    {
        Debug.Log("GAME OVER");
    }
}
