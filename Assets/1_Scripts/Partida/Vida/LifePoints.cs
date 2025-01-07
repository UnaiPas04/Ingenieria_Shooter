using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    public int maxLifePoints = 100;//inicializas en el inspector a cada enemigo
    private int lifePoints;
    private List<IHealthObserver> observers = new List<IHealthObserver>();

    private void Awake()
    {
        lifePoints = maxLifePoints;
    }

    public int getLifePoints()
    {
        return lifePoints;
    }
    public int DecreaseLifePoints(int damage)
    {
        if (lifePoints > damage)
        {
            lifePoints-=damage;
        }
        else
        {
            lifePoints = 0;
            NotifyDeath();
        }
        NotifyHealthChange();
        return lifePoints;
    }

    public bool IsAlive()
    {
        return lifePoints > 0;
    }

    public float GetPercent()
    {
        return (float)lifePoints / (float)maxLifePoints;
    }

    public void AddObserver(IHealthObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IHealthObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyHealthChange()
    {
        foreach (IHealthObserver observer in observers)
        {
            observer.OnHealthChange(lifePoints, maxLifePoints);
        }
    }

    public void NotifyDeath()
    {
        foreach (IHealthObserver observer in observers)
        {
            observer.OnDeath();
        }
    }
}
