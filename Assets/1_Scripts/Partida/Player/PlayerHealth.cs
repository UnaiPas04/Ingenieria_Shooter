using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private List<IHealthObserver> observers = new List<IHealthObserver>();

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            NotifyHealthChange();
            NotifyPlayerDeath();
        }
        else
        {
            NotifyHealthChange();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        NotifyHealthChange();
    }

    private void NotifyPlayerDeath()
    {
        foreach (var observer in observers)
        {
            observer.OnDeath();
        }
    }

    private void NotifyHealthChange()
    {
        foreach (var observer in observers)
        {
            observer.OnHealthChange(currentHealth, maxHealth);
        }
    }

    public void AddObserver(IHealthObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IHealthObserver observer)
    {
        observers.Remove(observer);
    }
}
