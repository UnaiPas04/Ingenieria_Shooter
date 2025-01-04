using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    public int MaxLifePoints=100;//inicializas en el inspector a cada enemigo
    public int lifePoints;
   // private VictoryManager victoryManager;

    private void Awake()
    {
        lifePoints = MaxLifePoints;
      //  victoryManager = FindFirstObjectByType<VictoryManager>();
       // victoryManager.OnHealthChange(lifePoints, MaxLifePoints);
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
         /*   if (victoryManager != null)
            {
                victoryManager.OnHealthChange(0, MaxLifePoints);
            }*/
        }
        return lifePoints;
    }

    public bool IsAlive()
    {
        return lifePoints > 0;
    }

    public float GetPercent()
    {
        return (float)lifePoints / (float)MaxLifePoints;
    }
}
